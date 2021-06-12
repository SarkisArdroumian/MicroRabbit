﻿using MediatR;
using Microrabbit.Banking.Data.Context;
using Microrabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Events;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();
         
            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TranfserCommandHandler>();

            //Application  Services
            services.AddTransient<IAccountService, AccountService>();
           

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            
            services.AddTransient<BankingDbContext>();
            
        }

        public static void RegisterServices1(IServiceCollection services)
        {
            //Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            //Domain Events
            services.AddTransient<IEventHandler<MicroRabbit.Transfer.Domain.Events.TransferCreatedEvent>, TransferEventHandler>();

            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TranfserCommandHandler>();

            //Application  Services
           
            services.AddTransient<ITransferService, TransferService>();

            //Data
           
            services.AddTransient<ITransferRepository, TransferRepository>();
           
            services.AddTransient<TransferDbContext>();
        }
    }
}
