using System;
using System.Threading;

namespace Robo
{
  class Program
  {
    const int speed = 50;
    const int sleep = 1000;

    static void Main(string[] args)
    {
      using (var robot = new Bot())
      {
        robot.Connect("COM3", 9600);

        string input = string.Empty;
        while (input == string.Empty)
        {
          robot.SetSpeeds(speed, speed);
          Console.WriteLine("Move Forward");

          Thread.Sleep(sleep);

          robot.SetSpeeds(-1 * speed, -1 * speed);
          Console.WriteLine("Move Back");

          Thread.Sleep(sleep);

          robot.SetSpeeds(0, 0);

          input = Console.ReadLine();
        }
      }
    }
  }
}
