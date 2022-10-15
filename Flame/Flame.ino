#include <FastLED.h>

#define LED_PIN     11
#define COLOR_ORDER RGB
#define CHIPSET     WS2811
#define NUM_LEDS    50

#define TRIGGER_PIN 3
#define HIGH_PIN 6
#define FADETIME 500

int BRIGHTNESS=200;
int FRAMES_PER_SECOND=800;

bool gReverseDirection = false;

CRGB leds[NUM_LEDS];

void setup() {  
  randomSeed(analogRead(A0)*analogRead(A1));
  pinMode(TRIGGER_PIN,INPUT_PULLUP);
  digitalWrite(TRIGGER_PIN,1);
  pinMode(HIGH_PIN,OUTPUT);
  digitalWrite(HIGH_PIN,1);
  //attachInterrupt(digitalPinToInterrupt(TRIGGER_PIN),ir,CHANGE);   
  FastLED.addLeds<CHIPSET, LED_PIN, COLOR_ORDER>(leds, NUM_LEDS).setCorrection( TypicalLEDStrip );
  FastLED.setBrightness( BRIGHTNESS );
}

CRGB randomColor(){  
  CRGB Colors[] = {CRGB(255,20,0),CRGB(255,40,0),CRGB(255,60,0),CRGB(255,80,0),CRGB(226,99,16),CRGB(255,0,0)};  
  int i = random(0,5);
  return Colors[i];
}


void clear(){
  for(int i=0; i<NUM_LEDS; i++){
    leds[i] = CRGB(0,0,0);
  }
  FastLED.show();
}

void ir(){
  while(digitalRead(TRIGGER_PIN)==0){
     FireRed();  
     FastLED.show();
  }
  clear();
}

float intensity=1;
int fadeCount=0;

int legs[][6] = {
   {7,  8,  9,  10, 11, 12},
   {43, 44, 45, 56, 47, 48},
   {5,   4,  3,  2,  1,  0},
   {40, 39, 38, 37, 36, 35},
   {17, 16, 15, 14, 13, 12},
   {29, 30, 31, 32, 33, 34},
   {18, 19, 20, 21, 22, 23},
   {28, 27, 26, 25, 24, 23}
};

void randomLeg(){  
  int leg = random(0,7);  
  for(int i=0; i<6; i++){
    leds[legs[leg][i]]=randomColor();
    FastLED.show();
    delay(20);
    leds[legs[leg][i]]=CRGB(0,0,0);    
  }
  clear();
  randomDelay(500,1000); 
}

void startupSequence(){  
  for(int i=0; i<6; i++){
    for(int leg=0;leg<8;leg++){
      leds[legs[leg][i]]=randomColor();        
    }
    FastLED.show();
    delay(50);   
  }
}
void shutdownSequence(){  
  leds[49]=CRGB(0,0,0);
  for(int i=5; i>=0; i--){
    for(int leg=0;leg<8;leg++){
      leds[legs[leg][i]]=CRGB(0,0,0);
    }
    FastLED.show();
    delay(100);   
  }
}

void randomBlinks(){   
    int i = random(0,49);  
    leds[i] = randomColor();
    FastLED.show();
    randomDelay(50,100);
    leds[i] = CRGB(0,0,0);  
    FastLED.show();
    randomDelay(50,1000); 
}

bool startupDone=false;
bool shutdownDone=false;
void loop()
{       
  if(digitalRead(TRIGGER_PIN)==1){
    if(!shutdownDone){
      shutdownSequence();
      shutdownDone=true;
    }
    clear();
    randomLeg(); 
    startupDone=false;    
  } else {
    if(!startupDone){
      startupSequence();
      startupDone=true;
    }
    FireRed();
    shutdownDone=false;
    FastLED.show();
  }
  
}

void randomDelay(int a, int b){
  int m = random(b);
  int i=a;
  while(i<b && digitalRead(TRIGGER_PIN)==1){
    i++;
    delay(1);
  }  
}


// Fire2012 by Mark Kriegsman, July 2012
// as part of "Five Elements" shown here: http://youtu.be/knWiGsmgycY
//// 
// This basic one-dimensional 'fire' simulation works roughly as follows:
// There's a underlying array of 'heat' cells, that model the temperature
// at each point along the line.  Every cycle through the simulation, 
// four steps are performed:
//  1) All cells cool down a little bit, losing heat to the air
//  2) The heat from each cell drifts 'up' and diffuses a little
//  3) Sometimes randomly new 'sparks' of heat are added at the bottom
//  4) The heat from each cell is rendered as a color into the leds array
//     The heat-to-color mapping uses a black-body radiation approximation.
//
// Temperature is in arbitrary units from 0 (cold black) to 255 (white hot).
//
// This simulation scales it self a bit depending on NUM_LEDS; it should look
// "OK" on anywhere from 20 to 100 LEDs without too much tweaking. 
//
// I recommend running this simulation at anywhere from 30-100 frames per second,
// meaning an interframe delay of about 10-35 milliseconds.
//
// Looks best on a high-density LED setup (60+ pixels/meter).
//
//
// There are two main parameters you can play with to control the look and
// feel of your fire: COOLING (used in step 1 above), and SPARKING (used
// in step 3 above).
//
// COOLING: How much does the air cool as it rises?
// Less cooling = taller flames.  More cooling = shorter flames.
// Default 50, suggested range 20-100 
#define COOLING  55

// SPARKING: What chance (out of 255) is there that a new spark will be lit?
// Higher chance = more roaring fire.  Lower chance = more flickery fire.
// Default 120, suggested range 50-200.
#define SPARKING 120

void RandomBlinks(){
  for( int i = 0; i < NUM_LEDS; i++) {
     leds[i]= CRGB::Blue;
  }  
}

void FireRed()
{
// Array of temperature readings at each simulation cell
  static uint8_t heat[NUM_LEDS];

  // Step 1.  Cool down every cell a little
    for( int i = 0; i < NUM_LEDS; i++) {
      heat[i] = qsub8( heat[i],  random8(0, ((COOLING * 10) / NUM_LEDS) + 2));
    }
  
    // Step 2.  Heat from each cell drifts 'up' and diffuses a little
    for( int k= NUM_LEDS - 1; k >= 2; k--) {
      heat[k] = (heat[k - 1] + heat[k - 2] + heat[k - 2] ) / 3;
    }
    
    // Step 3.  Randomly ignite new 'sparks' of heat near the bottom
    if( random8() < SPARKING ) {
      int y = random8(7);
      heat[y] = qadd8( heat[y], random8(160,255) );
    }

    // Step 4.  Map from heat cells to LED colors
    for( int j = 0; j < NUM_LEDS; j++) {       
      CRGB color = HeatColor( heat[j]);
      color.r = color.r * intensity;
      color.g = color.g * intensity;
      color.b = color.b * intensity;
      int pixelnumber;
      if( gReverseDirection ) {
        pixelnumber = (NUM_LEDS-1) - j;
      } else {
        pixelnumber = j;
      }
      leds[pixelnumber] = color;
    }
}
