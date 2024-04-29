using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult gettoken()
        {
            var token = new JwtHelper(_configuration).GenerateJwtToken(new User() { UserName = "张三" });
            return Content(token);
        }
        /// <summary>
        /// 测试token
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public IActionResult test()
        {
            return Content("请求成功");
        }


    }
}
