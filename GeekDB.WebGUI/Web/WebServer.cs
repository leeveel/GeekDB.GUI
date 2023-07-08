using GeekDB.WebGUI.Common;
using GeekDB.WebGUI.Logic;
using GeekDB.WebGUI.Web.Data;
using GeekDB.WebGUI.Web.Service;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using MudBlazor.Services;

namespace GeekDB.WebGUI.Web
{
    public static class WebServer
    {
        static WebApplication app;
        public static Task Start(string webUrl)
        {
            var builder = WebApplication.CreateBuilder(new WebApplicationOptions
            {
                WebRootPath = "Web/wwwroot",
            });

            StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

            // Add services to the container.
            builder.Services.AddRazorPages().WithRazorPagesRoot("/Web/Pages");
            builder.Services.AddServerSideBlazor();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSingleton<DBService>();
            builder.Services.AddSingleton<LoginService>();
            builder.Services.AddSingleton<NodeService>();
            builder.Services.AddScoped<ProtectedSessionStorage>();
            builder.Services.AddScoped<ProtectedLocalStorage>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddMudServices();

            app = builder.Build();

            var provider = app.Services;
            //如果没有默认用户,初始化默认用户
            var dbService = provider.GetRequiredService<DBService>();
            var adminName = Settings.InsAs<CenterSetting>().InitUserName;

            if (dbService.GetData<UserInfo>(adminName) == null)
            {
                dbService.UpdateData(adminName, new UserInfo { Name = adminName, Password = Settings.InsAs<CenterSetting>().InitPassword });
            }

            ServiceManager.NodeService = provider.GetRequiredService<NodeService>();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();

            app.MapFallbackToPage("/_Host");

            app.Urls.Clear();
            var urlList = webUrl.Split(";");
            foreach (var u in urlList)
            {
                app.Urls.Add(u);
            }

            return app.StartAsync();
        }

        public static Task Stop()
        {
            if (app != null)
                return app.StopAsync();
            return Task.CompletedTask;
        }
    }
}
