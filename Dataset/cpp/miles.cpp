
//  miles.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   float  distance_in_miles ;
   float  distance_in_kilometers ;

   cout <<  "\n This program converts miles to kilometers." 
        <<  "\n Please, give a distance in miles:  "  ;

   cin  >>  distance_in_miles ;

   distance_in_kilometers  =  1.6093 * distance_in_miles ;

   cout <<  "\n "  <<  distance_in_miles  <<  " miles is "
        <<  distance_in_kilometers  <<  " kilometers.\n" ;
}


