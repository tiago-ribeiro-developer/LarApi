using Domain.Common;
using Domain.Dto;

namespace Domain.Entities;

public class Phone : EntityBase, IAggregateRoot
{
    public string Type { get; set; }
    public string Number { get; set; }
    public int PersonId { get; set; }

    public Phone()
    {
        
    }

    public Phone(string type, string number, int personId)
    {
        Type = type;
        Number = number;
        PersonId = personId;
    }
    
    public static class Factory
    {
        public static Phone Create(PhoneDto dto)
        {
            var phone = new Phone()
            {
                Id = dto.id,
                Type = dto.type,
                Number = dto.number,
                PersonId = dto.personId
            };
            return phone;
        }
    }
}