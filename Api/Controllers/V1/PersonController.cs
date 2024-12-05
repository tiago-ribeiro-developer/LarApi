using Api.Controllers.Common;
using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers.V1
{
    /// <summary>
    /// Controller para gerenciar operações relacionadas a pessoas.
    /// </summary>
    [Route("api/v1/person")]
    [ApiController]
    public class PersonController : ApiBase
    {
        private readonly IPersonApplicationService _applicationService;

        /// <summary>
        /// Construtor da controller.
        /// </summary>
        /// <param name="personApplicationService">Serviço de aplicação para manipulação de dados de pessoa.</param>
        public PersonController(IPersonApplicationService personApplicationService)
        {
            _applicationService = personApplicationService;
        }

        /// <summary>
        /// Registra uma nova pessoa.
        /// </summary>
        /// <param name="viewModel">Modelo com os dados da pessoa a ser registrada.</param>
        /// <returns>Retorna 200 (Ok) se o registro for bem-sucedido, ou 400 (BadRequest) se houver erros de validação.</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Registra uma nova pessoa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync(PersonViewModel.RegisterPersonViewModel viewModel)
        {
            var result = await _applicationService.RegisterAsync(viewModel);
            if (result.IsValid)
                return Ok();
            return BadRequest(result.Errors);
        }

        /// <summary>
        /// Atualiza os dados de uma pessoa.
        /// </summary>
        /// <param name="id">ID da pessoa a ser atualizada.</param>
        /// <param name="viewModel">Modelo com os novos dados da pessoa.</param>
        /// <returns>Retorna 200 (Ok) se a atualização for bem-sucedida, ou 400 (BadRequest) se houver erros de validação.</returns>
        [HttpPut]
        [SwaggerOperation(Summary = "Atualiza os dados de uma pessoa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(PersonViewModel.UpdatePersonViewModel viewModel)
        {
            var result = await _applicationService.UpdateAsync(viewModel);
            if (result.IsValid)
                return Ok();
            return BadRequest(result.Errors);
        }

        /// <summary>
        /// Obtém os dados de uma pessoa pelo ID.
        /// </summary>
        /// <param name="id">ID da pessoa.</param>
        /// <returns>Retorna 200 (Ok) com os dados da pessoa, ou 404 (NotFound) se a pessoa não for encontrada.</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém os dados de uma pessoa pelo ID")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonViewModel>> GetByIdAsync(int id)
        {
            var result = await _applicationService.GetByIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        /// <summary>
        /// Obtém a lista de todas as pessoas.
        /// </summary>
        /// <returns>Retorna 200 (Ok) com a lista de pessoas, ou 404 (NotFound) se nenhuma pessoa for encontrada.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a lista de todas as pessoas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PersonViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _applicationService.GetAllAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        /// <summary>
        /// Exclui uma pessoa pelo ID.
        /// </summary>
        /// <param name="id">ID da pessoa a ser excluída.</param>
        /// <returns>Retorna 200 (Ok) se a exclusão for bem-sucedida, ou 400 (BadRequest) se houver erros.</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui uma pessoa pelo ID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _applicationService.DeleteAsync(id);
            if (result.IsValid)
                return Ok();
            return BadRequest(result.Errors);
        }
    }
}
