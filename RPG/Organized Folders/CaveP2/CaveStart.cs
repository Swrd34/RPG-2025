namespace RPG
{
    class CaveDay
    {
        public static void Start()
        {
            Console.WriteLine("Before you stands the entrance to a dark, unsettling cave.");
            Console.WriteLine("Do you enter?");
            Console.WriteLine("{1} Yes\n{2} No");
            string playerChoice = UserInput.GetPlayerInput(new string[] { "1", "2" });

            if (playerChoice == "1")
            {
                Console.Clear();
                WalkedInCave();
            }

            if (playerChoice == "2")
            {
                Console.Clear();
                Console.WriteLine("You left");
                Console.ReadKey();
            }


        }

        public static void WalkedInCave()
        {
            Random caveEvent = new();
            int number = caveEvent.Next(1, 11);

            Console.WriteLine(number);
            if (number < 3)
            {
                Console.WriteLine("You nervously step into the cave. Surroudning you are massive spider webs that cover the walls and celling of the cave.");
                Console.WriteLine("A sudden dread begins to fill you.");
                UserInput.WaitForEnter();
                Console.Clear();
                SpiderEncounter.ApprochingSpider();
            }

            if (number >= 3)
            {
                Console.WriteLine("You nervously step into the cave.");
                UserInput.WaitForEnter();
                Console.Clear();
                CaveSplit();

            }

        }
        public static void CaveSplit()
        {
            Console.WriteLine("Before you is a split in the cave.. the left slightly illuminated.. and the right in complete darkness.");
            UserInput.WaitForEnter();
            Console.WriteLine("Which way do you go?");
            Console.WriteLine("{1} Left\n{2} Right");
            string playerChoice = UserInput.GetPlayerInput(new string[] { "1", "2" });

            if (playerChoice == "1") // Left
            {
                Console.Clear();
                CaveSplitLight.Start();
            }

            if (playerChoice == "2") // Right
            {
                Console.Clear();
                CaveSplitDark.Start();
            }


        }





    }
}

class CaveNight
{
    public static void Start()
    {

    }
}