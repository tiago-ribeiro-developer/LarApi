namespace Domain.Commands.Phone;

public class AddCommand : PhoneCommand
{
    public AddCommand(
        string type,
        string number, 
        int personId)
    {
        Type = type;
        Number = number;
        PersonId = personId;
    }
}