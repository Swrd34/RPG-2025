namespace RPG
{

class UserInput //Class for getting user input and detecting if input is invalid
    {
        
        public static string GetPlayerInput(string[] validOptions) //System for getting user input
        {
            Console.SetCursorPosition(0, 20);

            string input = string.Empty;
            bool validInput = false;
            bool invCheck = false;

            // Loop until the user provides a valid input
            while (!validInput)
            {
                Console.Write("");
                input = Console.ReadLine() ?? "".Trim();

                if(input == "/inv")
                {
                    invCheck = true;
                    AllDefinitions.player01.PrintInventory();
                }
                
                
                // Check if input is valid by comparing it to valid options
                if (validOptions.Contains(input))
                {
                    validInput = true;
                }

                else if(invCheck == true)
                {
                    invCheck = false;
                }

                else
                {
                    // If the input is invalid, show a message and ask again
                    Console.WriteLine("Invalid choice, please try again.");
                }

            }

            return input;
        }

        public static string GetInputItemFight() // All items
        {
            string playerChoice = GetPlayerInput(new string[]{"/Dammed GreatSword", "/Purified GreatSword"});

            if(playerChoice == "/Dammed GreatSword" && AllDefinitions.player01.Inventory.Contains(AllDefinitions.dammedGreatSword))
            {
                return "DammedGreatSword";
            }

            if(playerChoice == "/Purified GreatSword" && AllDefinitions.player01.Inventory.Contains(AllDefinitions.purifiedGreatSword))
            {
                return "PurifiedGreatSword";
            }

            return null;


        }

        public static void WaitForEnter()
        {
            while (true)
            {
                var startKey = Console.ReadKey(true);
                if (startKey.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }

        public static void WaitForDEL()
        {
            while (true)
            {
                var startKey = Console.ReadKey(true);
                if (startKey.Key == ConsoleKey.Delete)
                {
                    break;
                }
            }
        }
    }
}