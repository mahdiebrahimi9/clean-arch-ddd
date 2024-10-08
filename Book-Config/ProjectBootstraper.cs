﻿using Book_Application.Products.Create;
using Book_Application.Shared;
using Book_Contract;
using Book_Domain.Orders.Repository;
using Book_Domain.Products.Repositorey;
using Book_Domain.UsersAgg.Repository;
using Book_Infrastructre;
using Book_Infrastructre.Persestent.Ef;
using Book_Infrastructre.Persestent.Ef.Orders;
using Book_Infrastructre.Persestent.Ef.Products;
using Book_Infrastructre.Persestent.Ef.Users;
using Book_Queary.Products.GetById;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Book_Config
{
    public class ProjectBootstraper
    {
        public static void Init(IServiceCollection service, string connectionString)
        {
            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<IOrderRepository, OrderRepository>();
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
            service.AddMediatR(typeof(CreateProductCommand).Assembly);
            service.AddMediatR(typeof(GetProductByIdQuery).Assembly);
            service.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);

            service.AddDbContext<BookDbContext>(option
                => option.UseSqlServer(connectionString));

            service.AddScoped<ISmsService, SmsService>();

        }
    }
}
