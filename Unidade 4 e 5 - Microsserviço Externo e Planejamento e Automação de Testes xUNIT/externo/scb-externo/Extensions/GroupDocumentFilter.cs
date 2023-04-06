using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace scb_externo.Extensions
{
    // gato para stackar os endpoints no mesmo grupo
    public class GroupDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var info = new List<OpenApiTag> { new OpenApiTag { Name = "Externo", Description = "APIs de comunicação externa do SCB" } };

            foreach (var path in swaggerDoc.Paths)
            {
                foreach (var operation in path.Value.Operations)
                {
                    operation.Value.Tags = info;
                }
            }

            swaggerDoc.Tags = info;
        }
    }
}
