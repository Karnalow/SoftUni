namespace MyFirstWebApplication
{
    public class StartUp
    {
        public void ConfigureServices(IServiceCollection services)
        { 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapGet("/ivan", async context =>
                {
                    await context.Response.WriteAsync("Hello Ivan!");
                });
            });
        }
    }
}
