namespace RPG
{

    class BeginingForestScene // First scene/North or South Forest
    {

        public static void Start() // Start of Forest
        {
            Random forest = new(); // Night or day spawn
            int number = forest.Next(1, 1); //Temp only Day

            if (number == 1) // Day
            {
                TextDisplayer.RegSpeed("You awake in a forest during the day. You are surrounded by tress and nature.");
                TextDisplayer.RegSpeed("\nWhere do you wish to go?\n\n");
                Console.WriteLine("{1} North\n{2} South?");
            }


            if (number == 2) // Night
            {
                TextDisplayer.RegSpeed("You awake in a forest at night. You are surrounded by tress and nature.");
                TextDisplayer.RegSpeed("Do you wish to go north {1} or south {2}?");
            }



            string playerChoice = UserInput.GetPlayerInput(new string[] { "1", "2" }); // Gets input
            if (playerChoice == "1" && number == 1) // Player goes north during the day
            {
                Console.Clear();
                TextDisplayer.RegSpeed("You head North... ");
                Thread.Sleep(1000);
                VillageDay.Start();
            }

            if (playerChoice == "2" && number == 1) // Player goes south during the day
            {
                Console.Clear();
                TextDisplayer.RegSpeed("You head South... ");
                Thread.Sleep(1000);
                CaveDay.Start();
            }

            if (playerChoice == "1" && number == 2) // Player goes north during the night
            {
                Console.Clear();
                Console.Write("You head North...");
                CaveNight.Start();
            }

            if (playerChoice == "2" && number == 2) // Player goes south during the night
            {
                Console.Clear();
                Console.Write("You head South...");
                CaveNight.Start();
            }
        }
    }
}