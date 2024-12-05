using Application.ViewModels;
using FluentValidation.Results;

namespace Application.Interfaces;

public interface IPersonApplicationService : IDisposable
{
    Task<ValidationResult> RegisterAsync(PersonViewModel.RegisterPersonViewModel viewModel);
    Task<ValidationResult> UpdateAsync(PersonViewModel.UpdatePersonViewModel viewModel);
    Task<PersonViewModel?> GetByIdAsync(int id);
    Task<List<PersonViewModel>?> GetAllAsync();
    Task<ValidationResult> DeleteAsync(int id);
}