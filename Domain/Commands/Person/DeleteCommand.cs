using Domain.Commands.Phone;

namespace Domain.Commands.Person;

public class DeleteCommand : PhoneCommand
{
    public DeleteCommand(int id)
    {
        Id = id;
    }
}