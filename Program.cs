using Game.Class.Manager;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();

            gameManager.Run();
        }
    }
}
