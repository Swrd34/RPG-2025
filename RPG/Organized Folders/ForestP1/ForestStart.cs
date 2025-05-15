using RPG;
namespace RPG
{


class VillageDay
{
    public static void Start()
    {
        Random hutChance = new();
        int number = hutChance.Next(1, 101);
        TextDisplayer.RegSpeed("You come across a village. It is abandonded, destroyed, covered in debris and smothering in flames.\n");
        TextDisplayer.RegSpeed("From one of the burning huts, you hear strange noises.\n");
        UserInput.WaitForEnter();
        Console.WriteLine("Do you wish to investigate?\n{1} Yes\n{2} No");

        string playerChoice = UserInput.GetPlayerInput(new string[] { "1", "2" });


        if (playerChoice == "1" && number <= 20)
        {
            Console.Clear();
            TextDisplayer.RegSpeed("You step towards the hut, and push open the door...\n");
            Thread.Sleep(1000);
            BearEncounter.Start(); // Ha, goodluck.
        }

        if (playerChoice == "1" && number > 21)
        {
            Console.Clear();
            TextDisplayer.RegSpeed("You step towards the hut, and push open the door...\n");
            Thread.Sleep(1000);
            MrLegsNpc.Start();
        }

        if (playerChoice == "2") // Wuss
        {
            TextDisplayer.RegSpeed("You decide to not investigate the strange noises and look to the rest of the village.\n");
            UserInput.WaitForEnter();
            VillageChoices();
        }
    }

    public static void VillageChoices() // Village Main Menu
    {
        Console.Clear();
        TextDisplayer.RegSpeed("Before you is the rest of the village. The air is rich of burning wood. Most of the buildings are falling apart.");
        Console.WriteLine("\nWhere do you go?\n{1} Church\n{2} Town Well\n{3} Blacksmith Hut\n{4} Tavern\n{5} Leave village.");
        string playerChoice = UserInput.GetPlayerInput(new string[] { "1", "2", "3", "4", "5" });

        if (playerChoice == "1") // Church
        {
            Console.Clear();
            Church.Start();
        }

        if (playerChoice == "2") // Town Well
        {
            Console.Clear();

        }

        if (playerChoice == "3") //Blacksmith Hutt
        {
            Console.Clear();

        }

        if (playerChoice == "4") // Tavern
        {
            Console.Clear();

        }

        if (playerChoice == "5") // Leave
        {

        }
    }

}

class VillageNight
    {
        public static void Start()
        {

        }
    }
















}