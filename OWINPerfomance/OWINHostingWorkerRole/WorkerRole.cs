using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.Owin.Hosting;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
//using Microsoft.WindowsAzure.Storage;

namespace OWINHostingWorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        private IDisposable app;

        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.TraceInformation("OWINHostingWorkerRole entry point called", "Information");

            while (true)
            {
                Thread.Sleep(10000);
                Trace.TraceInformation("Working", "Information");
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            var endPoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["WorkerIn"];
            
            app = WebApp.Start<Startup>(string.Format("{0}://{1}", endPoint.Protocol, endPoint.IPEndpoint));

            return base.OnStart();
        }

        public override void OnStop()
        {
            app.Dispose();
            base.OnStop();
        }
    }
}
