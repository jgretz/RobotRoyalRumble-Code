#include <Encoder.h>
#include <PID_v1.h>
#include <BricktronicsMotor.h>

#include <Wire.h>
#include <Adafruit_MCP23017.h>
#include <BricktronicsShield.h>

BricktronicsMotor m1(BricktronicsShield::MOTOR_1);
BricktronicsMotor m2(BricktronicsShield::MOTOR_2);

void setup()
{
  // Be sure to set your serial console to 115200 baud
  Serial.begin(115200);

  BricktronicsShield::begin();

  // Initialize the motor connections
  m1.begin();
  m2.begin();
}

// To use PID control with multiple motors, we need to call the
// update() function for all motors periodically, so we can't just
// use the built-in goTo{Position,Angle}WaitFor*() functions.
// The easiest way is to make a super-update function that calls all
// the motors' update() functions at once.
void updateMotors()
{
    // Call all motors' update() functions.
    // If you add more motors or call them by different names,
    // be sure to update this function!
    m1.update();
    m2.update();
}

// we can also create a function similar to the single motor's delayUpdateMS
void delayUpdateMotors(uint32_t delayMS)
{
    unsigned long endTime = millis() + delayMS;
    while( millis() < endTime )
    {
        updateMotors();
    }
}

void loop()
{
//    Serial.print("Sending motors to +/- 180 ticks = +/- 90 degrees...");
//    m1.goToPosition(180);
//    m2.goToPosition(-180);
//    delayUpdateMotors(2000);
//    Serial.println("done");
//
//    // If you want to wait until both motors have reached a position:
//    m1.goToPosition(360);
//    m2.goToPosition(-720);
//    Serial.print("Waiting until m1 is at 360 and m2 is at -720...");
//    // If you want to wait until either motor arrives, change && to || below:
//    while( !m1.settledAtPosition(360) && !m2.settledAtPosition(-720) )
//    {
//        updateMotors();
//    }
//    Serial.println("done");
//    delayUpdateMotors(2000);
}
