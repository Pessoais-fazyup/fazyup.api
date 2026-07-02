using fazyup.api.Feature.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fazyup.api.Feature.Admin
{
    [ApiController]
    [Route("/Admin")]
    [AllowAnonymous]
    public class AdminController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Execute([FromBody] AdminInput adminInput)
        {
            return Ok(adminInput);
        }
    }
}
