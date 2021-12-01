using AutoMapper;
using Contracts;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IOrderService> _orderService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager,
        IConfiguration configuration)
        {
            _orderService = new Lazy<IOrderService>(() =>
            new OrderService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationService(logger, mapper, userManager,
            configuration));
        }
        public IOrderService OrderService => _orderService.Value;
        public IAuthenticationService AuthenticationService =>
        _authenticationService.Value;
    }
}
