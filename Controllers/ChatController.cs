using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using share_login_api.Models;
using System.Collections;

namespace share_login_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : Controller
    {
        private readonly UserDBreactContext _context;

        public ChatController(UserDBreactContext context) {
            _context = context;
        }

        [HttpPost]
        public ActionResult AddMessage(Message message)
        {
            int id = _context.Message.Count();
            

            if (id == 0)
            {
                message.Id = 0;
            }
            else
            {
                var lastid = _context.Message.OrderByDescending(d => d.Id).FirstOrDefault();
                message.Id = lastid.Id + 1;
            }
            _context.Message.Add(message);
            _context.SaveChanges();


            return StatusCode(201);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable>> GetMessageAsync(int id)
        {
            return await _context.Message
            .Where(x => x.ChatroomId == id)
            .Select(x => new Message()
            {
                Id = x.Id,
                ChatroomId = x.ChatroomId,
                Content = x.Content,
                UserId = x.UserId


             })
         .ToListAsync();


        }


    }
}
