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
        private readonly IRoleAdderService _roleAdderService;
        public RoleController(IRoleGetterService roleGetterService,
            IRoleAdderService roleAdderService
            ) { 
            _roleGetterService = roleGetterService;
            _roleAdderService = roleAdderService;
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
                    roles = roleResponses.Select(r =>
                    {
                        return new
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Permissions = r.RolePermissions.Select(p => p.Permission)
                        };
                    })
                },
                message = "Data fetched successfully."
            });
        }

        [HttpPut("Decentralize")]
        public async Task<IActionResult> Decentralize(DecentralizeRequest decentralizeRequest)
        {
            try
            {
                List<RoleResponse> roleResponses = await _roleAdderService.DecentralizeAccount(decentralizeRequest);
                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        roles = roleResponses.Select(r =>
                        {
                            return new
                            {
                                Id = r.Id,
                                Name = r.Name,
                                Permissions = r.RolePermissions.Select(p => p.Permission)
                            };
                        })
                    },
                    message = "Successfully decentralize role !"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message

                });
            }
        }
    }
}
