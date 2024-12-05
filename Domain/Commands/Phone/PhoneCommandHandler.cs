using Domain.Common;
using Domain.Interfaces.Repositories;
using FluentValidation.Results;
using MediatR;

namespace Domain.Commands.Phone;

public class PhoneCommandHandler : CommandHandler,
    IRequestHandler<AddCommand, ValidationResult>,
    IRequestHandler<DeleteCommand, ValidationResult>,
    IRequestHandler<UpdateCommand, ValidationResult>
{
    
    private readonly IPhoneRepository _repository;
    private readonly IPersonRepository _personRepository;
    private readonly IMediator _mediator;
    
    public  PhoneCommandHandler(IPhoneRepository phoneRepository, IPersonRepository personRepository, IMediator mediator)
    {
        _repository = phoneRepository;
        _personRepository = personRepository;
        _mediator = mediator;
    }
    
    public async Task<ValidationResult> Handle(AddCommand request, CancellationToken cancellationToken)
    {
        var person = await _personRepository.GetByIdAsync(request.PersonId);
        if (person == null)
        {
            return new ValidationResult(new List<ValidationFailure>
            {
                new ValidationFailure("Person", "Person not found.")
            });
        }
        
        var phone = new Entities.Phone(
            request.Type,
            request.Number,
            request.PersonId
        );
        await _repository.AddAsync(phone);
        return new ValidationResult();    
    }

    public async Task<ValidationResult> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        var phone = await _repository.GetByIdAsync(request.Id);
        if (phone == null)
        {
            return new ValidationResult(new List<ValidationFailure>
            {
                new ValidationFailure("Phone", "Phone not found.")
            });
        }

        phone.Number = request.Number;
        phone.Type = request.Type;
        
        await _repository.UpdateAsync(phone);
        return new ValidationResult();    
    }

    public async Task<ValidationResult> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
        return new ValidationResult();    
    }
}