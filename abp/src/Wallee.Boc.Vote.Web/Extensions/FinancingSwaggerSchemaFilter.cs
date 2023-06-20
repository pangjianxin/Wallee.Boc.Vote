using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace Wallee.Boc.Vote.Web.Extensions
{
    public class FinancingSwaggerSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                var array = new OpenApiArray();
                array.AddRange(Enum.GetNames(context.Type).Select(n => new OpenApiString(n)));
                // Openapi-generator
                schema.Extensions.Add("x-enum-varnames", array);
            }
        }
    }
}
