namespace RPG
{
    class Church // Possible NG+ content
    {
        public static bool hasRangChurchBell = false;
        public static bool ominousPresence = false;
        public static bool XXX = false;

        public static void Start()
        {
            TextDisplayer.RegSpeed("You step up to the crumbling church and push the doors open.\n");
            TextDisplayer.RegSpeed("What part of the church do you explore?\n");
            Console.WriteLine("{1} Alter\n{2} Graveyard\n{3} Fountain of Ablution\n{4} Bell Tower\n{5} Leave");

            string playerChoice = UserInput.GetPlayerInput(new string[] { "1", "2", "3", "4", "5" });

            if (playerChoice == "1" && hasRangChurchBell == false) // Going to alter without ringing bell
            {
                AlterNotRung();
            }

            if (playerChoice == "1" && hasRangChurchBell == true) // Going to alter after ringing bell
            {
                if (AllDefinitions.player01.Inventory.Contains(AllDefinitions.dammedGreatSword)) // If player has the dammed sword
                {
                    AlterEmpty();
                }

                else
                {
                    AlterRung();
                }
            }

            if (playerChoice == "2" && !AllDefinitions.player01.Inventory.Contains(AllDefinitions.dammedGreatSword))
            {
                Console.Clear();
                GraveyardDoorLocked();
            }

            if (playerChoice == "2" && AllDefinitions.player01.Inventory.Contains(AllDefinitions.dammedGreatSword) || AllDefinitions.player01.Inventory.Contains(AllDefinitions.purifiedGreatSword))
            {
                GraveyardDoorUnlock();
            }

            if (playerChoice == "3")
            {
                Fountain();
            }

            if (playerChoice == "4")
            {
                ChurchBellTower();
            }

            if (playerChoice == "5" && ominousPresence == false)
            {
                Console.Clear();

                TextDisplayer.RegSpeed("You step out of the church and back out into the village.");
                UserInput.WaitForEnter();

                VillageDay.VillageChoices();
            }

            if (playerChoice == "5" && ominousPresence == true)
            {
                Console.Clear();
                Console.WriteLine("You try to leave but the church doors dont budge. The bell continues to toll.");
                UserInput.WaitForEnter();

                ChurchChoices();
            }




        }

        public static void ChurchChoices()
        {
            Console.Clear();
    
            Console.WriteLine("What part of the church do you explore?");
            Console.WriteLine("{1} Alter\n{2} Graveyard\n{3} Fountain of Ablution\n{4} Bell Tower\n{5} Leave");
               

            string playerChoice = UserInput.GetPlayerInput(new string[] { "1", "2", "3", "4", "5" }); // First input variable

            if (playerChoice == "1" && hasRangChurchBell == false) // Going to alter without ringing bell
            {
                AlterNotRung();
            }

            if (playerChoice == "1" && hasRangChurchBell == true) // Going to alter after ringing bell
            {
                if (AllDefinitions.player01.Inventory.Contains(AllDefinitions.dammedGreatSword) || AllDefinitions.player01.Inventory.Contains(AllDefinitions.purifiedGreatSword))
                {
                    AlterEmpty();
                }

                else
                {
                    AlterRung();
                }
            }

            if (playerChoice == "2")
            {
                Console.Clear();
                GraveyardDoorLocked();
            }

            if (playerChoice == "3")
            {
                Fountain();
            }

            if (playerChoice == "4")
            {
                ChurchBellTower();
            }

            if (playerChoice == "5" && ominousPresence == false)
            {
                Console.Clear();
                TextDisplayer.RegSpeed("You step out of the church and back out into the village.");

                VillageDay.VillageChoices();
            }

            if (playerChoice == "5" && ominousPresence == true)
            {
                Console.Clear();
                TextDisplayer.RegSpeed("You try to leave but the church doors dont budge. The bell continues to toll.");
                UserInput.WaitForEnter();

                ChurchChoices();
            }






        }


        public static void AlterNotRung()
        {
            Console.Clear();

            TextDisplayer.RegSpeed("You approch the alter and notice the sword imbedded within it. You try to release it, but it's no use.\n\n");
            Console.WriteLine("{1} Leave.");

            string playerChoice = UserInput.GetPlayerInput(new string[] { "1" });
            ChurchChoices();
        }

        public static void AlterRung()
        {
            ominousPresence = true;


            Console.Clear();

            TextDisplayer.RegSpeed("You approch the alter and pull at the sword. The alter cracks and hulls as the sword is pulled from its place. The church crumbles and the bell tolls.\n");
            UserInput.WaitForEnter();
            Console.ForegroundColor = ConsoleColor.Yellow;
            AllDefinitions.player01.AddItem(AllDefinitions.dammedGreatSword);
            Console.ResetColor();
            TextDisplayer.RegSpeed("\nYou raise the sword and rest it upon your shoulder. The sword whispers to you.\n\n");
            TextDisplayer.RegSpeed("An ominous presence fills the church.\n\n");
            Console.WriteLine("{1} Leave.");

            string playerChoice = UserInput.GetPlayerInput(new string[] { "1" });


            ChurchChoices();
        }

        public static void AlterEmpty()
        {
            Console.Clear();

            TextDisplayer.RegSpeed("The alter wears an empty slit down it's midsection, from which you hear the whispers of the dammed.\n\n");

            if (!AllDefinitions.player01.Inventory.Contains(AllDefinitions.purifiedGreatSword))
            {
                Console.WriteLine("{1} Leave.");

                string playerChoice = UserInput.GetPlayerInput(new string[] { "1" });

                if (playerChoice == "1")
                {
                    ChurchChoices();
                }
            }

            else if (AllDefinitions.player01.Inventory.Contains(AllDefinitions.purifiedGreatSword) && !XXX)
            {
                XXX = true;
                Console.WriteLine("{1} Insert Purified GreatSword into Alter.\n{2} Leave.");

                string playerChoice = UserInput.GetPlayerInput(new string[] { "1" });

                if (playerChoice == "1" && !Player.XXXXXXX)
                {
                    AllDefinitions.audioPlayerReg.StopAudio();
                    Error.Start();
                    AllDefinitions.audioPlayerReg.StopAudio();
                    AllDefinitions.audioPlayerReg.LoopAudio("Audio/Sounds/churchbells.wav");
                    ChurchChoices();
                }

                if(playerChoice == "2")
                {
                    ChurchChoices();
                }
            }

            if (AllDefinitions.player01.Inventory.Contains(AllDefinitions.purifiedGreatSword) && XXX)
            {
                Console.WriteLine("{1} Leave.");

                string playerChoice = UserInput.GetPlayerInput(new string[] { "1" });

                if (playerChoice == "1")
                {
                    ChurchChoices();
                }
            }
        }

        public static void ChurchBellTower()
        {
            Console.Clear();

            if(hasRangChurchBell)
            {
                TextDisplayer.RegSpeed("The bell continues to toll...\n\n\n");
                Console.WriteLine("{1} Leave.");

                UserInput.GetPlayerInput(new string[]{"1"});

                Church.ChurchChoices();
            }

            else{

            TextDisplayer.RegSpeed("You walk up the church tower stairs and come across the bell. It is cold to the touch.\n\n");
            TextDisplayer.RegSpeed("Ring church bell?\n\n");
            Console.WriteLine("{1} Yes\n{2} No");

            string playerChoice = UserInput.GetPlayerInput(new string[] { "1", "2" }); // First input variable

            if (playerChoice == "1")
            {
                hasRangChurchBell = true;
                Console.Clear();
                AllDefinitions.audioPlayerReg.LoopAudio("Audio/Sounds/churchbells.wav");
                TextDisplayer.RegSpeedNoSkip(".");
                Thread.Sleep(2000);
                TextDisplayer.RegSpeedNoSkip(".");
                Thread.Sleep(2000);
                TextDisplayer.RegSpeedNoSkip(".");
                Thread.Sleep(2000);

                // Play bell noise here (synchronically)

                TextDisplayer.RegSpeed("A heavy object has been loosened...\n\n");
                Console.WriteLine("{1} Leave.");

                string playerChoice2 = UserInput.GetPlayerInput(new string[] { "1" }); // Second input variable

                ChurchChoices();


            }

            if (playerChoice == "2")
            {
                ChurchChoices();
            }
            }
        }

        public static void GraveyardDoorLocked()
        {
            Console.Clear();

            TextDisplayer.RegSpeed("You try the back door of the church, but it's locked and it doesn't budge.\n");
            UserInput.WaitForEnter();
            TextDisplayer.RegSpeed("The chains look worn down, they may be able to be broken.\n\n");

            if (!AllDefinitions.player01.Inventory.Contains(AllDefinitions.dammedGreatSword) && !AllDefinitions.player01.Inventory.Contains(AllDefinitions.purifiedGreatSword))
            {
                Console.WriteLine("{1} Leave.");
                string playerChoice = UserInput.GetPlayerInput(new string[] { "1" });

                ChurchChoices();
            }

            else if (AllDefinitions.player01.Inventory.Contains(AllDefinitions.dammedGreatSword) || AllDefinitions.player01.Inventory.Contains(AllDefinitions.purifiedGreatSword))
            {
                Console.WriteLine("{1} Break lock.\n{2} Leave.");
                string playerChoice = UserInput.GetPlayerInput(new string[] { "1", "2" });

                if (playerChoice == "1")
                {
                    GraveyardDoorUnlock();
                }

                if (playerChoice == "2")
                {
                    ChurchChoices();
                }
            }


        }

        public static void GraveyardDoorUnlock()
        {
            Console.Clear();

            TextDisplayer.RegSpeed("You raise your sword and bring it down apon the chains. They snap and clump to the floor.\n\n");
            UserInput.WaitForEnter();
            TextDisplayer.RegSpeed("You open the door and step through.. as you do the door closes behind you. Before you is the church's graveyard. The sky has darkened and the air is foggy and humid. The bell continues to toll.\n\n");

            Graveyard();


        }

        public static void Graveyard()
        {
            Console.WriteLine("{1} Investigate the graveyard.\n{2} Leave.");

            string playerChoice = UserInput.GetPlayerInput(new string[] { "1", "2" });

            if (playerChoice == "1")
            {
                Console.Clear();

                TextDisplayer.RegSpeed("From the church, you can see a columbarium at the end of the graveyard. You begin to walk towards it.. the fresh soil of the graves mushing beneth your feet.\n\n");
                UserInput.WaitForEnter();
                TextDisplayer.RegSpeed("As you step across a grave, boney fingers grab at your ankle and tug at you. You turn to react, but skeleton arms and hands from graves around you begin\nto rise from their resting place and pull themselves up to the surface of the living.\n\n");
                UserInput.WaitForEnter();
                TextDisplayer.RegSpeed("Before you know it, you are surrounded by decaying corpses. They groan and reach for you. You grasp your sword tighter and get ready to act.\n\n");

                Console.WriteLine("{1} Fight\n{2} Run");

                string playerChoice2 = UserInput.GetPlayerInput(new string[] { "1", "2" });

                if (playerChoice2 == "1")
                {
                    GraveyardEncounter.FightChoices();
                }

                if (playerChoice2 == "2")
                {
                    GraveyardEncounter.Run();
                }

            }

            if (playerChoice == "2")
            {
                Console.Clear();
                TextDisplayer.RegSpeed("You try the door, but it doesn't budge, as if something heavy leans against the other side.\n\n");

                Console.WriteLine("{1} Back.");
                UserInput.GetPlayerInput(new string[] { "1" });
                Console.Clear();
                Graveyard();
            }
        }

        public static void Fountain()
        {
            Console.Clear();

            // If the player doesnT have the dammed sword or has the holy sword
            if (!AllDefinitions.player01.Inventory.Contains(AllDefinitions.dammedGreatSword) || AllDefinitions.player01.Inventory.Contains(AllDefinitions.purifiedGreatSword))
            {
                TextDisplayer.RegSpeed("You have no sins to be cleaned\n\n");

                Console.WriteLine("{1} Leave.");

                string playerChoice = UserInput.GetPlayerInput(new string[] { "1" });

                ChurchChoices();

            }

            // if the player has the dammed sword
            if (AllDefinitions.player01.Inventory.Contains(AllDefinitions.dammedGreatSword))
            {
                TextDisplayer.RegSpeed("You have no sins to be cleaned\n\n");

                Console.WriteLine("{1} Clense Sword.\n{2} Leave.");

                string playerChoice = UserInput.GetPlayerInput(new string[] { "1", "2" });

                if (playerChoice == "1")
                {
                    Console.Clear();

                    AllDefinitions.player01.Removeitem(AllDefinitions.dammedGreatSword);
                    AllDefinitions.player01.AddItem(AllDefinitions.purifiedGreatSword);
                    TextDisplayer.RegSpeed("Your sword has been clensed. It reeks of the language of the godesses and is greatly improved.\n\n");

                    Console.WriteLine("{1} Leave.");

                    string playerChoice2 = UserInput.GetPlayerInput(new string[] { "1" });

                    ChurchChoices();
                }

                if (playerChoice == "2")
                {
                    ChurchChoices();
                }
            }
        }
    }
}