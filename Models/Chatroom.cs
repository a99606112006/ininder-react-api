using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace share_login_api.Models
{
    public partial class Chatroom
    {
        public int Id { get; set; }
        public int User_1 { get; set; }
        public int User_2 { get; set; }
    }
}
