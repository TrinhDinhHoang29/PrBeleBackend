using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.DTO.RoleDTOs;
using PrBeleBackend.Core.ServiceContracts.RoleContracts;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleGetterService _roleGetterService;
        public RoleController(IRoleGetterService roleGetterService) { 
            _roleGetterService = roleGetterService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RoleResponse> roleResponses = await _roleGetterService.GetAllRole();

            return Ok(new
            {
                status = 200,
                data = new
                {
                    roles = roleResponses
                },
                message = "Data fetched successfully."
            });
        }
    }
}
