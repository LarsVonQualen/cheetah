using System;

namespace Cheetah.Security.Interfaces.Models
{
    public interface IUser
    {
        Guid UserId { get; set; }
        string Username { get; set; }
    }
}