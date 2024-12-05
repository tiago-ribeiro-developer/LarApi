namespace Domain.Commands.Phone;

public class UpdateCommand : PhoneCommand
{
    public UpdateCommand(
        int id,
        string type,
        string number)
    {
        Id = id;
        Type = type;
        Number = number;
    }
}