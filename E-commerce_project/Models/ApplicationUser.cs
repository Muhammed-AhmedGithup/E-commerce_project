using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_project.Models
{
	public class ApplicationUser:IdentityUser
	{
		[Display(Name ="Full name")]
        public string  Full_name{ get; set; }
    }
}
