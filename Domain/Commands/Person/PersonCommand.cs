using Domain.Common;

namespace Domain.Commands.Person;

public class PersonCommand : Command
{
    public int Id { get; protected set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Boolean Active { get; set; }
    public List<string> Phones { get; protected set; }

}