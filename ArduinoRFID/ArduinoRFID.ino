#include <SPI.h>
#include <MFRC522.h>
#include <Adafruit_SSD1306.h>
#include <Adafruit_GFX.h>

#define SCREEN_W 128
#define SCREEN_H 64

#define SS_PIN 10
#define RST_PIN 9

MFRC522 mfrc522(SS_PIN, RST_PIN);
Adafruit_SSD1306 display(SCREEN_W, SCREEN_H, &Wire, -1);

void setup()
{
    Serial.begin(9600);
    SPI.begin();
    display.begin(SSD1306_SWITCHCAPVCC, 0x3C);
    mfrc522.PCD_Init();
    display.clearDisplay();
}

void loop()
{

    if (mfrc522.PICC_IsNewCardPresent())
    {
        byte uid[4];
        getID(uid);
        if (uid != -1)
        {
            for (int i = 0; i < 4; i++)
            {
                Serial.print(uid[i]);
                Serial.print(" ");
            }
            Serial.println();
        }
    }
    if (!mfrc522.PICC_ReadCardSerial())
    {
        return;
    }
}

void getID(byte idArray[4])
{
    if (!mfrc522.PICC_ReadCardSerial())
    {
        idArray[0] = {0};
        idArray[1] = {0};
        idArray[2] = {0};
        idArray[3] = {0};
    }
    idArray[0] = mfrc522.uid.uidByte[0];
    idArray[1] = mfrc522.uid.uidByte[1];
    idArray[2] = mfrc522.uid.uidByte[2];
    idArray[3] = mfrc522.uid.uidByte[3];
    mfrc522.PICC_HaltA();
}