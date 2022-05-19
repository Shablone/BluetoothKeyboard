#include "Keyboard_DE.h"
#include "Mouse.h"
#include <SoftwareSerial.h>
#define SWrx 15
#define SWtx 16
SoftwareSerial bluetooth(SWrx, SWtx); // RX, TX

//todo

//deutscher usb descriptor

//->vb darf keine + schicken
//170 = ignroieren
//vb -> String falls + -> 170 und neu generieren


//Verschlüsselung
int Schluessel[][10] = {{136, 16, 158, 235, 11, 193, 182, 89, 207, 224}, {13, 46, 233, 193, 178, 164, 5, 208, 49, 65}, {84, 59, 62, 229, 192, 38, 178, 188, 189, 234}, {2, 8, 195, 233, 127, 4, 80, 189, 96, 62}, {113, 76, 111, 67, 42, 61, 75, 67, 103, 32}, {196, 143, 93, 222, 39, 93, 36, 182, 192, 9}, {166, 172, 139, 0, 235, 34, 249, 123, 166, 124}, {127, 214, 34, 118, 43, 164, 213, 121, 104, 241}, {54, 118, 218, 84, 157, 236, 216, 5, 222, 95}, {251, 92, 33, 178, 63, 100, 43, 100, 118, 201}};
int Index[] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};



void Log(String str) {
  //Serial.println(str);
}

void setup() {
  //Serial.begin(9600);
  Log("Start");
  pinMode(SWrx, INPUT);
  pinMode(SWtx, OUTPUT);
  bluetooth.begin(9600);
  Mouse.begin();
  Keyboard.begin();
}


int ReadOne() {
  int readChr;
  bool Warten = true;
  while (Warten) {
    if (bluetooth.available() > 0) {
      readChr = bluetooth.read();
      Warten = false;
    } else if (Serial.available() > 0) {
      readChr = Serial.read();
      Warten = false;
    } else {
      delay(1);
    }
  }
  //Log("    " + String(char(readChr)) + " " + String(readChr));
  return readChr;
}

//Input lesen

int ProcessOne(bool enc) {
  int readChr = ReadOne();
  
  //Modulstati kommen unverschlüsselt, Daten kommen verschlüsselt
  //Würde Verschlüselung '+' ergeben, wird es mit 170 ersetzt und neu verschlüsselt

  static int countLeer = 0;
  if (readChr == 170) {
    CountUp();
    countLeer +=1;
    if(countLeer==10){
      newCon();
    }
    readChr = ProcessOne(false);
  } else {
    countLeer = 0;
  }
  //Log("      " + String(readChr));

  if (readChr == '+') {
    //Log("Crop Modul{");
    if (ReadOne() == 'C') {
      while (ReadOne() != 10) {}
      while (ReadOne() != 10) {}
    } else {
      while (ReadOne() != 10) {}
    }
    //Log("}");
    readChr = ProcessOne(false);
  }

  if (enc) { //wenn verschlüsselt und damit relevant
    readChr = decrypt(readChr);
    Log(String(char(readChr)) + " " + String(readChr));
  }  
  return readChr;
}

int newCon(){
  //Log("Setup Index");
  int count = 0;
  int readChr;
  for(int i = 0; i <= 9; i++){
    readChr = ReadOne();
    while(readChr==170){
      readChr = ReadOne();
    }
    Index[i] = readChr;
  }
  //Log("Finished");
}





void Maus() {
  // z.B. MX123345Y12325M
  // oder Mr
  //Log("Maus");
  char First = ProcessOne(true); //"X" oder Mausbutton
  switch (First) {
    case 'l':
      Mouse.press(MOUSE_LEFT);
      return;
    case 'L':
      Mouse.release(MOUSE_LEFT);
      return;
    case 'r':
      Mouse.press(MOUSE_RIGHT);
      return;
    case 'R':
      Mouse.release(MOUSE_RIGHT);
      return;
    case 'm':
      Mouse.press(MOUSE_MIDDLE);
      return;
    case 'M':
      Mouse.release(MOUSE_MIDDLE);
      return;
  }

  char chr3Serial;

  //x Wert:
  String valStr = "";
  while (true) {
    chr3Serial = ProcessOne(true);
    if (chr3Serial == 'Y') {
      break;
    }
    valStr += (char)chr3Serial;
  }

  int X = valStr.toInt();

  //y Wert
  valStr = "";
  while (true) {
    chr3Serial = ProcessOne(true);
    if (chr3Serial == 'M') {
      break;
    }
    valStr += (char)chr3Serial;
  }
  int Y = valStr.toInt();

  Mouse.move(X, Y, 0);

}

void loop() {

  char chrSerial = ProcessOne(true);

    switch ( chrSerial) {
      case 'M': //Maus bewegen
        Maus();
        break;
      case 'S': //String
        SendString();
        break;
      case 'p': //press
        key(0);
        break;
      case 'r': //release
        key(1);
        break;
    }

}

void key(bool action) {
  int chr2Serial = ProcessOne(true);
  if (action == 0) {
    Keyboard.press(chr2Serial);
  } else {
    Keyboard.release(chr2Serial);
  }
}


void SendString() {
  //Log("String");
  String valStr = "";
  while (true) {
    char chrSerial = ProcessOne(true);
    if (chrSerial == 1) {
      break;
    }
    valStr += (char)chrSerial;
  }
  Keyboard.print(valStr);
}





//Verschlüsselung
int decrypt(int val) {
  for (int i = 0; i <= 9; i++) {
    int k = Schluessel[i][Index[i]];
    val = val ^ k;
  }
  CountUp();
  return val;
}

void CountUp() {
  Index[0] += 1;
  for (int i = 0; i <= 8; i++) {
    if (Index[i] == 10) {
      Index[i] = 0;
      Index[i + 1] += 1;
    }
    if (Index[9] == 10) {
      Index[10] = 0;
    }
  }
}
