using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeCore.Service.Identity
{
    /// <summary>
    /// Essential payload for the user 
    /// </summary>
    public class AppUser
    {
        //essential properties that should be found in any AppUser class
        //Using IdentityUser proprties

        /// <summary>
        /// This represents the Id of the User in Guid but parsed into string
        /// </summary>
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
