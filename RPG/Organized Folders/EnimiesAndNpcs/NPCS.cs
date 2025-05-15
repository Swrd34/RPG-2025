namespace RPG
{
    class MrLegsNpc
    {
        public static bool ifNpcTalk = false;

        public static void Start()
        {
            Console.Clear();

            Console.Write("???: ");

            TextDisplayer.RegSpeedNoSkip("\"Ngh..");
            Thread.Sleep(400);

            TextDisplayer.RegSpeedNoSkip("please..");
            Thread.Sleep(400);

            TextDisplayer.RegSpeedNoSkip("help me...\"");
            UserInput.WaitForEnter();

            TextDisplayer.RegSpeed("\nBefore you is a tall pale man in burnt garnments, sitting on the floor against the wall of the hut.\nThe skin on his legs is falling off, and charred. He speaks to you in a shakey, hesitant tone.\n\n");

            UserInput.WaitForEnter();

            Console.Write("???: ");

            TextDisplayer.RegSpeedNoSkip("\"You there..");
            Thread.Sleep(400);
            TextDisplayer.RegSpeedNoSkip("please..");
            Thread.Sleep(400);
            TextDisplayer.RegSpeedNoSkip("dont leave me here...\"\n\n");
            Thread.Sleep(400);
            UserInput.WaitForEnter();
            MrLegsMainMenu();



        }


        public static void MrLegsMainMenu()
        {
            Console.WriteLine("{1} What happened to you?\n{2} Where are the town's poeple?\n{3} Leave.");
            string playerChoice = UserInput.GetPlayerInput(new string[] { "1", "2", "3" });
            if (playerChoice == "1")
            {
                ifNpcTalk = true;
                Console.Clear();
                MrLegsMenu1();
            }

            if (playerChoice == "2")
            {
                Console.Clear();
                Console.WriteLine("Villiger: \"Dead.. I was the only one able to get away.. it all happened so fast...\"");
                Console.WriteLine("{1} Back.");
                UserInput.GetPlayerInput(new string[] { "1" });
                Console.Clear();
                MrLegsMainMenu();
            }

            if (playerChoice == "3" && ifNpcTalk == false)
            {
                Console.Clear();
                TextDisplayer.RegSpeed("You leave the hut.");
                UserInput.WaitForEnter();
                VillageDay.VillageChoices();

            }

            if (playerChoice == "3" && ifNpcTalk == true)
            {
                Console.Clear();
                TextDisplayer.RegSpeed("As you turn away and step outside of the hut, you hear the injured villiger speak his last words..");
                UserInput.WaitForEnter();
                TextDisplayer.RegSpeed("\n\nVilliger: \"Inside the church.. within the alter.. lies the key.. to defeating the dragon...\"");
                UserInput.WaitForEnter();
                VillageDay.VillageChoices();
            }


        }

        public static void MrLegsMenu1()
        {
            Console.WriteLine("Villiger: We were attacked.. by a dragon.. there was so much fire...");
            Console.WriteLine("\n\n{1} Where did the dragon go?\n{2} Where did the dragon come from?\n{3} Back.");
            string playerChoice = UserInput.GetPlayerInput(new string[] { "1", "2", "3" });

            if (playerChoice == "1")
            {
                Console.Clear();
                MrLegsMenu1_1();
            }

            if (playerChoice == "2")
            {
                Console.Clear();
                MrLegsMenu1_2();
            }

            if (playerChoice == "3")
            {
                Console.Clear();
                MrLegsMainMenu();
            }


        }

        public static void MrLegsMenu1_1()
        {
            Console.Clear();
            Console.WriteLine("Villiger: \"I'm.. not sure.. there was too much chaos.. I hid in here untill it flew away.\"");
            Console.WriteLine("{1} Back.");
            UserInput.GetPlayerInput(new string[] { "1" });
            Console.Clear();
            MrLegsMenu1();
        }

        public static void MrLegsMenu1_2()
        {
            Console.Clear();
            Console.WriteLine("Villiger: \"There are rumors.. but.. no one is sure.. of its true origins.\"");
            Console.WriteLine("{1} Back.");
            UserInput.GetPlayerInput(new string[] { "1" });
            Console.Clear();
            MrLegsMenu1();

        }
    }

    class MinerNpc
    {

    }
}