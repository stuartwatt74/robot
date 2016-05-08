using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Robot.Controllers;
using Robot.Hubs;
using System.Collections;

[assembly: OwinStartup(typeof(Robot.Startup))]

namespace Robot
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            String root = AppDomain.CurrentDomain.BaseDirectory;
            root = root.Substring(0, root.IndexOf("bin") - 1);

            // Now with a default home page
            var physicalFileSystem = new PhysicalFileSystem(root);
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = physicalFileSystem
            };
            options.StaticFileOptions.FileSystem = physicalFileSystem;
            options.StaticFileOptions.ServeUnknownFileTypes = true;
            options.DefaultFilesOptions.DefaultFileNames = new[] { "index.html" };
            app.UseFileServer(options);

            TestController.Instance.SetHub<DisplayHub>();

            // SignalR
            app.MapSignalR();
        }
    }
}
