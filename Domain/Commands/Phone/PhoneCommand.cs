using Domain.Common;

namespace Domain.Commands.Phone;

public class PhoneCommand : Command
{
    public int Id { get; protected set; }
    public string Type { get; set; }
    public string Number { get; set; }
    public int PersonId { get; set; }

}