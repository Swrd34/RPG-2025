namespace RPG
{
class TextDisplayer
    {
        public static void RegSpeed(string text)
        {
            bool enterFlag = false;
            bool textDisplayerDone = false;

            Thread enterKeyThread = new Thread(() =>
            {
                while(!textDisplayerDone)
                {
                
                    if(Console.KeyAvailable)
                    {
                        var keyPress = Console.ReadKey(true);
                        
                        if (keyPress.Key == ConsoleKey.Enter)
                        {
                            enterFlag = true;
                            break; // Exit loop once Enter is detected
                        }

                    }
                
                }
            });
            
            enterKeyThread.Start();

            for(int p = 0; p < text.Length; p++)
            {
                if(enterFlag)
                {
                    Console.WriteLine(text.Substring(p));
                    break;
                }
                Console.Write(text[p]);
                Thread.Sleep(38);
            }
            
            textDisplayerDone = true;

            enterKeyThread.Join();

        }
        
        public static void RegSpeedNoSkip(string text)
        {
            bool enterFlag = false;

            for(int p = 0; p < text.Length; p++)
            {
                if(enterFlag)
                {
                    Console.WriteLine(text.Substring(p));
                    break;
                }
                Console.Write(text[p]);
                Thread.Sleep(38);
            }
            

        }


    }
}