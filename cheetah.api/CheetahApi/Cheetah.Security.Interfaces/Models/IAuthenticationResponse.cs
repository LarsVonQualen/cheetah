using System.Collections.Generic;

namespace Cheetah.Security.Interfaces.Models
{
    public interface IAuthenticationResponse
    {
        bool IsValid { get; set; }
        //ICollection<string> Roles { get; set; }  
    }
}