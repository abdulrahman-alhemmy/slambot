/**
* File: ServoController.ino
*
* Declares some basic servo functionality, built upon the 
* servo example that came with the arduino IDE.
*
* The servo object can be rotated to a given angle, based on
* on the parameters passed to rotate it will either wait for
* the servo to reach its position or continue on.
*
* Reset simply returns the servo to 0 degrees with or without
* waiting for it, again based on the parameters passed.
*
* NOTE: This file cannot be included until the boolean error
* is resolved...
*
* @author Joshua Michael Daly
* @version 27/10/2013
*/

#include <Servo.h>

/*
* Create servo object to control a servo a maximum of eight 
* servo objects can be created.
*/
Servo servo;
 
int servoPostion = 0; // Variable to store the servo position. 

/************************************************************
* Servo Functions
************************************************************/

/**
* Resets the servo to 0 degrees.
*/ 
void reset();

/**
* Resets the servo to 0 degrees optionally waiting for the 
* servo to reach its position.
*
* @param wait  if true the function will not return until the
*              servo has reached 0 degrees.
*/
void reset(boolean wait);

/**
* Rotates the servo to the angle specified without waiting for
* the servo to reach it.
*
* @param angle  position to move the servo to
*/
void rotate(unsigned short angle);

/**
* Rotates the servo to the angle specified optionally waiting for
* the servo to reach its position.
*
* @param angle  position to move the servo to
* @param wait   if true the function will not return until the
*               servo has reached angle.
*/
void rotate(unsigned short angle, boolean wait);




