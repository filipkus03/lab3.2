using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace lab3.Areas.Identity.Data;

// Add profile data for application users by adding properties to the lab3User class
public class lab3User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

