using MapCreator.Structs;

class Program
{
    static int width = 0;
    static int height = 0;

    static void Main(string[] args)
    {
        bool isRunning = true;

        Console.WriteLine("Enter the map width: ");
        width = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the map heigh: ");
        height = int.Parse(Console.ReadLine());

        Console.SetWindowSize(width, height);

        Console.Clear();
        Vector2 cursorPos = Vector2.Zero;
        char[,] map = new char[width, height];

        while (isRunning)
        {
            EvaluateInput(Console.ReadKey(true).Key, ref cursorPos, ref isRunning, ref map);
        }

        SaveMap(map);
    }

    static void EvaluateInput(ConsoleKey key, ref Vector2 cursorPos, ref bool isRunning, ref char[,] map)
    {
        switch (key)
        {
            case ConsoleKey.LeftArrow:
                cursorPos += Vector2.Left;
                break;
            case ConsoleKey.UpArrow:
                cursorPos += Vector2.Down;
                break;
            case ConsoleKey.RightArrow:
                cursorPos += Vector2.Right;
                break;
            case ConsoleKey.DownArrow:
                cursorPos += Vector2.Up;
                break;
            case ConsoleKey.Escape:
                isRunning = false;
                break;
            case ConsoleKey.Spacebar:
                PrintOnScreen('X', cursorPos, ref map);
                break;
        }

        MoveCursor(ref cursorPos);
    }

    static void MoveCursor(ref Vector2 newPos)
    {
        if (newPos.x < 0) newPos.x = 0;
        else if (newPos.x >= width) newPos.x = width - 1;
        else if (newPos.y < 0) newPos.y = 0;
        else if (newPos.y >= height) newPos.y = height - 1;
        Console.SetCursorPosition(newPos.x, newPos.y);
    }

    static void PrintOnScreen(char sprite, Vector2 pos, ref char[,] map)
    {
        Console.Write(sprite);
        map[pos.x, pos.y] = sprite;
    }

    static void SaveMap(char[,] map)
    {
        string stringMap = "";

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                stringMap += map[x, y];
            }
            stringMap +="\n";
        }

        FileStream fileStream = File.OpenWrite("Map.txt");
        StreamWriter streamWriter = new StreamWriter(fileStream);
        streamWriter.Write(stringMap);
        streamWriter.Close();
        fileStream.Close();
    }
}