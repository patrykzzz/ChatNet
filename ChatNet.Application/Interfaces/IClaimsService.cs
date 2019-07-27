using System;

namespace ChatNet.Application.Interfaces
{
    public interface IClaimsService
    {   
        Guid GetCurrentUserId();
    }
}
