using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IOrderService OrderService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
