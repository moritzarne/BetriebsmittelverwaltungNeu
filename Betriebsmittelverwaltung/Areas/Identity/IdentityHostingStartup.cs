using System;
using Betriebsmittelverwaltung.Areas.Identity.Data;
using Betriebsmittelverwaltung.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Betriebsmittelverwaltung.Areas.Identity.IdentityHostingStartup))]
namespace Betriebsmittelverwaltung.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                
            });
        }
    }
}