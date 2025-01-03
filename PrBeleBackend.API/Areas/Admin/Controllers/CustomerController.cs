﻿using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.DTO.CustomerDTOs;
using PrBeleBackend.Core.Enums;
using PrBeleBackend.Core.ServiceContracts.CustomerContracts;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerGetterService _customerGetterService;
        private readonly ICustomerSorterService _customerSorterService;
        private readonly ICustomerUpdaterService _customerUpdaterService;
        private readonly ICustomerDeleterService _customerDeleterService;
        public CustomerController(
            ICustomerGetterService customerGetterService,
            ICustomerSorterService customerSorterService,
            ICustomerUpdaterService customerUpdaterService,
            ICustomerDeleterService customerDeleterService
            )
        {
            _customerGetterService = customerGetterService;
            _customerSorterService = customerSorterService;
            _customerUpdaterService = customerUpdaterService;
            _customerDeleterService = customerDeleterService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(
            string? field,
            string? query,
            int? status,
            string? sort,
            SortOrderOptions? order = SortOrderOptions.ASC,
            int page = 1,
            int limit = 10
            )
        {
            List<CustomerResponse> allCustomers = await _customerGetterService.GetAllCustomer();

            allCustomers = allCustomers
                .Where(a => status == 0 || status == 1 ? a.Status == status : true)
                .ToList();

            int totalCustomer = allCustomers.Count;

            List<CustomerResponse> customers = await _customerGetterService.GetFilteredCustomer(field, query);

            List<CustomerResponse> paginaCustomer = customers
                .Where(a => status == 0 || status == 1 ? a.Status == status : true)
                .Skip(limit * (page - 1)).Take(limit).ToList();

            List<CustomerResponse> sortedCustomer = await _customerSorterService.SortCustomers(paginaCustomer, sort, order.ToString());

            return Ok(new
            {
                status = 200,
                data = new
                {
                    accounts = sortedCustomer,
                    pagination = new
                    {
                        currentPage = page,
                        totalPages = totalCustomer / limit,
                        totalRecords = totalCustomer
                    }
                },
                message = "Data fetched successfully."

            });
        }
        [HttpPatch("{Id}")]
        public async Task<IActionResult> Edit(int Id, CustomerUpdatePatchRequest customerUpdateRequest)
        {
            try
            {
                CustomerResponse customerResponse = await _customerUpdaterService
                    .UpdateCustomerPatch(Id, customerUpdateRequest);
                return Ok(new
                {
                    status = 200,
                    data = customerResponse,
                    message = "Customer status updated successfully."
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
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            bool result = await _customerDeleterService.DeleteCustomer(Id);
            if (result == false)
            {
                return NotFound(new
                {
                    status = 404,
                    message = "Customer not found !"
                });
            }
            return Ok(new
            {
                status = 200,
                message = "Delete Customer success !"
            });
        }
    }
}
