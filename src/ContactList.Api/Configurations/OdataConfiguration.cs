using ContactList.Core;
using ContactList.Core.Interfaces;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.OData;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System.Reflection;

namespace ContactList.Api.Configurations
{
    public static class OdataConfiguration
    {
        public static void AddOdataSetup(this IServiceCollection services)
        {
            services.AddControllers().AddOData(opt => {
                opt.AddRouteComponents(GetEdmModel()).Expand()
                                                     .Filter()
                                                     .SkipToken()
                                                     .Count()
                                                     .OrderBy()
                                                     .Select()
                                                     .SetMaxTop(100);
                opt.TimeZone = TimeZoneInfo.Local;
            });

            services.AddMvcCore(options =>
            {
                options.OutputFormatters.OfType<OutputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0).ToList().ForEach(outputFormatter =>
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                });

                options.InputFormatters.OfType<InputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0).ToList().ForEach(inputFormatter =>
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                });
            });
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EnableLowerCamelCase();

            var entities = AppDomain.CurrentDomain.GetAssemblies()
                                                  .SelectMany(w => w.GetTypes())
                                                  .Where(w =>
                                                      w.FullName!.Contains("ContactList.Infrastructure.Entities")
                                                      && w.GetInterfaces().Any(w => w.Name.Equals(nameof(IODataEntity)))
                                                      && !w.IsInterface
                                                      && !w.IsAbstract
                                                  )
                                                  .ToList();

            
            entities.ForEach(entity =>
            {
                MethodInfo mi = builder.GetType().GetMethod("EntitySet")!;
                MethodInfo miConstructed = mi.MakeGenericMethod(entity);
                miConstructed.Invoke(builder, new[] { entity.Name });
            });

            return builder.GetEdmModel();
        }
    }
}
