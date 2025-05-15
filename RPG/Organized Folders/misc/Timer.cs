namespace RPG
{
    class CountdownTimer
    {

        public static void StartTimerSpider()
        {
            while (SpiderEncounter.timerCount > -1 && SpiderEncounter.timerChecker == true)
            {
                Console.SetCursorPosition(0, 7);
                Console.Write($"Time Left: {SpiderEncounter.timerCount} \r");
                Console.SetCursorPosition(0, 20);
                Thread.Sleep(1000);
                SpiderEncounter.timerCount--;
            }
            SpiderEncounter.timerChecker = false;




        }
    }
}