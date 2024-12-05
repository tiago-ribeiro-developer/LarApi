using Domain.Common;
using Domain.Interfaces.Repositories;
using FluentValidation.Results;
using MediatR;

namespace Domain.Commands.Person;

public class PersonCommandHandler : CommandHandler,
    IRequestHandler<AddCommand, ValidationResult>,
    IRequestHandler<DeleteCommand, ValidationResult>,
    IRequestHandler<UpdateCommand, ValidationResult>
{
    private readonly IPersonRepository _repository;
    private readonly IMediator _mediator;
    
    public PersonCommandHandler(IPersonRepository personRepository, IMediator mediator)
    {
        _repository = personRepository;
        _mediator = mediator;
    }
    
    public async Task<ValidationResult> Handle(AddCommand request, CancellationToken cancellationToken)
    {
        var person = new Entities.Person(
            request.Name,
            request.Document,
            request.DateOfBirth,
            request.Active,
            request.Phones
        );
        await _repository.AddAsync(person);
        return new ValidationResult();
    }
    
    public async Task<ValidationResult> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        var person = await _repository.GetByIdAsync(request.Id);
        if (person == null)
        {
            return new ValidationResult(new List<ValidationFailure>
            {
                new ValidationFailure("Person", "Person not found.")
            });
        }
        person.Name = request.Name;
        person.Document = request.Document;
        person.DateOfBirth = request.DateOfBirth;
        person.Active = request.Active;
        
        await _repository.UpdateAsync(person);
        return new ValidationResult();
    }

    public async Task<ValidationResult> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
        return new ValidationResult();
    }
}