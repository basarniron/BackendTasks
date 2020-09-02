using BackendTask.Business.Contracts;
using BackendTask.Business.Contracts.Messages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTask.API.Controllers
{
    /// <summary>
    /// Client Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        #region Dependency Injected Fields

        private readonly IClientService _clientService;

        #endregion

        #region Constructors

        public ClientController(IClientService clientService)
        {
            _clientService = clientService ?? throw new ArgumentNullException();
        }

        #endregion


        /// <summary>
        /// Creates the client.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/client/{adviserId}")]
        public async Task<IActionResult> CreateClient(
            [FromRoute] string adviserId,
            [FromBody] ClientMessage request)
        {
            var response = await _clientService.CreateClient(new Guid(adviserId), request);

            if (response == null ||
                !response.IsSuccess ||
                (response.ValidationMessages != null && response.ValidationMessages.Any()))
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/client/{adviserId}/{clientId}")]
        public async Task<IActionResult> GetClient(
            [FromRoute] string adviserId,
            [FromRoute] string clientId)
        {
            var response = await _clientService.GetClient(new Guid(adviserId), new Guid(clientId));

            if (response == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        
        [HttpGet]
        [Route("api/clients/{adviserId}")]
        public async Task<IActionResult> GetClients(
            [FromRoute] string adviserId)
        {
            var response = await _clientService.GetClients(new Guid(adviserId));
            if (response == null || !response.Any())
                return Ok("No data available");
            return Ok(response);
        }

      
        [HttpPut]
        [Route("api/client/{adviserId}")]
        public async Task<IActionResult> UpdateClient(
            [FromRoute] string adviserId,
            [FromBody] ClientMessageExtended request)
        {
            var response = await _clientService.UpdateClient(new Guid(adviserId), request);

            if (response == null ||
                !response.IsSuccess ||
                (response.ValidationMessages != null && response.ValidationMessages.Any()))
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("api/client/{adviserId}/{clientId}")]
        public async Task<IActionResult> RemoveClient(
            [FromRoute] string adviserId,
            [FromRoute] string clientId)
        {
            var response = await _clientService.RemoveClient(new Guid(adviserId), new Guid(clientId));

            if (response == null ||
                !response.IsSuccess ||
                (response.ValidationMessages != null && response.ValidationMessages.Any()))
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}