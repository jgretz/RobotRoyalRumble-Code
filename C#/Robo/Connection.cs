using System;
using System.IO.Ports;

namespace Robo
{
  public class Connection
  {
    public enum WriteMethod
    {
      Analog = 0,
      Digital = 1
    }
    
    private const byte MESSAGE = 16;

    private readonly string _portName;
    private readonly int _baudRate;

    private SerialPort _port;

    public Connection(string portName, int baudRate)
    {
      _portName = portName;
      _baudRate = baudRate;
    }

    public bool IsConnected { get; set; }

    public void Connect()
    {
      _port = new SerialPort(_portName, _baudRate);
      _port.Open();

      if (_port.IsOpen)
      {
        IsConnected = true;
        Console.WriteLine("Connected");
      }
    }

    public void Disconnect()
    {
      _port.Close();

      IsConnected = false;
      Console.WriteLine("Disconnected");
    }

    public void Write(WriteMethod method, int pin, int value)
    {
      var message = new byte[] { MESSAGE, (byte) method, (byte) pin, (byte) value };

      _port.Write(message, 0, message.Length);
    }
  }
}
