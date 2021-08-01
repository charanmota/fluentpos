using System.Threading.Tasks;
using FluentPOS.Shared.Core.Constants;
using FluentPOS.Shared.Core.Interfaces.Services;
using FluentPOS.Shared.DTOs.Identity.EventLogs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FluentPOS.Modules.Identity.Controllers
{
    [ApiVersion("1")]
    internal sealed class EventLogsController : BaseController
    {
        private readonly IEventLogService _eventLog;

        public EventLogsController(IEventLogService eventLog)
        {
            _eventLog = eventLog;
        }

        [HttpGet]
        [Authorize(Policy = Permissions.EventLogs.ViewAll)]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginatedEventLogsFilter filter)
        {
            var request = Mapper.Map<GetEventLogsRequest>(filter);
            var eventLogs = await _eventLog.GetAllAsync(request);
            return Ok(eventLogs);
        }
    }
}