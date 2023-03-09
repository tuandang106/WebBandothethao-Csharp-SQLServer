using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Models
{
    public class UserMasterData
    {
        [Required(ErrorMessage = "Bắt buộc")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Bắt buộc")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Bắt buộc")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Bắt buộc")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bắt buộc")]
        public string Password { get; set; }
        
        public Nullable<bool> IsAdmin { get; set; }

        public Nullable<bool> Sex { get; set; }
    }
}