using Domain.Entities;

namespace Domain.Dto;

public class PhoneDto
{
    public int id { get; protected set; }
    public string type { get; set; }
    public string number { get; set; }
    public int personId { get; set; }

    public static class Factory
    {
        public static PhoneDto Create(Phone phone)
        {
            var phoneDto = new PhoneDto() { };
            phoneDto.type = phone.Type;
            phoneDto.number = phone.Number;
            phoneDto.personId = phone.PersonId;

            return phoneDto;
        }
        
        public static PhoneDto Update(Phone phone)
        {
            var phoneDto = new PhoneDto() { };
            phoneDto.id = phone.Id;
            phoneDto.type = phone.Type;
            phoneDto.number = phone.Number;

            return phoneDto;
        }
        
        public static PhoneDto Delete(int id)
        {
            var phoneDto = new PhoneDto() { };
            phoneDto.id = id;
            
            return phoneDto;
        }
    }
}