using System;
using System.IO;

class Program
{
    static void Main()
    {
        string baseDir = AppContext.BaseDirectory;

        var inputFile = Path.Combine(baseDir, "..", "..", "..", "resources", "input.json");

        TraitData traitData = JsonReader.ReadJson(inputFile);

        var universeClassification = DataProcessor.ProcessAndDisplayData(traitData);

        FileWriter.WriteOutputToFiles(universeClassification);
    }
}
