using RPG;
namespace RPG
{
class StartUp //Start up ani 

{

    public static void Start()
    {        
        
        Console.ForegroundColor = ConsoleColor.Green;

        AllDefinitions.audioPlayerReg.PlayAudioAsync("Audio/Sounds/bootupV3.wav");   
        Thread.Sleep(500);
        AllDefinitions.audioPlayer.LoopAudioBackgroundSoundPlayer("Audio/Sounds/compwhirl.wav");


        Console.WriteLine("Award Modular BIOS v4.51PG, An Energy Star Ally");
        Thread.Sleep(300);
        Console.WriteLine("Copyright (c) 1999, Award Software, Inc.");
        Thread.Sleep(800);

        Console.WriteLine("(55XWUQ0E) Intel i430VX PCIset(TM)");
        Thread.Sleep(800);

        Console.WriteLine("\nIntel Pentium III at 800 MHz, 1 Processor(s)");
        Thread.Sleep(1000);
        SimulateMemoryTest(64000);
        Thread.Sleep(100);
        Console.WriteLine("\nAward Plug and Play BIOS Extension v1.0A");
        Thread.Sleep(100);
        Console.WriteLine("Copyright (C) 1997, Award Software, Inc");
        Thread.Sleep(500);

        Console.Write("\n   Detecting Floppy Drive A:    ...");
        Thread.Sleep(2000);
        Console.Write(" 3.5\" 1.44MB");

        Console.Write("\n   nChecking NVRAM     ...");
        Thread.Sleep(2500);
        Console.Write(" OK");

        Console.Write("\n   Detecting IDE Primary Master     ...");
        Thread.Sleep(1500);
        Console.Write(" Seagate 10GB HDD");

        Console.Write("\n   Detecting IDE Secondary Master     ...");
        Thread.Sleep(1500);
        Console.Write(" ATAPI CD-ROM");

        Console.Write("\n\nActivating Root Access...");
        Thread.Sleep(500);
        Console.Write(" Failed");



        Console.WriteLine("\n\nFinishing Initilization...");
        Thread.Sleep(3000);






        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nPress DEL to enter SETUP");
        Console.WriteLine("12/05/99-i430VX,UMC8669-2A59Gh2BC-00");


        Thread.Sleep(5000);


        Console.Clear();

        Thread.Sleep(500);
        Console.ForegroundColor = ConsoleColor.White;
        Game.Start();
        
    }


    private static void SimulateMemoryTest(int maxMemory)
    {
        int currentMemory = 0;
        int step = 512;
        int delay = 10;

        while (currentMemory <= maxMemory)
        {
            Console.Write($"\rMemory Test : {currentMemory}K ");
            currentMemory += step;
            Thread.Sleep(delay);
        }

        Console.Write($"\rMemory Test : {maxMemory}K OK\n");
    }
}

class Error //Error sound and flashes
{
    public static void Start()
    {
        
        AllDefinitions.audioPlayerReg.PlayAudioAsync("Audio/Sounds/error.wav");


        for (int i = 0; i < 30; i++) // Change the loop count for how many flashes you want
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear(); // Refreshes the screen to apply the background color

            Thread.Sleep(1); // Waits for 1ms with white background

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear(); // Refreshes the screen to apply the background color

            Thread.Sleep(1); // Waits for 1ms with black background
        }

        AllDefinitions.audioPlayerReg.StopAudio();
        // Reset console colors after flashing
        Console.ResetColor();

        
    }
}
}
