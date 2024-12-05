using Domain.Common;
using Domain.Dto;

namespace Domain.Entities;

public class Person : EntityBase, IAggregateRoot
{
    public string Name { get; set; }
    public string Document { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Boolean Active { get; set; }
    public List<string> Phones { get; set; }
    
    public Person(
        string name,
        string document,
        DateTime dateOfBirth,
        Boolean active,
        List<string> phones
    )
    {
        Name = name;
        Document = document;
        DateOfBirth = dateOfBirth;
        Active = active;
        Phones = phones;
    }

    public Person()
    {
        
    }
    
    public static class Factory
    {
        public static Person Create(PersonDto dto)
        {
            var person = new Person()
            {
                Id = dto.id,
                Name = dto.name,
                Document = dto.document,
                DateOfBirth = dto.dateofbirth,
                Active = dto.active,
                Phones = dto.phones != null ? dto.phones.Split(",").ToList() : null,

            };
            return person;
        }
    }
}