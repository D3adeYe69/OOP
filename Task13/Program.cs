using System;
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
    public void CompareSizes(Display m)
    {
        int area1 = this.width * this.height;
        int area2 = m.width * m.height;
        int AreaDifference = Math.Abs(area1 - area2);
        Console.WriteLine($"\nComparing display of {this.model} with {m.model}");
        if (area1 > area2)
            Console.WriteLine($"{this.model} has a  larger  screen  size than {m.model} by {AreaDifference} square pixels");

        else if (area1 < area2)
            Console.WriteLine($"{m.model} has a larger screen size larger than {this.model} by {AreaDifference} square pixels");
        else
            Console.WriteLine($"{this.model} and {m.model} have the same size");
    }

    public void CompareSharpnes(Display m)
    {
        float SharpnesDifference = Math.Abs((float)this.ppi - m.ppi);
        Console.WriteLine($"\nComparing sharpness of {this.model} with {m.model}");
        if (this.ppi > m.ppi)
            Console.WriteLine($"{this.model} is sharper than {m.model} with a difference of {SharpnesDifference}");
        else if (this.ppi < m.ppi)
            Console.WriteLine($"{m.model} is sharper than {this.model} with a difference of {SharpnesDifference}");
        else
            Console.WriteLine($"{this.model} and {m.model} have the same sharpness");

    }
    public void CompareWithMonitor(Display m)
    {
        CompareSizes(m);
        CompareSharpnes(m);
    }


}
class Program
{
    static void Main(string[] args)
    {
        Display d1 = new Display(1920, 1080, 120, "Monitor1");
        Display d2 = new Display(2560, 1440, 150, "Monitor2");
        Display d3 = new Display(3840, 2160, 200, "Monitor3");

        d1.CompareWithMonitor(d2);
        d2.CompareWithMonitor(d3);
        d3.CompareWithMonitor(d1);
    }
}