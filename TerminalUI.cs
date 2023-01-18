namespace AppMongoDB;

internal class TerminalUI : IUI
{
    public void Clear()
    {
        //Not used for now!
    }

    public void Exit()
    {
        System.Environment.Exit(0);
    }

    public string GetInput()
    {
        string? input = Console.ReadLine();
        return input;
    }

    public void Print(string text)
    {
        Console.WriteLine(text);
    }
}
