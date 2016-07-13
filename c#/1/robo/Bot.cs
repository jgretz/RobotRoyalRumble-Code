using Firmata.NET;
using System;

namespace Robo
{
  public class Bot : IDisposable
  {    
    private const int PWM_L = 10;
    private const int PWM_R = 9;
    private const int DIR_L = 8;
    private const int DIR_R = 7;

    private Arduino _arduino;
    

    public void Connect(string portName, int baudRate)
    {
      _arduino = new Arduino(portName, baudRate);

      _arduino.pinMode(PWM_L, Arduino.OUTPUT);
      _arduino.pinMode(PWM_R, Arduino.OUTPUT);
      _arduino.pinMode(DIR_L, Arduino.OUTPUT);
      _arduino.pinMode(DIR_R, Arduino.OUTPUT);
    }

    public void Disconnect()
    {
      _arduino.Close();
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

      _arduino.analogWrite(speedPin, speedPin);
      _arduino.digitalWrite(directionPin, reverse ? Arduino.HIGH : Arduino.LOW);
    }

    public void Dispose()
    {
       Disconnect();
    }
  }
}
