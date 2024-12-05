namespace API.Dependances
{
    public static class ServicesDependances
    {
        public static void AddServicesDependances(this IServiceCollection services)
        {
            services.AddScoped<IClassificationRepository , ClassificationRepository>();
            services.AddScoped<IMoviesRepository , MoviesRepository>();
            services.AddScoped<IClassificationService , ClassificationService>();
            services.AddScoped<IMoviesService , MoviesService>();
        }
    }
}