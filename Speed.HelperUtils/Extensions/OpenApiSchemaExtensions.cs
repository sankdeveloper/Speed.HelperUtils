using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;

namespace Clover.Core.WebAPI.CustomPluginService.Extensions;

public static class OpenApiSchemaExtensions
{
    public static async Task<string> ReadAsJsonStringAsync(this OpenApiSchema? openApiSchema)
    {
        if (openApiSchema is null)
            return string.Empty;

        await using var fileStream = new MemoryStream();
        await using var writer = new StreamWriter(fileStream);
        var writerSetting = new OpenApiWriterSettings() { InlineLocalReferences = true, InlineExternalReferences = true };

        openApiSchema.SerializeAsV2WithoutReference(new OpenApiJsonWriter(writer, writerSetting));
        await writer.FlushAsync();

        return Encoding.UTF8.GetString(fileStream.ToArray());
    }
}
