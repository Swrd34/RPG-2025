namespace RPG
{
    class GraveyardEncounter // Ending (3/?)
    {
        public static void Run()
        {

            Console.Clear();
            TextDisplayer.RegSpeed("You attempt to run, but the skeleton hands keep you in place and stop you from getting away. As you struggle, the undead around you grab ahold and begin eating you alive.\n\n");
            UserInput.WaitForEnter();
            TextDisplayer.RegSpeed("As you scream, the bells toll louder.\n\n");

            UserInput.WaitForEnter();

            Console.WriteLine("\nEnding 3/?: \"Forever Resting Place\"");
            Game.EndGame();
        }

        public static void FightChoices()
        {
            AllDefinitions.player01.Health = 100;
            Random random = new();
            int skeletonnum = random.Next(2, 4);

            for(int i = 0; i < skeletonnum; i++)
            {
                
            }


            
            Console.Clear();
            TextDisplayer.RegSpeed("What do you use?\n");

            AllDefinitions.player01.PrintInventoryItemsFight();

            if (UserInput.GetInputItemFight() == "DammedGreatSword")
            {
                Console.Clear();
                UndeadChurch.FightDammedSword();
            }

            else if (UserInput.GetInputItemFight() == "PurfiedGreatSword")
            {
                Console.Clear();
            }

            else if (UserInput.GetInputItemFight() == null)
            {
                Console.Clear();
                Console.WriteLine("Error has occured.");
            }

            while (UndeadChurch.isAlive)
            {
                Console.Clear();
                TextDisplayer.RegSpeed("What do you use next?\n");
                
                AllDefinitions.player01.PrintInventoryItemsFight();
                
                if (UserInput.GetInputItemFight() == "DammedGreatSword")
                {
                    Console.Clear();
                    UndeadChurch.FightDammedSword();
                }

                else if (UserInput.GetInputItemFight() == "PurfiedGreatSword")
                {
                    Console.Clear();
                }

                else if (UserInput.GetInputItemFight() == null)
                {
                    Console.Clear();
                    Console.WriteLine("Error has occured.");
                }
            }

        }
    }

    class SpiderEncounter // Tweaks needed, Finish Spider Story  
    {

        public static bool timerChecker = true;
        public static int timerCount = 12;





        public static void ApprochingSpider()
        {

            Console.WriteLine("You begin to walk a little faster until Your foot lands on nothing. For a moment, you're weightless, suspended in an impossible stillness as your heart races to catch up. Then you fall.");
            UserInput.WaitForEnter();
            Console.WriteLine("\nYou plummet for some time, until your fall is broken by what feels to be a sticky, springy substance.");
            UserInput.WaitForEnter();
            Console.WriteLine("\nThe cave is deafeningly empty. Behind you echos a fast paste thumbing sound. You dont have much time to make a decison.\n");
            Console.WriteLine("\n\n{1} Struggle\n{2} Stay Still");


            Task.Run(() => CountdownTimer.StartTimerSpider());

            while (SpiderEncounter.timerChecker == true)
            {
                string inputDetect = UserInput.GetPlayerInput(new string[] { "1", "2" });

                if (inputDetect == "1" && SpiderEncounter.timerChecker == true) //Struggle
                {
                    SpiderEncounter.timerChecker = false;
                    Console.Clear();
                    StruggleSpider();
                }

                else if (inputDetect == "2" && SpiderEncounter.timerChecker == true) //Stay Still
                {
                    SpiderEncounter.timerChecker = false;
                    Console.Clear();
                    StayStill();
                }
            }

            if (SpiderEncounter.timerCount <= 0)
            {
                Console.Clear();
                OutOfTime();
            }

        }


        public static void StruggleSpider()
        {
            Console.WriteLine("You twist and turn, struggling to free yourself from the web as the thomping grows louder and closer.. until it reaches you.");
            Console.WriteLine("Your break free, but the spider catches you before you can get away. Its fangs pierce your back and drag you back.");
            Console.WriteLine("You struggle and scream as its leg presses against you, and its fang rips you apart.");
            Console.WriteLine("\nEnding 2/?: \"Spider Munchies\"");
            Console.WriteLine("\n\n\n\n\n\n\nNew game?\n{1} Yes\n{2} No");

            string playerChoice = UserInput.GetPlayerInput(new string[] { "1", "2" });

            if (playerChoice == "1")
            {
                Console.Clear();
                Game.Start();
            }

            if (playerChoice == "2")
            {
                Console.Clear();
                Console.WriteLine("Thanks for playing!");
            }

        }



        public static void StayStill()
        {

        }

        public static void OutOfTime()
        {
            Console.Clear();
            Console.WriteLine("You ran out of time!");
            UserInput.WaitForEnter();
        }
    }

    class BearEncounter // Should be done for now endings (1/?) and (2/?)

    {
        public static void Start()
        {
            TextDisplayer.RegSpeed("You are met with the face of a growling grizzly bear.");
            UserInput.WaitForEnter();
            Console.WriteLine("What is your next move?");
            Console.WriteLine("{1} Run\n{2} Fight\n{3} Play dead");
            string playerChoice = UserInput.GetPlayerInput(new string[] { "1", "2", "3" });
            if (playerChoice == "1")
            {
                Console.Clear();
                HutDayRun();
            }

            if (playerChoice == "2")
            {
                Console.Clear();
                HutDayFight();
            }

            if (playerChoice == "3")
            {
                Console.Clear();
                HutDayPlayDead();
            }
        }

        public static void HutDayRun() // Coward 2/?
        {
            TextDisplayer.RegSpeed("You turn away and attempt to run away from the bear, however your legs are weak and don't make it far.");
            TextDisplayer.RegSpeed("The bear pounces on your back and claws at your flesh. You scream in agony as its jaws crush your legs, arms, and head.");
            UserInput.WaitForEnter();
            Console.WriteLine("\nEnding (2/?): \"Coward\"");

            Game.EndGame();
        }

        public static void HutDayPlayDead()
        {
            TextDisplayer.RegSpeed("As the bear leans in close to sniff you, you drop to the ground and stop breathing. It sniffs you, growls, then steps over you and leaves the hut.");
            TextDisplayer.RegSpeed("You stand up, unharmed, and notice the scene of the hut. Your nose catches the aroma of burnt corpses.");
            TextDisplayer.RegSpeed("\nYou avert you eyes away from the decomposing bodies, and notice a slip of paper on a table in the back of the hut. You grab it and it informs you of the location of great weapon hidden in the villige church.");
            UserInput.WaitForEnter();
            TextDisplayer.RegSpeed("\n\nYou step out of the hut and look to the rest of the village.\n");
            UserInput.WaitForEnter();
            VillageDay.VillageChoices();
        }

        public static void HutDayFight()
        {
            TextDisplayer.RegSpeed("You stare the bear down, and throw a right hook to the bear's face. The bear is breifly stunned by your bravery... then charges at you and knocks you onto your back.");
            TextDisplayer.RegSpeed("As you scramble to get back to your feet, the bear's jaw clamps down on your ankle and drags you further into the hut. ");
            TextDisplayer.RegSpeed("You claw at the ground and kick your legs, but it is no use.");
            TextDisplayer.RegSpeed(" The bear rips your leg off, and begins to claw and scoop at your stomach. This is your first, and final fight.");
            UserInput.WaitForEnter();
            Console.WriteLine("\nEnding (2/?): \"Valiant Bravery\"");
            Game.EndGame();
        }
    }

}