using NJsonSchema.CodeGeneration;
using NJsonSchema.CodeGeneration.TypeScript;
using NSwag;
using NSwag.CodeGeneration.CSharp;
using NSwag.CodeGeneration.OperationNameGenerators;
using NSwag.CodeGeneration.TypeScript;
using System;

namespace sandbox.Services
{
    public class OpenApiGenerator
    {
        static public async Task<string> GenerateCSharpCode(string specFilePath)
        {
            var document = await OpenApiDocument.FromFileAsync(specFilePath);
            var clientSettings = new CSharpClientGeneratorSettings
            {
                ClassName = "service",
                CSharpGeneratorSettings =
                {
                    Namespace = "sandbox.Generated"
                }
            };

            var clientGenerator = new CSharpClientGenerator(document, clientSettings);
            return clientGenerator.GenerateFile();
        }

        static public async Task<string> GenerateTypescriptCode(string specFilePath)
        {
            var document = await OpenApiDocument.FromFileAsync(specFilePath);
            var clientSettings = new TypeScriptClientGeneratorSettings
            {
                ClassName = "{controller}Client",
                RxJsVersion = 7,
                Template = TypeScriptTemplate.Angular,
                InjectionTokenType = InjectionTokenType.InjectionToken,
                OperationNameGenerator = new MultipleClientsFromFirstTagAndOperationIdGenerator(),

                TypeScriptGeneratorSettings =
                {
                    GenerateCloneMethod = true,
                    MarkOptionalProperties = true,
                }
            };

            var clientGenerator = new TypeScriptClientGenerator(document, clientSettings);
            return clientGenerator.GenerateFile();
        }
    }
}
