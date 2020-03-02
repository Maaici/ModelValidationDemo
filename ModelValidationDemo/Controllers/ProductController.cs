using Microsoft.AspNetCore.Mvc;
using ModelValidationDemo.Entities;
using System.Threading.Tasks;

namespace ModelValidationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddNewProduct(Product product) {
            if (!ModelState.IsValid) { //手动验证，验证不通过手动返回错误信息
                return ValidationProblem(ModelState);
            }
            return Ok("模型验证通过！");
        }
    }
}