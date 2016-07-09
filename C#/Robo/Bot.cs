using System;
using static Robo.Connection;

namespace Robo
{
  public class Bot : IDisposable
  {
    private const int HIGH = 1;
    private const int LOW = 0;
    
    private const int PWM_L = 10;
    private const int PWM_R = 9;
    private const int DIR_L = 8;
    private const int DIR_R = 7;

    private Connection _connection;
    

    public void Connect(string portName, int baudRate)
    {
      _connection = new Connection(portName, baudRate);
      _connection.Connect();
    }

    public void Disconnect()
    {
      _connection.Disconnect();
    }

    public void SetSpeeds(int leftSpeed, int rightSpeed)
    {
      SetLeftSpeed(leftSpeed);
      SetRightSpeed(rightSpeed);
    }
 
    public void SetLeftSpeed(int speed)
    {
      SetSpeed(PWM_R, DIR_R, speed);
    }

    public void SetRightSpeed(int speed)
    {
      SetSpeed(PWM_L, DIR_L, speed);
    }

    private void SetSpeed(int speedPin, int directionPin, int speed)
    {
      bool reverse = speed < 0;
      speed = Math.Abs(speed);

      _connection.Write(WriteMethod.Analog, speedPin, speed);
      _connection.Write(WriteMethod.Digital, directionPin, reverse ? HIGH : LOW);
    }

    public void Dispose()
    {
      if (_connection.IsConnected)
      {
        Disconnect();
      }
    }
  }
}
