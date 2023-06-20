using Newtonsoft.Json.Schema;

namespace HandsOnTests.Utils;

public static class SchemaUtils
{
    public static JSchema ObterSchemaAsync(this string nomeArquivo)
    {
        string folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "//Cenarios//";
        var file = folder + $"{nomeArquivo}.json";

        using StreamReader r = new(file);
        string json = r.ReadToEnd();

        JSchema schema = JSchema.Parse(json);

        return schema;
    }
}

