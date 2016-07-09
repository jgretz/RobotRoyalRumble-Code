#define LED_PIN 13
#define PWM_L 10
#define PWM_R 9
#define DIR_L 8
#define DIR_R 7

void setup()
{
  pinMode(LED_PIN, OUTPUT);
  
  pinMode(PWM_L,  OUTPUT);
  pinMode(PWM_R,  OUTPUT);
  pinMode(DIR_L, OUTPUT);
  pinMode(DIR_R, OUTPUT);
}

void loop()
{
  int speed = 50;
  int sleep = 1000;
  
  digitalWrite(LED_PIN, HIGH); 
  setSpeeds(speed, speed);
  delay(sleep);
 
  digitalWrite(LED_PIN, LOW); 
  setSpeeds(-1 * speed, -1 * speed);
  delay(sleep);
}

void setSpeeds(int left, int right) {
   setSpeed(PWM_L, DIR_L, left);
   setSpeed(PWM_R, DIR_R, right);
}

void setSpeed(int speedPin, int directionPin, int speed) {
  int direction = LOW;
  if (speed < 0) {
    direction = HIGH;
    speed = speed * -1;
  }

  analogWrite(speedPin, speed);
  digitalWrite(directionPin, direction);
}

