using MediatR;
using Domain.Entities;
using Application.Mappers;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Commands.Person;
using FluentValidation.Results;
using Domain.Interfaces.Repositories;

namespace Application.Services;

public class PersonApplicationService : IPersonApplicationService
{
    private readonly IPersonRepository _repository;
    private readonly IMediator _mediator;

    public PersonApplicationService(IPersonRepository personRepository, IMediator mediator)
    {
        _repository = personRepository;
        _mediator = mediator;
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task<ValidationResult> RegisterAsync(PersonViewModel.RegisterPersonViewModel viewModel)
    {
        var command = new AddCommand(viewModel.Nome, viewModel.CPF, viewModel.DataNascimento, true);
        return await _mediator.Send(command);
    }

    public async Task<ValidationResult> UpdateAsync(PersonViewModel.UpdatePersonViewModel viewModel)
    {
        var command = new UpdateCommand(viewModel.Id, viewModel.Nome, viewModel.CPF, viewModel.DataNascimento);
        return await _mediator.Send(command);
    }

    public async Task<PersonViewModel?> GetByIdAsync(int id)
    {
        var result = await _repository.GetByIdAsync(id);
        if (result == null) return null;
        
        return result.ToViewModel();
    }

    public async Task<List<PersonViewModel>?> GetAllAsync()
    {
        var result = await _repository.GetAll();
        if (result == null) return null;
        return result.Select(x => x.ToViewModel()).ToList();    
    }

    public async Task<ValidationResult> DeleteAsync(int id)
    {
        var command = new DeleteCommand(id);
        return await _mediator.Send(command);    
    }
}