namespace Domain.Commands.Person;

public class AddCommand : PersonCommand
{
    public AddCommand(
        string name,
        string document,
        DateTime dateOfBirth,
        Boolean active)
    {
        Name = name;
        Document = document;
        DateOfBirth = dateOfBirth;
        Active = active;
    }
}