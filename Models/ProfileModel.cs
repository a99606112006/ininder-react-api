using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace share_login_api.Models
{
    public class ProfileModel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        public string Quesion { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string CorrectAnswer { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string Answer2 { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string Answer3 { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string Answer4 { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; }

        [Column(TypeName = "int")]
        public int User_id { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }

    }
}
