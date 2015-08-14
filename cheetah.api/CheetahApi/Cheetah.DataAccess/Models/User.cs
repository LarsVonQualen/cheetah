using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace Cheetah.DataAccess.Models
{
    public partial class User : IUser
    {
        public string Id
        {
            get { return UserId.ToString(); }
            set { UserId = Guid.Parse(value); }            
        }

        public ICollection<ExternalLogin> ExternalLogins { get; set; }
    }
}