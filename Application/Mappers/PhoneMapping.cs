using Domain.Entities;
using Application.ViewModels;

namespace Application.Mappers;

public static class PhoneMapping
{
    public static PhoneViewModel ToViewModel(this Phone phone)
    {
        return new PhoneViewModel()
        {
            Id = phone.Id,
            Tipo = phone.Type,
            Numero = phone.Number,
            PersonId = phone.PersonId
        };
    }
}