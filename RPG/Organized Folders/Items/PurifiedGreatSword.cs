namespace RPG
{
    class PurifiedGreatSword : Item
    {
        public static int WeaponXp { get; set; } = 0; // Tracks experience for this weapon
        public static int WeaponLvl { get; set; } = 1; // Tracks the level of the weapon
        public string[] WeaponAttacks {get; private set; } = {"Weapon attack 1", "Weapon attack 2 ", "Weapon attack 3"}; 

        public PurifiedGreatSword() : base("Purified GreatSword", 50) // Inherit name and base damage from Weapon
        {}

    }

}
