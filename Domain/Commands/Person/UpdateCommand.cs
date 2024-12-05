namespace Domain.Commands.Person;

public class UpdateCommand : PersonCommand
{
    public UpdateCommand(
        int id,
        string name,
        string document,
        DateTime dateOfBirth)
    {
        Id = id;
        Name = name;
        Document = document;
        DateOfBirth = dateOfBirth;
    }
}