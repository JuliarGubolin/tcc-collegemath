using CollegeMath.Application.Applications;
using CollegeMath.Application.Interfaces;
using CollegeMath.Infra.Interfaces;
using CollegeMath.Infra.Repositories;

namespace CollegeMath.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            //Indicando ao c# por quem a interface está sendo implementada
            //"Sempre que eu pedir uma IContentApplication me devolva sua implementação no ContentRepository"
            services.AddHttpContextAccessor();
            services.AddScoped<IEmailApplication, EmailApplication>();
            services.AddScoped<IContentApplication, ContentApplication>();
            services.AddScoped<IContentRepository, ContentRepository>();
            services.AddScoped<ILevelApplication, LevelApplication>();
            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<IQuestionApplication, QuestionApplication>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IAlternativeApplication, AlternativeApplication>();
            services.AddScoped<IAlternativeRepository, AlternativeRepository>();
            services.AddScoped<IImageQuestionApplication, ImageQuestionApplication>();
            services.AddScoped<IImageQuestionRepository, ImageQuestionRepository>();
            services.AddScoped<ISolutionApplication, SolutionApplication>();
            services.AddScoped<ISolutionRepository, SolutionRepository>();
            services.AddScoped<IImageSolutionApplication, ImageSolutionApplication>();
            services.AddScoped<IImageSolutionRepository, ImageSolutionRepository>();
            services.AddScoped<IUserQuestionHistoryApplication, UserQuestionHistoryApplication>();
            services.AddScoped<IUserQuestionHistoryRepository, UserQuestionHistoryRepository>();
            return services;
        }
        }
}
