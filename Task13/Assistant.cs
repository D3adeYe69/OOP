
public class Assistant
{
    public string AssistantName { get; set; }
    private List<Display> assignedDisplays;

    public Assistant(string name)
    {
        AssistantName = name;
        assignedDisplays = new List<Display>();
    }

    public void AssignDisplay(Display display)
    {
        assignedDisplays.Add(display);
        Console.WriteLine($"{display.Model} has been assigned to {AssistantName}.");
    }

    public void Assist()
    {
        Console.WriteLine($"\n{AssistantName} is comparing all assigned displays:");
        for (int i = 0; i < assignedDisplays.Count; i++)
        {
            for (int j = i + 1; j < assignedDisplays.Count; j++)
            {
                assignedDisplays[i].CompareWithMonitor(assignedDisplays[j]);
            }
        }
    }

    public void BuyDisplay()
    {
        Console.WriteLine("\nAvailable displays to buy:");
        foreach (var display in assignedDisplays)
        {
            Console.WriteLine($"- {display.Model}");
        }

        Console.Write("\nEnter the model name of the display you want to buy: ");
        string modelName = Console.ReadLine();

        Display displayToBuy = assignedDisplays.Find(d => d.Model.Equals(modelName, StringComparison.OrdinalIgnoreCase));
        if (displayToBuy != null)
        {
            assignedDisplays.Remove(displayToBuy);
            Console.WriteLine($"\n{modelName} has been bought and removed from {AssistantName}'s assigned displays.");
        }
        else
        {
            Console.WriteLine($"{modelName} is not found in {AssistantName}'s assigned displays.");
        }
    }
}
