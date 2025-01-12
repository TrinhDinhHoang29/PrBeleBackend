using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.API.Filters;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.AccountContracts;
using System.Collections.Generic;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountGetterService _accountGetterService;
        private readonly IAccountAdderService _accountAdderService;
        private readonly IAccountSorterService _accountSorterService;
        private readonly IAccountUpdaterService _accountUpdaterService;
        private readonly IAccountDeleterService _accountDeleterService;
        public AccountController(
            IAccountGetterService accountGetterService,
            IAccountSorterService accountSorterService,
            IAccountAdderService accountAdderService,
            IAccountUpdaterService accountUpdaterService,
            IAccountDeleterService accountDeleterService
            ) {
            _accountGetterService = accountGetterService;
            _accountSorterService = accountSorterService;
            _accountAdderService = accountAdderService;
            _accountUpdaterService = accountUpdaterService;
            _accountDeleterService = accountDeleterService;
        }
        [PermissionAuthorize("A-R")]
        [HttpGet]
        public async Task<IActionResult> Index(
            int? status,
            string? sort,
            string field = "",
            string query = "",
            SortOrderOptions? order = SortOrderOptions.ASC,
            int page = 1,
            int limit = 10
            )
        {

            List<AccountResponse> accounts = await _accountGetterService.GetFilteredAccount(field, query);

            List<AccountResponse> paginaAccount = accounts
                .Where(a => status == 0 || status == 1 ? a.Status == status : true)
                .Skip(limit * (page - 1)).Take(limit).ToList();

            List<AccountResponse> sortedAccount = await _accountSorterService.SortAccounts(paginaAccount, sort, order.ToString());

            return Ok(new
            {
                status = 200,
                data = new
                {
                    accounts = sortedAccount,
                    pagination = new
                    {
                        currentPage = page,
                        totalPage = Math.Ceiling((decimal)accounts.Count / limit),
                    }
                },
                message = "Data fetched successfully."

            });
        }

        [PermissionAuthorize("A-R")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> Detail(int Id)
        {
            AccountResponse? accountResponse = await _accountGetterService.GetAccountById(Id);
            if (accountResponse == null) {
                return BadRequest(new
                {
                    status = 400,
                    message = "AccountId not found !"
                });
            }
            return Ok(new
            {
                status = 200,
                data = new {
                    account = accountResponse,
                },
                message = "Data fetched successfully."
            });
        }

        [PermissionAuthorize("A-C")]
        [HttpPost]
        public async Task<IActionResult> Create(AccountAddRequest accountAddRequest)
        {
            try
            {
                AccountResponse account = await _accountAdderService.AddAccount(accountAddRequest);

                return Created("/api/admin/accounts/" + account.Id, new
                {
                    status = 201,
                    data = account,
                    message = "Account created successfully."
                });
            }
            catch (Exception ex) {

                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message
                });
            }
        }

        [PermissionAuthorize("A-U")]
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, AccountUpdateFakeRequest accountAddRequest)
        {
            try
            {
                AccountUpdateRequest accountUpdateRequest = new AccountUpdateRequest()
                {
                    FullName = accountAddRequest.FullName,
                    PhoneNumber = accountAddRequest.PhoneNumber,
                    Email = accountAddRequest.Email,
                    RoleId = accountAddRequest.RoleId,
                    Sex = accountAddRequest.Sex,
                    Status = accountAddRequest.Status,
                    
                };
                AccountUpdatePasswordRequest accountUpdatePassword = new AccountUpdatePasswordRequest()
                {
                    Password = accountAddRequest.Password,
                    RePassword = accountAddRequest.RePassword
                };
                AccountResponse accountResponse = await _accountUpdaterService
                    .UpdateAccount(Id, accountUpdateRequest, accountUpdatePassword);
                return Ok(new
                {
                    status = 200,
                    data = accountResponse,
                    message = "Account updated successfully."
                });
            }
            catch (Exception ex) {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message

                });

            }

        }

        [PermissionAuthorize("A-U")]
        [HttpPatch("ChangePassword/{Id}")]
        public async Task<IActionResult> UpdatePassword(int Id, AccountUpdatePasswordRequest accountUpdateRequest)
        {
            try
            {
                AccountResponse accountResponse = await _accountUpdaterService
                    .UpdatePasswordAccount(Id, accountUpdateRequest);
                return Ok(new
                {
                    status = 200,
                    data = accountResponse,
                    message = "Account updated successfully."
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

        [PermissionAuthorize("A-U")]
        [HttpPatch("{Id}")]
        public async Task<IActionResult> Edit(int Id, AccountUpdatePatchRequest accountUpdateRequest)
        {
            try
            {
                AccountResponse accountResponse = await _accountUpdaterService
                    .UpdateAccountPatch(Id, accountUpdateRequest);
                return Ok(new
                {
                    status = 200,
                    data = accountResponse,
                    message = "Account status updated successfully."
                });
            }
            catch (Exception ex) {

                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message

                });
            }
        }

        [PermissionAuthorize("A-D")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            bool result = await _accountDeleterService.DeleteAccount(Id);
            if (result == false)
            {
                return NotFound(new { 
                    status = 404,
                    message = "Account not found !"
                });
            }
            return Ok(new
            {
                status = 200,
                message = "Delete account success !"
            });
        }
    }
}
