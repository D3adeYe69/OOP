

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
