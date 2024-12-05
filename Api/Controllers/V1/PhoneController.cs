using Api.Controllers.Common;
using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers.V1
{
    /// <summary>
    /// Controller para gerenciar operações relacionadas a telefones.
    /// </summary>
    [Route("api/v1/phone")]
    [ApiController]
    public class PhoneController : ApiBase
    {
        private readonly IPhoneApplicationService _applicationService;

        /// <summary>
        /// Construtor da controller.
        /// </summary>
        /// <param name="phoneApplicationService">Serviço de aplicação para manipulação de dados de telefone.</param>
        public PhoneController(IPhoneApplicationService phoneApplicationService)
        {
            _applicationService = phoneApplicationService;
        }

        /// <summary>
        /// Registra um novo telefone.
        /// </summary>
        /// <param name="viewModel">Modelo com os dados do telefone a ser registrado.</param>
        /// <returns>Retorna 200 (Ok) se o registro for bem-sucedido, ou 400 (BadRequest) se houver erros de validação.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Registra um novo telefone")]
        public async Task<IActionResult> RegisterAsync(PhoneViewModel.RegisterPhoneViewModel viewModel)
        {
            var result = await _applicationService.RegisterAsync(viewModel);
            if (result.IsValid)
                return Ok();
            return BadRequest(result.Errors);
        }

        /// <summary>
        /// Atualiza os dados de um telefone.
        /// </summary>
        /// <param name="id">ID do telefone a ser atualizado.</param>
        /// <param name="viewModel">Modelo com os novos dados do telefone.</param>
        /// <returns>Retorna 200 (Ok) se a atualização for bem-sucedida, ou 400 (BadRequest) se houver erros de validação.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Atualiza os dados de um telefone")]
        public async Task<IActionResult> UpdateAsync(PhoneViewModel.UpdatePhoneViewModel viewModel)
        {
            var result = await _applicationService.UpdateAsync(viewModel);
            if (result.IsValid)
                return Ok();
            return BadRequest(result.Errors);
        }

        /// <summary>
        /// Obtém os dados de um telefone pelo ID.
        /// </summary>
        /// <param name="id">ID do telefone.</param>
        /// <returns>Retorna 200 (Ok) com os dados do telefone, ou 404 (NotFound) se o telefone não for encontrado.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PhoneViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Obtém os dados de um telefone pelo ID")]
        public async Task<ActionResult<PhoneViewModel>> GetByIdAsync(int id)
        {
            var result = await _applicationService.GetByIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        /// <summary>
        /// Obtém a lista de telefones associados a um usuário.
        /// </summary>
        /// <param name="idUser">ID do usuário.</param>
        /// <returns>Retorna 200 (Ok) com a lista de telefones, ou 404 (NotFound) se nenhum telefone for encontrado.</returns>
        [HttpGet("all/{idUser}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PhoneViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Obtém a lista de telefones associados a um usuário")]
        public async Task<IActionResult> GetAllAsync(int idUser)
        {
            var result = await _applicationService.GetAllByIdUserAsync(idUser);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        /// <summary>
        /// Exclui um telefone pelo ID.
        /// </summary>
        /// <param name="id">ID do telefone a ser excluído.</param>
        /// <returns>Retorna 200 (Ok) se a exclusão for bem-sucedida, ou 400 (BadRequest) se houver erros.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Exclui um telefone pelo ID")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _applicationService.DeleteAsync(id);
            if (result.IsValid)
                return Ok();
            return BadRequest(result.Errors);
        }
    }
}
