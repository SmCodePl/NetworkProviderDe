﻿
using Microsoft.AspNetCore.Mvc;
using NetworkProviderDe.Domain.Entities;
using NetworkProviderDe.Domain.Models;
using NetworkProviderDe.Domain.Services;

namespace NetworkProviderDe.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FiberNetPlanController : ControllerBase
    {
        private readonly ILogger<FiberNetPlanController> _logger;
        private readonly FiberNetService _fiberNetService;

        public FiberNetPlanController(ILogger<FiberNetPlanController> logger, FiberNetService fiberNetService)
        {
            _logger = logger;
            _fiberNetService = fiberNetService;
        }
        // Get
        [HttpGet]
        public async Task<ActionResult<List<FiberNetPlan>>> GetAllNetPlans()
        {
            var result = await _fiberNetService.GetAllNetPlansAsync();

            if (result == null || result.Count == 0)
                return NotFound("No FiberNetPlans found");
            else
                return Ok(result);
        }
        // GET: FiberNetPlanByArea
        [HttpGet("FiberNetPlansByArea")]
        public async Task<ActionResult<List<FiberNetResult>>> GetFiberNetPlan([FromQuery] string postalCode)
        {
            var result = await _fiberNetService.FindByPostalCodeAsync(postalCode);
            
            if (result == null || result.Count == 0)
            {
                return NotFound($"We do not found offered for area: {postalCode}");
            }
            return Ok(result);
        }

    }
}