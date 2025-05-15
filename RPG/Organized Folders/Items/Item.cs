namespace RPG
{
    class Item
    {
        public string Name { get; protected set; }
        public int BaseDmg { get; protected set; }

        public Item(string name, int baseDmg)
        {
            Name = name;
            BaseDmg = baseDmg;
        }
    }

}
