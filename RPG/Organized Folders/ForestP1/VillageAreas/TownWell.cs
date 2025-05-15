namespace RPG
{
    class TownWell
    {
        private static Random pushChance = new();
        public static bool looked = false;
        public static int number = pushChance.Next(1, 11); 

        
        public static void Start()
        {
            if(looked == true)
            {
                Console.WriteLine("You have already looked in the well.");
                Console.WriteLine("{1} Leave.");

                string playerChoice = UserInput.GetPlayerInput(new string[]{"1"});

                VillageDay.VillageChoices();

            }
        }
    }
}