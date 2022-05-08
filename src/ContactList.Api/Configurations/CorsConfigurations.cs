namespace ContactList.Api.Configurations
{
    public static class CorsConfiguration
    {
        public static void AddCorsSetup(this WebApplication app)
        {
            app.UseCors(options => options
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
            );
        }
    }
}
