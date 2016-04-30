﻿using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PubApp.DataAccess;
using PubApp.DataAccess.Entities;
using System.Web;

namespace PubApp.Web.Infrastructure
{
    public class IdentityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationUserStore>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterType<ApplicationUserManager>()
                .AsSelf()
                .InstancePerRequest();

            builder.Register<IdentityFactoryOptions<ApplicationUserManager>>(c => new IdentityFactoryOptions<ApplicationUserManager>()
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("ApplicationName")
            });

            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication)
                .InstancePerRequest();

            builder.RegisterType<ApplicationOAuthProvider>()
                .AsImplementedInterfaces()
                .WithParameter("publicClientId", "self");

            builder.Register(c => c.Resolve<ApplicationUserManager>()
                .FindById(HttpContext.Current.User.Identity.GetUserId<int>())).As<User>();
        }
    }
}