using System;
using System.Threading;

namespace Robo
{
  class Program
  {
    static void Main(string[] args)
    {
      using (var robot = new Bot())
      {
        robot.Connect("COM3", 9600);

        string input = string.Empty;
        while (input == string.Empty)
        {
          robot.SetSpeeds(100, 100);
          Console.WriteLine("Move Forward");

          Thread.Sleep(500);

          robot.SetSpeeds(-100, -100);
          Console.WriteLine("Move Back");

          Thread.Sleep(500);

          robot.SetSpeeds(0, 0);

          input = Console.ReadLine();
        }
      }
    }
  }
}
