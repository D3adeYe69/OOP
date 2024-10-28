public class DataProcessor
{
    public static Dictionary<string, List<View>> ProcessAndDisplayData(TraitData traitData)
    {
        // Initialize dictionaries
        var universeClassification = new Dictionary<string, List<View>>();

        foreach (var individual in traitData.input)
        {
            // Output 
            Console.WriteLine($"ID: {individual.id}");
            Console.WriteLine($"Is Humanoid: {individual.isHumanoid}");
            Console.WriteLine($"Planet: {individual.planet}");
            Console.WriteLine($"Age: {individual.age?.ToString() ?? "Indefinite"}");
            Console.WriteLine($"Traits: {string.Join(", ", individual.traits ?? new List<string>())}");

            // Classify 
            Character character = Classifier.ClassifyIndividual(individual);
            string universeName = character?.GetRaceName() ?? "Unknown Universe";
            Console.WriteLine($"Universe: {universeName}");

            // View
            var view = new View
            {
                id = individual.id,
                isHumanoid = individual.isHumanoid,
                planet = individual.planet,
                age = individual.age,
                traits = individual.traits
            };

            if (!universeClassification.ContainsKey(universeName))
            {
                universeClassification[universeName] = new List<View>();
            }
            universeClassification[universeName].Add(view);

            Console.WriteLine(); // For spacing
        }

        return universeClassification;
    }
}
