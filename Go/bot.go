package main

import (
  "time"

  "github.com/hybridgroup/gobot"
  "github.com/hybridgroup/gobot/platforms/firmata"
  "github.com/hybridgroup/gobot/platforms/gpio"
)

const PWM_L = "10"
const PWM_R = "9"
const DIR_L = "8"
const DIR_R = "7"

func main() {
  gbot := gobot.NewGobot()
  firmataAdaptor := firmata.NewFirmataAdaptor("arduino", "/dev/cu.usbmodem1421")

  leftMotor := newMotor(firmataAdaptor, "left", PWM_L, DIR_L)
  rightMotor := newMotor(firmataAdaptor, "right", PWM_R, DIR_R)

  work := func() {
    speed := byte(50);
    fwd := true

    gobot.Every(1*time.Second, func() {
      if (fwd) {
        leftMotor.Forward(speed)
        rightMotor.Forward(speed)
      } else {
        leftMotor.Backward(speed)
        rightMotor.Backward(speed)
      }

      fwd = !fwd
    })
  }

  robot := gobot.NewRobot("bot",
    []gobot.Connection{firmataAdaptor},
    []gobot.Device{leftMotor,rightMotor},
    work,
  )

  gbot.AddRobot(robot)

  gbot.Start()
}

func newMotor(adapter gpio.DigitalWriter, name string, speedPin string, directionPin string) *gpio.MotorDriver {
  motor := gpio.NewMotorDriver(adapter, name, speedPin)
  motor.DirectionPin = directionPin

  return motor
}
