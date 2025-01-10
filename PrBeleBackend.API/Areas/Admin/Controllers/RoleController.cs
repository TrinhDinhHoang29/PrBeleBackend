using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrBeleBackend.API.Filters;
using PrBeleBackend.Core.DTO.RoleDTOs;
using PrBeleBackend.Core.ServiceContracts.RoleContracts;
using PrBeleBackend.Infrastructure.DbContexts;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]

    [Authorize]
    [PermissionAuthorize("P-M")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleGetterService _roleGetterService;
        private readonly IRoleAdderService _roleAdderService;
        private readonly BeleStoreContext _beleStoreContext;
        public RoleController(IRoleGetterService roleGetterService,
            IRoleAdderService roleAdderService,
            BeleStoreContext beleStoreContext
            ) { 
            _roleGetterService = roleGetterService;
            _roleAdderService = roleAdderService;
            _beleStoreContext = beleStoreContext;
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

        [HttpGet("Permissions")]
        public async Task<IActionResult> Permissions()
        {
            var permissions = await _beleStoreContext.permissions.Select(p =>new
            {
                Id = p.Id,
                Name = p.Name, 
            }).ToListAsync();
            return Ok(new
            {
                status = 200,
                data = permissions,
                message = "Fetch data success !"
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
