using Microsoft.AspNetCore.Mvc;
namespace BalancedBracketService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BracketValidationController : ControllerBase
    {
        private readonly IBracketChecker _bracketChecker;

        public BracketValidationController(IBracketChecker bracketChecker)
        {
            _bracketChecker = bracketChecker;
        }


        [HttpPost("balanced-bracket")]
        public IActionResult checkBalanced([FromBody] string[] input)
        {
           
            if (input == null || input.Length != 3)
                return BadRequest("Exactly 3 input strings are required.");

            bool[] results = new bool[3];
            for (int i = 0; i < 3; i++)
            {
                if (string.IsNullOrEmpty(input[i]))
                    return BadRequest($"Input at index {i} is null or empty.");

                results[i] = _bracketChecker.Validate(input[i]);
            }

            return Ok(new { isBalanced = results });
        }
    }
}
