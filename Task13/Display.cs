
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
