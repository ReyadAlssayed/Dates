using Dates;
using Dates.Service;
using Supabase;

namespace Dates;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddSingleton<DataService>();
        builder.Services.AddScoped<Radzen.TooltipService>();
        builder.Services.AddScoped<Radzen.DialogService>();          // ✅ إن احتجت حوارات
        builder.Services.AddScoped<Radzen.NotificationService>();     // ✅ مفيدة للأشعارات
        builder.Services.AddScoped<Radzen.ContextMenuService>();      // ✅ في بعض السياقات



#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        // ✅ تسجيل Supabase Client بدون انتظار (بدون Wait)
        builder.Services.AddSingleton<Client>(sp =>
        {
            var url = "https://nckcokoakwstoemxclqb.supabase.co";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im5ja2Nva29ha3dzdG9lbXhjbHFiIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTEzOTUyMzcsImV4cCI6MjA2Njk3MTIzN30.4jAN4QDPSl_VChBnpm6NAI3w6S2ziOF9ADLjPx1NDoQ";

            var client = new Client(url, key, new SupabaseOptions
            {
                AutoConnectRealtime = true
            });

            // لا تنفذ client.InitializeAsync() هنا

            return client;
        });

        return builder.Build();
    }
}
