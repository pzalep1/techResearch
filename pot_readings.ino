void setup() {
  Serial.begin(9600);          // Fast Baud rate to reduce lag
}

void loop() {

// Send the Data as a Serial String as follows:
// "pitchtilt, rolltilt \n"
// This String will be read by Python with lines separated by '\n'
int first = map(analogRead(A0), 130, 600, -30, 30);
int second = map(analogRead(A1),300, 530, -30, 30);

   Serial.print(first);                                  
   Serial.print(","); 
   Serial.print(second);
   Serial.println();
   delay(20);
  
  
}
