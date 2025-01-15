using Domain.Persistence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Reflection.Metadata;

namespace Persistence.Providers
{
    public class EntityAttributeValuesProvider : IEntityAttributeValuesProvider
    {
        public Dictionary<string, string> GetColumnsAndModelPropertyNames<T>(bool addKey = true)
        {
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            var columnNamePropertyNameDict = new Dictionary<string, string>();

            foreach (var propertyInfo in propertyInfos)
            {
                if(propertyInfo.GetCustomAttributes(typeof(CustomAttribute), true).FirstOrDefault() is ColumnAttribute columnAttribute)
                {
                    if(addKey || propertyInfo.GetCustomAttributes(typeof(KeyAttribute), true).Length == 0)
                    {
                        if(columnAttribute.Name != null)
                        {
                            columnNamePropertyNameDict.Add(columnAttribute.Name, propertyInfo.Name);
                        }
                    }
                }
                else
                {
                    throw new Exception($"Column Attribute is missing for property: {propertyInfo.Name}");
                }
            }

            return columnNamePropertyNameDict;
        }

        public string GetFormattedStringFromColumnsAndPropertyNames<T>(Dictionary<string, string> columnNamePropertyNames, string formatString)
        {
            var result = string.Join(", ", columnNamePropertyNames
            .Select(columnNamePropName =>
                string.Format(formatString, columnNamePropName.Key, columnNamePropName.Value)));

            return result;
        }

        public (string?, string) GetKeyColumnNamePropertyName<T>()
        {
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                if (propertyInfo.GetCustomAttributes(typeof(KeyAttribute), true).Length > 0 &&
                    propertyInfo.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault() is
                        ColumnAttribute columnAttribute)
                {
                    return (columnAttribute.Name, propertyInfo.Name);
                }
            }

            throw new Exception("Provided model does not contain KeyColumnAttribute");
        }

        public string GetTableName<T>()
        {
            var attributes = typeof(T).GetCustomAttributes(typeof(TableAttribute), true);
            if (attributes.Length > 0)
            {
                var tableAttribute = (TableAttribute)attributes[0];
                return tableAttribute.Name;
            }

            throw new Exception("Table Attribute is missing.");
        }
    }        
}
