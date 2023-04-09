namespace ProjectTaskManagementSystemLibrary;

public class Generator
{
    private static readonly Random _random = new Random();

    public static int GenerateId()
    {
        return _random.Next(100000, 999999);
    }
}