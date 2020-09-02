using BackendTask.Business.Contracts;
using BackendTask.Business.Contracts.Messages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviserController : ControllerBase
    {

        #region Dependency Injected Fields

        private readonly IAdviserService _adviserService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AdviserController"/> class.
        /// </summary>
        /// <param name="adviserService">The adviser service.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public AdviserController(IAdviserService adviserService)
        {
            _adviserService = adviserService ?? throw new ArgumentNullException();
        }

        #endregion

        /// <summary>
        /// Creates the adviser.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/adviser")]
        public async Task<IActionResult> CreateAdviser(
            [FromBody] AdviserMessage request)
        {
            var response = await _adviserService.CreateAdviser(request);

            if ( response == null   || 
                !response.IsSuccess || 
                (response.ValidationMessages != null && response.ValidationMessages.Any()))
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Gets the adviser.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/adviser/{adviserId}")]
        public async Task<IActionResult> GetAdviser(
            [FromRoute] string adviserId)
        {
            var response = await _adviserService.GetAdviser(new Guid(adviserId));

            if (response == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Gets the advisers.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/advisers")]
        public async Task<IActionResult> GetAdvisers()
        {
            var response = await _adviserService.GetAdvisers();
            if (response == null || !response.Any())
                return Ok("No data available");
            return Ok(response);
        }

        /// <summary>
        /// Gets the adviser.
        /// </summary>
        /// <param name="adviserId">The adviser identifier.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/adviser")]
        public async Task<IActionResult> UpdateAdviser([FromBody] AdviserMessageExtended request)
        {
            var response = await _adviserService.UpdateAdviser(request);

            if (response == null ||
                !response.IsSuccess ||
                (response.ValidationMessages != null && response.ValidationMessages.Any()))
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("api/adviser/{adviserId}")]
        public async Task<IActionResult> RemoveAdviser(
            [FromRoute] string adviserId)
        {
            var response = await _adviserService.RemoveAdviser(new Guid(adviserId));

            if(response == null ||
                !response.IsSuccess ||
                (response.ValidationMessages != null && response.ValidationMessages.Any()))
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}