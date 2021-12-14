using System;
using Book_My_Table.Areas.Identity.Data;
using Book_My_Table.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Book_My_Table.Areas.Identity.IdentityHostingStartup))]
namespace Book_My_Table.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Book_My_TableContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebApplication1ContextConnection")));

                services.AddDefaultIdentity<Book_My_TableUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Book_My_TableContext>();
            });
        }
    }
}