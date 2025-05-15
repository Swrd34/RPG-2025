namespace RPG
{
    class Player
    {  
        public static bool isParanoid;
        public int amountOfItems;
        public int Health;
        public int timesPlayed;
        public static bool XXXXXXX = false;


        public List<Item> Inventory { get; private set; }

        public Player()
        {
            Inventory = new List<Item>();
        }

        public void Removeitem(Item item)
        {
            AllDefinitions.player01.amountOfItems--;

            if(Inventory.Contains(item))
            {
                Inventory.Remove(item);
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{item.Name} is not in inventory.");
                Console.ResetColor();
            }
        }
        
        
        
        
        public void AddItem(Item item)
        {
            AllDefinitions.player01.amountOfItems++;
            
            if (!Inventory.Contains(item))
            {
                Inventory.Add(item);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{item.Name} added to inventory.");
                Console.ResetColor();
            }
            
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{item.Name} is already in the inventory.");
                Console.ResetColor();
            }

        }

        public void PrintInventory() // Add to as more items are added
        {
            Console.WriteLine("\n\n\n\n"); //Slop :(
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            if (Inventory.Count == 0)
            {
                Console.WriteLine("No items in inventory.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("Items in inventory:");
            
            foreach (var item in Inventory)
            {
                Console.WriteLine($"- {item.Name}");
            }

            Console.WriteLine("\n\n\n\nFor more info, type item name. {/Example Item}\n{1} Exit");
            Console.ResetColor();

            string playerChoice = UserInput.GetPlayerInput(new string[]{"1", "/Dammed GreatSword", "/Purified GreatSword"});

            if(playerChoice == "1")
            {
                Console.WriteLine("\n\n\n\n\n\n\n\n\n");
            }

            if(playerChoice == "/Dammed GreatSword" && AllDefinitions.player01.Inventory.Contains(AllDefinitions.dammedGreatSword))    
            {
                DammedGreatSword.Info();
            }

            if(playerChoice == "/Purified GreatSword" && AllDefinitions.player01.Inventory.Contains(AllDefinitions.dammedGreatSword))
            {
                Console.WriteLine("Purified GreatSword info here");
            }

            
            Console.ResetColor();
        }

        public void PrintInventoryItemsFight() // Add to as more items are added
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            if (Inventory.Count == 0)
            {
                Console.WriteLine("No items in inventory.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("Items in inventory:");
            
            foreach (var item in Inventory)
            {
                Console.WriteLine($"- {item.Name}");
            }

            Console.WriteLine("\n\n\n\nTo select an item, type item name. {/Example Item}");
            
            Console.ResetColor();
        }


    }

}
