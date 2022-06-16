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
    public class FriendController : Controller
    {
        private readonly UserDBreactContext _context;

        public FriendController(UserDBreactContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult AddFriend(Chatroom friend)
        {
            int id = _context.Chatroom.Count();


            if (id == 0)
            {
                friend.Id = 0;
            }
            else
            {
                var lastid = _context.Chatroom.OrderByDescending(d => d.Id).FirstOrDefault();
                friend.Id = lastid.Id + 1;
            }
            _context.Chatroom.Add(friend);
            _context.SaveChanges();


            return StatusCode(201);
        }
        [HttpGet("{mid}/{yid}")]
        public IActionResult GetFriend(int mid, int yid)
        {
            var data = _context.Chatroom.FirstOrDefault(d => d.User_1 == mid && d.User_2==yid || d.User_1 ==yid && d.User_2 == mid);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Chatroom>>> GetFriends(int id)
        {

            return await _context.Chatroom
                .Where(x => x.User_1==id||x.User_2==id)
                .ToListAsync();
        }


    }
}
