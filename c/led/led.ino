#define LED_PIN 13

void setup()
{
  pinMode(LED_PIN, OUTPUT);
}

void loop()
{ 
  int sleep = 1000;
  
  digitalWrite(LED_PIN, HIGH); 
  delay(sleep);
 
  digitalWrite(LED_PIN, LOW);
  delay(sleep);
}

