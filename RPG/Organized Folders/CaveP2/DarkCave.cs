namespace RPG
{
    class CaveSplitDark // finish ending
    {   
        public static void Start()
        {
            Console.WriteLine("You decide for a moment, then turn right.");
            Console.WriteLine("You walk for some time.. it feels like hours.. unitl you hear something in front of you.. deep in the heart of the cave...");
            UserInput.WaitForEnter();
            Console.WriteLine("???: \"Closer...\"");
            UserInput.WaitForEnter();
            Console.WriteLine("Turn back?");
            Console.WriteLine("{1} Yes\n{2} No");
            string playerChoice = UserInput.GetPlayerInput(new string[]{"1", "2"});

            if(playerChoice == "1")
            {
                Console.Clear();
                Error.Start();
                DarkDark();
            }

            if(playerChoice == "2")
            {
                Console.Clear();
                DarkDark();
            }
            
    
        }




        public static void DarkDark()
        {
            Console.WriteLine("You know what is good for you, and follow the whispers.");
            UserInput.WaitForEnter();
            Console.WriteLine("They become louder, more incoherent, more enticing");
            UserInput.WaitForEnter();
            Console.WriteLine("The voice has what you need.");
            UserInput.WaitForEnter();

            Console.WriteLine("It will save you, accept it into your life");
            UserInput.WaitForEnter();
            DarkDarkGod();
            
        }


        public static void DarkDarkGod()
        {
            
            Console.WriteLine("{1} Devote yourself to Him\n{2} Defy God ");
            string playerChoice = UserInput.GetPlayerInput(new string[]{"1" , "2"});

            if(playerChoice == "1")
            {
                Console.WriteLine("computer shutdown here");
            }

            if(playerChoice == "2")
            {
                Console.Clear();
                Error.Start();
                DarkDarkGod();
            }
        }
    }

}