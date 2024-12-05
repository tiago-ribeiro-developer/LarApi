using Domain.Entities;

namespace Domain.Dto;

public class PersonDto
{
    public int id { get; set; }
    public string name { get; set; }
    public string document { get; set; }
    public DateTime dateofbirth { get; set; }
    public Boolean active { get; set; }
    public string phones { get; set; }

    public static class Factory
    {
        public static PersonDto Create(Person person)
        {
            var personDto = new PersonDto() { };
            personDto.name = person.Name;
            personDto.document = person.Document;
            personDto.dateofbirth = person.DateOfBirth;
            personDto.active = person.Active;

            return personDto;
        }
        
        public static PersonDto Update(Person person)
        {
            var personDto = new PersonDto() { };
            personDto.id = person.Id;
            personDto.name = person.Name;
            personDto.document = person.Document;
            personDto.dateofbirth = person.DateOfBirth;
            personDto.active = person.Active;

            return personDto;
        }
        
        public static PersonDto Delete(int id)
        {
            var personDto = new PersonDto() { };
            personDto.id = id;
            
            return personDto;
        }
    }
}