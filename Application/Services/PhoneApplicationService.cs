using MediatR;
using Application.Mappers;
using Domain.Commands.Phone;
using Application.Interfaces;
using Application.ViewModels;
using FluentValidation.Results;
using Domain.Interfaces.Repositories;

namespace Application.Services;

public class PhoneApplicationService : IPhoneApplicationService
{
    private readonly IPhoneRepository _repository;
    private readonly IPersonRepository _personRepository;
    private readonly IMediator _mediator;

    public PhoneApplicationService(IPhoneRepository phoneRepository, IPersonRepository personRepository, IMediator mediator)
    {
        _repository = phoneRepository;
        _personRepository = personRepository;
        _mediator = mediator;
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task<ValidationResult> RegisterAsync(PhoneViewModel.RegisterPhoneViewModel viewModel)
    {
        var command = new AddCommand(viewModel.Tipo, viewModel.Numero, viewModel.PersonId);
        return await _mediator.Send(command);
    }

    public async Task<ValidationResult> UpdateAsync(PhoneViewModel.UpdatePhoneViewModel viewModel)
    {
        var command = new UpdateCommand(viewModel.Id, viewModel.Tipo, viewModel.Numero);
        return await _mediator.Send(command);
    }

    public async Task<PhoneViewModel?> GetByIdAsync(int id)
    {
        var result = await _repository.GetByIdAsync(id);
        if (result == null) return null;
        return result.ToViewModel();
    }

    public async Task<List<PhoneViewModel>?> GetAllByIdUserAsync(int idUser)
    {
        var person = await _personRepository.GetByIdAsync(idUser);
        if (person == null)
        {
            return null;
        }
        var result = await _repository.GetAll(person);
        if (result == null) return null;
        return result.Select(x => x.ToViewModel()).ToList();
    }

    public async Task<ValidationResult> DeleteAsync(int id)
    {
        var command = new DeleteCommand(id);
        return await _mediator.Send(command);
    }
}