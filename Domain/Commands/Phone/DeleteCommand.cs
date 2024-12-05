namespace Domain.Commands.Phone;

public class DeleteCommand : PhoneCommand
{
    public DeleteCommand(int id)
    {
        Id = id;
    }
}