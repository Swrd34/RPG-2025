using System.Diagnostics;
using NAudio.Wave.Asio;

namespace RPG
{
    class DammedGreatSword : Item
    {
        public static int WeaponDmg { get; set; } = 10; // Base Weapon Damage
        public static int WeaponXp { get; set; } = 0; // Tracks experience for this weapon
        public static int WeaponLvl { get; set; } = 1; // Tracks the level of the weapon
        public static string itemType = "GreatSword";
        public static int attacksAvailable = 0; // Default attacks available
        public static int Weaponboost { get; set; } = 5;

        public DammedGreatSword() : base("Dammed GreatSword", 5) // Inherit name and base damage from Weapon
        { }

        public static void GainWeaponXp(int amount) // Gives the weapon xp
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            WeaponXp += amount;
            Console.WriteLine($"The Dammed GreatSword gained {amount} XP!\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            LevelUp();
            Console.ResetColor();
        }

        public static void Info() // Info on the weapon for inv
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\n\n\"Dammed GreatSword\"\n");
            Console.WriteLine($"Item Type: {DammedGreatSword.itemType}\n");
            Console.WriteLine("Item Desc: An Unholy GreatSword forged over a millennia ago. It whispers to you.\n");

            Console.ResetColor();
        }


        private static void LevelUp() // Levling system for Weapon
        {
            if (WeaponXp >= 100 * WeaponLvl) // if the Weapon xp is more than 100 * the current weapon level
            {
                WeaponXp -= 100 * WeaponLvl; // Reset Weapon xp
                WeaponLvl++; // Increase Level
                WeaponDmg += 5;
                
                Console.WriteLine($"The Dammed GreatSword leveled up! It is now Lvl {WeaponLvl}.\n"); // Level up text
            }
        }

        public static int Attack()
        {
            Random number = new(); // RNG for weapon attack chance
            int attackChance = number.Next(1, 11); // 
            string attackMiss = "You swing and miss, stumbling at the weight of the sword.";

            Random number2 = new();
            int boost = number2.Next(1, 4);

            if (attackChance >= 3 && boost == 3)
            {
                Console.Clear();
                int boostDmg = WeaponDmg * WeaponLvl;

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                TextDisplayer.RegSpeed("As you raise your sword, you focus on the whispers emitting from it. They guide your movements an enhance your attack.\n");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                
                int damage = WeaponDmg + boostDmg;

                UserInput.WaitForEnter();

                return damage;
            }

            else if (attackChance >= 3)
            {
                Console.Clear();

                int damage = WeaponDmg;

                return damage;
            }



            if (attackChance < 3)
            {
                Console.Clear();
                
                TextDisplayer.RegSpeed(attackMiss);
                
                return 0;
            }

            else
            {
                return 0;
            }




        }




    }

}
