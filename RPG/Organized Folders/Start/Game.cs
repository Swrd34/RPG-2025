namespace RPG
{
    public class Game // Start and end game
    {

        public static void Start()
        {
            Console.Clear();
            TextDisplayer.RegSpeed("Welcome to RPG! In this game, you will make choices that will change the course of the story. Good luck!");
            Console.WriteLine("/inv at any time to view your inventory.");
            UserInput.WaitForEnter();
            Console.Clear();
            Thread.Sleep(1200);
            BeginingForestScene.Start();
        }

        public static void EndGame()
        {
            Console.WriteLine("\n\n\n\n\n\n\nNew game?\n{1} Yes\n{2} No");
            string playerChoice = UserInput.GetPlayerInput(new string[] { "1", "2", });
            
            if (playerChoice == "1")
            {
                Console.Clear();
                BeginingForestScene.Start();
            }

            else
            {
                Console.Clear();
                TextDisplayer.RegSpeed("Thanks for playing!");
            }
        
        }
    }

}
