#define LED_PIN 13
#define PWM_L 10
#define PWM_R 9
#define DIR_L 8
#define DIR_R 7

byte inputByte_0; // signal 
byte inputByte_1; // type (0 = analog, 1 = digital)
byte inputByte_2; // pin
byte inputByte_3; // value

void setup()
{
  Serial.begin(9600);
  
  pinMode(LED_PIN, OUTPUT);
  
  pinMode(PWM_L,  OUTPUT);
  pinMode(PWM_R,  OUTPUT);
  pinMode(DIR_L, OUTPUT);
  pinMode(DIR_R, OUTPUT);
}

// Main Loop
void loop() {
  // Read Buffer
  if (Serial.available() >= 4) 
  {
    //Read buffer
    inputByte_0 = Serial.read();
    inputByte_1 = Serial.read();
    inputByte_2 = Serial.read();
    inputByte_3 = Serial.read();
  }
  
  // Check for start of write message
  if (inputByte_0 != 16)
  {
    return;
  }
  
  switch (inputByte_1) {
    case 0:
      analogWrite(inputByte_2, inputByte_3);
      break;

    case 1:
      digitalWrite(inputByte_2, inputByte_3);
      break;
  }
  
  // Clear Message bytes
  inputByte_0 = 0;
  inputByte_1 = 0;
  inputByte_2 = 0;
  inputByte_3 = 0;
}
