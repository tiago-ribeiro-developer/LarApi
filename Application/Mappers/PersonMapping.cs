using Domain.Entities;
using Application.ViewModels;

namespace Application.Mappers;

public static class PersonMapping
{
    public static PersonViewModel ToViewModel(this Person person)
    {
        return new PersonViewModel()
        {
            Id = person.Id,
            Nome = person.Name,
            CPF = person.Document,
            DataNascimento = person.DateOfBirth,
            Telefones = person.Phones
        };
    }
}