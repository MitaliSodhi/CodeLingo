
//  celsius.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   int  array_of_degrees_fahrenheit[ 40 ] =

   { 32, 34, 36, 37, 39, 41, 43, 45, 46, 48,
     50, 52, 54, 55, 57, 59, 61, 63, 64, 66,
     68, 70, 72, 73, 75, 77, 79, 81, 82, 84,
     86, 88, 90, 91, 93, 95, 97, 99, 100, 102 } ;

   int  degrees_celsius ;

   cout << "\n This program converts temperatures given in"
        << "\n degrees Celsius to degrees Fahrenheit."
        << "\n Please, give a temperature in degrees Celsius:  " ;

   cin  >>  degrees_celsius ;

   cout << "\n "
        <<  degrees_celsius  <<  " degrees Celsius is "
        <<  array_of_degrees_fahrenheit[ degrees_celsius ]
        << " degrees Fahrenheit. \n" ;
}



