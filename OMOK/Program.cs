using System;

namespace OMOK
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "OMOK";
            GameManager gameManager = new GameManager();
            GameFlow gameFlow = new GameFlow(gameManager);
            gameFlow.Run();
        }
    }
}
