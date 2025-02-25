using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Grid_Elemendid_Trips_traps_trull
{
    internal class Program : MauiApplication
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
