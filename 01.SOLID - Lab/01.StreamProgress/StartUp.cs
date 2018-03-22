using System;

namespace P01.Stream_Progress
{
    public class StartUp
    {
        public static void Main()
        {   
            var musicStream = new StreamProgressInfo(new Music("Cardi B", "B", 342, 2000));
            var fileStream = new StreamProgressInfo(new File("someFile.txt", 290, 3000));
            Console.WriteLine(musicStream.CalculateCurrentPercent());
            Console.WriteLine(fileStream.CalculateCurrentPercent());
        }
    }
}
