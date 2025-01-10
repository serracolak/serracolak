
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;
        SnakeGame game = new SnakeGame();
        game.Start();
    }
}

abstract class Snake
{
    protected List<(int X, int Y)> body;
    protected (int X, int Y) direction;
    public int Length => body.Count;
    public (int X, int Y) Head => body[0];
    public List<(int X, int Y)> Body => body;

    protected ConsoleColor color;
    protected int speed;

    public Snake(int startX, int startY, ConsoleColor color, int speed = 100)
    {
        this.color = color;
        this.speed = speed;
        direction = (1, 0);
        body = new List<(int X, int Y)>
        {
            (startX, startY),
            (startX - 1, startY),
            (startX - 2, startY)
        };
    }

    public virtual void Move()
    {
        var newHead = (X: Head.X + direction.X, Y: Head.Y + direction.Y);
        body.Insert(0, newHead);
        body.RemoveAt(body.Count - 1); // Kuyruğu sil
    }

    public void Grow()
    {
        var newHead = (X: Head.X + direction.X, Y: Head.Y + direction.Y);
        body.Insert(0, newHead); // Yeni baş ekle
    }

    public void HandleInput(ConsoleKey key, ConsoleKey up, ConsoleKey down, ConsoleKey left, ConsoleKey right)
    {
        switch (key)
        {
            case var _ when key == up && direction != (0, 1):
                direction = (0, -1);
                break;
            case var _ when key == down && direction != (0, -1):
                direction = (0, 1);
                break;
            case var _ when key == left && direction != (1, 0):
                direction = (-1, 0);
                break;
            case var _ when key == right && direction != (-1, 0):
                direction = (1, 0);
                break;
        }
    }

    public void Draw()
    {
        // Eski kuyruğu sil
        var tail = body.Last();
        Console.SetCursorPosition(tail.X, tail.Y);
        Console.Write(" ");

        // Yeni kafa çiz
        var head = body[0];
        Console.SetCursorPosition(head.X, head.Y);
        Console.ForegroundColor = color;
        Console.Write("■");
        Console.ResetColor();
    }

    public void SpeedUp()
    {
        if (speed > 20) speed -= 5; // Yılan hızlanacak
    }
}

class FastSnake : Snake
{
    public FastSnake(int startX, int startY) : base(startX, startY, ConsoleColor.Green, 80) { }

    public override void Move()
    {
        var newHead = (X: Head.X + direction.X, Y: Head.Y + direction.Y);
        body.Insert(0, newHead);
        body.RemoveAt(body.Count - 1); // Kuyruğu sil
    }
}

class SlowSnake : Snake
{
    public SlowSnake(int startX, int startY) : base(startX, startY, ConsoleColor.Yellow, 150) { }
}

class Food
{
    public (int X, int Y) Position { get; set; }
    public string Type { get; set; }

    public Food((int X, int Y) position, string type)
    {
        Position = position;
        Type = type;
    }
}

class SnakeGame
{
    private const int Width = 80;
    private const int Height = 25;
    private const int WinningLength = 10;

    private Snake snake1;
    private Snake snake2;
    private Food food;
    private List<(int X, int Y)> obstacles;
    private bool isGameOver = false;
    private string winner = "";
    private string player1Name;
    private string player2Name;
    private bool playAgain = false;
    private bool isSinglePlayer = true;
    private int score = 0;
    private int gameSpeed = 150;
    private Stopwatch stopwatch;

    public void Start()
    {
        InitializeGame();
        stopwatch = new Stopwatch();
        stopwatch.Start();

        while (!isGameOver)
        {
            if (stopwatch.ElapsedMilliseconds >= gameSpeed)
            {
                Input();
                Logic();
                Draw();
                stopwatch.Restart();
            }
        }

        GameOver();
    }

    private void InitializeGame()
    {
        Console.Clear();
        Console.WriteLine("Yılan Oyununa Hoş Geldiniz!");
        Console.WriteLine("Lütfen oyun modunu seçin:");
        Console.WriteLine("1. Tek Kişilik");
        Console.WriteLine("2. İki Kişilik");

        string modeSelection;
        do
        {
            Console.Write("Seçiminiz (1/2): ");
            modeSelection = Console.ReadLine();
            if (modeSelection != "1" && modeSelection != "2")
            {
                Console.WriteLine("Geçersiz seçim. Lütfen 1 veya 2 girin.");
            }
        } while (modeSelection != "1" && modeSelection != "2");

        isSinglePlayer = modeSelection == "1";

        Console.Write("Oyuncu 1'in adını girin: ");
        player1Name = Console.ReadLine();

        if (!isSinglePlayer)
        {
            Console.Write("Oyuncu 2'nin adını girin: ");
            player2Name = Console.ReadLine();
        }

        snake1 = new FastSnake(10, Height / 2);
        snake2 = isSinglePlayer ? null : new SlowSnake(Width - 10, Height / 2);
        obstacles = new List<(int, int)>();
        GenerateFood();
        DrawBorders();
        isGameOver = false;
        playAgain = false;
    }

    private void DrawBorders()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;

        for (int x = 0; x < Width; x++)
        {
            Console.SetCursorPosition(x, 0);
            Console.Write("#");
            Console.SetCursorPosition(x, Height - 1);
            Console.Write("#");
        }

        for (int y = 0; y < Height; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write("#");
            Console.SetCursorPosition(Width - 1, y);
            Console.Write("#");
        }

        Console.ResetColor();
    }

    private void Input()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            snake1.HandleInput(key, ConsoleKey.W, ConsoleKey.S, ConsoleKey.A, ConsoleKey.D);

            if (!isSinglePlayer && snake2 != null)
            {
                snake2.HandleInput(key, ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow, ConsoleKey.RightArrow);
            }
        }
    }

    private void Logic()
    {
        snake1.Move();

        if (!isSinglePlayer && snake2 != null)
        {
            snake2.Move();
        }

        if (CheckCollision(snake1.Head) || (!isSinglePlayer && snake2 != null && CheckCollision(snake2.Head)))
        {
            isGameOver = true;
            winner = CheckCollision(snake1.Head) ? (isSinglePlayer ? "Oyun Bitti!" : $"{player2Name} Kazandı!") : $"{player1Name} Kazandı!";
            return;
        }

        if (snake1.Head == food.Position)
        {
            score += 10; // Yılan her yiyeceği yediğinde skor artar
            snake1.Grow();
            snake1.SpeedUp();
            GenerateFood();
        }

        if (!isSinglePlayer && snake2 != null && snake2.Head == food.Position)
        {
            score += 10;
            snake2.Grow();
            snake2.SpeedUp();
            GenerateFood();
        }

        if (snake1.Length >= WinningLength)
        {
            isGameOver = true;
            winner = $"{player1Name} Kazandı!";
        }
        else if (!isSinglePlayer && snake2 != null && snake2.Length >= WinningLength)
        {
            isGameOver = true;
            winner = $"{player2Name} Kazandı!";
        }
    }

    private bool CheckCollision((int X, int Y) head)
    {
        return head.X == 0 || head.X == Width - 1 || head.Y == 0 || head.Y == Height - 1 ||
               snake1.Body.Skip(1).Contains(head) || (!isSinglePlayer && snake2 != null && snake2.Body.Skip(1).Contains(head)) ||
               obstacles.Contains(head);
    }

    private void Draw()
    {
        snake1.Draw();

        if (!isSinglePlayer && snake2 != null)
        {
            snake2.Draw();
        }

        Console.SetCursorPosition(food.Position.X, food.Position.Y);
        Console.ForegroundColor = food.Type == "bomb" ? ConsoleColor.Red : (food.Type == "big" ? ConsoleColor.Blue : ConsoleColor.Green);
        Console.Write(food.Type == "bomb" ? "X" : "■");
        Console.ResetColor();

        Console.SetCursorPosition(0, Height);
        Console.WriteLine($"Skor: {score}  Yılan Boyu: {snake1.Length}");
    }

    private void GenerateFood()
    {
        Random random = new Random();
        string[] types = { "normal", "bomb", "big" };
        string foodType = types[random.Next(0, 3)];
        (int X, int Y) foodPos;

        do
        {
            foodPos = (random.Next(1, Width - 1), random.Next(1, Height - 1));
        } while (snake1.Body.Contains(foodPos) || (!isSinglePlayer && snake2 != null && snake2.Body.Contains(foodPos)));

        food = new Food(foodPos, foodType);
    }

    private void GameOver()
    {
        Console.Clear();
        Console.SetCursorPosition(Width / 2 - 7, Height / 2);
        Console.WriteLine(winner);
        Console.WriteLine($"Skor: {score}");
        Console.WriteLine("Yeniden oynamak ister misiniz? (Evet/Hayır)");
        var response = Console.ReadLine();
        playAgain = response.ToLower() == "evet";
    }

    public bool WantsToPlayAgain() => playAgain;
}
