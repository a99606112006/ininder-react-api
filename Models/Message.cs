using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace share_login_api.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public int ChatroomId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime? PostTime { get; set; }
    }
}
