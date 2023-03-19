using System;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FileStorage.Api.Filters
{
    public class ExcludeNonApiControllersFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            // Exclude non-API controllers from Swagger documentation
            var pathsToRemove = swaggerDoc.Paths.Where(pathItem => !pathItem.Key.StartsWith("/api")).ToList();
            foreach (var path in pathsToRemove)
            {
                swaggerDoc.Paths.Remove(path.Key);
            }
        }
    }
}

