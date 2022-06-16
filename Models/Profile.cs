using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace share_login_api.Models
{
    public partial class Profile
    {
        public int Id { get; set; }
        public string Quesion { get; set; }
        public string CorrectAnswer { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string ImageName { get; set; }

        public int User_Id { get; set; }
    }
}
