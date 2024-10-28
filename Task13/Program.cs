
public class Display
{
    private int width;
    private int height;
    private float ppi;
    private string model;

    public Display(int width, int height, float ppi, string model)
    {
        this.width = width;
        this.height = height;
        this.ppi = ppi;
        this.model = model;
    }

    public string Model => model;
    public int Width => width;
    public int Height => height;
    public float Ppi => ppi;

    public void CompareSizes(Display m)
    {
        int area1 = this.width * this.height;
        int area2 = m.width * m.height;
        int areaDifference = Math.Abs(area1 - area2);
        Console.WriteLine($"\nComparing display of {this.model} with {m.model}");
        if (area1 > area2)
            Console.WriteLine($"{this.model} has a larger screen size than {m.model} by {areaDifference} square pixels");
        else if (area1 < area2)
            Console.WriteLine($"{m.model} has a larger screen size than {this.model} by {areaDifference} square pixels");
        else
            Console.WriteLine($"{this.model} and {m.model} have the same size");
    }

    public void CompareSharpness(Display m)
    {
        float sharpnessDifference = Math.Abs(this.ppi - m.ppi);
        Console.WriteLine($"\nComparing sharpness of {this.model} with {m.model}");
        if (this.ppi > m.ppi)
            Console.WriteLine($"{this.model} is sharper than {m.model} with a difference of {sharpnessDifference} ppi");
        else if (this.ppi < m.ppi)
            Console.WriteLine($"{m.model} is sharper than {this.model} with a difference of {sharpnessDifference} ppi");
        else
            Console.WriteLine($"{this.model} and {m.model} have the same sharpness");
    }

    public void CompareWithMonitor(Display m)
    {
        CompareSizes(m);
        CompareSharpness(m);
    }
}

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

class Program
{
    static void Main(string[] args)
    {
        Display d1 = new Display(1920, 1080, 120, "Monitor1");
        Display d2 = new Display(2560, 1440, 150, "Monitor2");
        Display d3 = new Display(3840, 2160, 200, "Monitor3");

        Assistant assistant = new Assistant("Alex");

        assistant.AssignDisplay(d1);
        assistant.AssignDisplay(d2);
        assistant.AssignDisplay(d3);

        assistant.Assist();

        assistant.BuyDisplay();

        assistant.Assist();
    }
}
