using System.Formats.Asn1;
using Microsoft.VisualBasic;

namespace RPG
{

    class UndeadChurch
    {
        public static bool isAlive { get; set; } = true; // Flag for checdking if the Skeleton is alive
        public static int Health { get; set; } = 30; // Skeleton health
        private static bool hasHead = true; // Skeleton has head flag
        
        public static void FightDammedSword()
        {
            TakeDamageDGS(DammedGreatSword.Attack());
        }
        
        
        
        
        
        public static void TakeDamageDGS(int damage) // Taking damage method for DammedGreatSword
        {
            Health -= damage; // Subtract damage from healkth

            Random random1 = new(); // High chance for attack 
            int HighChance = random1.Next(1, 11);
            
            Random random2 = new(); // Low chance for attack
            int LowChance = random2.Next(1, 11);


            if (Health <= 0 && !hasHead) // If the Skeleton is dead
            {
                isAlive = false;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                TextDisplayer.RegSpeed("You grip your sword one last time and bring it down the corpse's torso, its body splits with a wet, ripping sound, revealing bloated organs and mangled bones beneath.\n");
                UserInput.WaitForEnter();
                TextDisplayer.RegSpeed("The halfs part and drop to the ground.\n");

                DammedGreatSword.GainWeaponXp(25);

                UserInput.WaitForEnter();
                Console.ResetColor();
                return;
            }

            if (Health <= 0 && hasHead) // If the Skeleton is dead
            {
                isAlive = false;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                TextDisplayer.RegSpeed("You grip your sword one last time and bring it down the corpse's head. It's skull cracks and shatters as you bare the full weight of your blade unto it.\n");
                UserInput.WaitForEnter();
                TextDisplayer.RegSpeed("As you drag the blade further down, its body splits with a wet, ripping sound, revealing bloated organs and mangled bones beneath.\n");
                TextDisplayer.RegSpeed("The halfs part and drop to the ground.\n");

                UserInput.WaitForEnter();
                Console.ResetColor();
                return;
            }
            
            else if (damage == 0) // If player misses or does no damage
            {
                Console.ForegroundColor = ConsoleColor.White;
                TextDisplayer.RegSpeed("\nThe Skeleton stands unharmed.\n");
                UserInput.WaitForEnter();
                Console.ResetColor();

                if(HighChance >= 7 && hasHead) // If attack chance triggers and the skeleton has a head
                {
                    ChompAttack();
                    return;
                }

                if(HighChance >= 7 && !hasHead)
                {
                    ChestCavityAttack();
                    return;
                }
            }
            
            else if (Health <= 10 && hasHead && Health > 0) // if the corpse's health is less than 10 and still has a head
            {
                hasHead = false;
                
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                
                TextDisplayer.RegSpeed("You swing your sword into the corpse's neck. Blood sprays from the opening.\n");
                TextDisplayer.RegSpeed("\nThe corpse's head hangs to the side from its neck, held by a few tendons. It struggles to hold on.\n");
                
                Console.ResetColor();
                
                UserInput.WaitForEnter();

                if(LowChance <= 2) // If attack chance triggers
                {
                    ClawAttack();
                }
                
                return;
            }

            else if(damage > 0 && hasHead) // if the corpse has a head and takes damage
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                
                TextDisplayer.RegSpeed("You drive your sword into the corpse's chest, and retract it.\n");
                TextDisplayer.RegSpeed("\nThe corpse bleeds profusely, but continues to come after you.\n");
                
                Console.ResetColor();
                
                UserInput.WaitForEnter();

                if(LowChance <= 2)
                {
                    ChompAttack();
                    return;
                }
            }

            else if(damage > 0 && !hasHead)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                
                TextDisplayer.RegSpeed("You drive your sword into the corpse's chest, and retract it.\n");
                TextDisplayer.RegSpeed("\nThe corpse bleeds profusely, but continues to come after you.\n");
                
                Console.ResetColor();
                
                UserInput.WaitForEnter();

                if(LowChance <= 2)
                {
                    ChompAttack();
                    return;
                }
            }

        }
        
        
        public static void ChompAttack()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            TextDisplayer.RegSpeed("\nThe rotten corpse grabs at your arm and sinks its teeth into your flesh.\n");
            TextDisplayer.RegSpeed("You wince in pain before prying it off you.");
            UserInput.WaitForEnter();
            Console.ResetColor();
            
            AllDefinitions.player01.Health -= 20;
        }

        public static void ClawAttack()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            TextDisplayer.RegSpeed("The corpse reaches for your face with both hands and stabs its fingers into your temple.\n");
            TextDisplayer.RegSpeed("You flinch in pain. Before kicking the corpse away.");
            TextDisplayer.RegSpeed("The corpse moans and stumbles back.");
            UserInput.WaitForEnter();
            Console.ResetColor();

            AllDefinitions.player01.Health -= 10;

        }

        public static void ChestCavityAttack()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            TextDisplayer.RegSpeed("The headless corpse emits a guttural, wet, gurgling sound from its neck stump, and its chest splits open, revealing jagged ribs and blood soaked tendons.\n");
            TextDisplayer.RegSpeed("The blood from the open cheast cavity sprays onto you, burning your skin.");
            TextDisplayer.RegSpeed("The corpse's shuts its chest, and leans over. Its blood dripping onto the grass.");
            UserInput.WaitForEnter();
            Console.ResetColor();

            AllDefinitions.player01.Health -= 20;


        }

        public static void Reset()
        {
            UndeadChurch.Health = 30;
            UndeadChurch.hasHead = true;
            UndeadChurch.isAlive = true;
        }
    }
}

