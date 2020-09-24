using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;

namespace Delos.Westworld.ParksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphController : ControllerBase
    {
        private readonly GraphServiceClient _graphServiceClient;

        public GraphController(GraphServiceClient graphServiceClient)
        {
            _graphServiceClient = graphServiceClient;
        }

        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            var me = await _graphServiceClient.Me.Request().GetAsync();

            return Ok(new
            {
                me.DisplayName, 
                me.Mail
            });
        }

        [HttpGet("me/photo")]
        public async Task<IActionResult> MyPhoto()
        {
            var photo = await _graphServiceClient.Me.Photo.Content.Request().GetAsync();

            return File(photo, "image/png");
        }

        [HttpGet("me/mail")]
        public async Task<IActionResult> GetTopMailMessages()
        {
            var data = await _graphServiceClient.Me.Messages.Request().Top(2).GetAsync();

            return Ok(data.Select(m => m.Subject));
        }
    }
}
