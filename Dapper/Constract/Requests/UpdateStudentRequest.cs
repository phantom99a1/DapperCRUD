namespace Constract.Requests
{
    public record UpdateStudentRequest(int Id, string FirstName, string LastName, string EmailAddress, string Major);
}
