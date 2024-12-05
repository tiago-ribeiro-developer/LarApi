using Application.ViewModels;
using FluentValidation.Results;

namespace Application.Interfaces;

public interface IPhoneApplicationService : IDisposable
{
    Task<ValidationResult> RegisterAsync(PhoneViewModel.RegisterPhoneViewModel viewModel);
    Task<ValidationResult> UpdateAsync(PhoneViewModel.UpdatePhoneViewModel viewModel);
    Task<PhoneViewModel?> GetByIdAsync(int id);
    Task<List<PhoneViewModel>?> GetAllByIdUserAsync(int idUser);
    Task<ValidationResult> DeleteAsync(int id);
}