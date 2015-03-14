
//  meanvalue.cpp (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   int   integer_from_keyboard     =  0 ;
   int   number_of_integers_given  = -1 ;
   float mean_value                =  0 ;
   int   sum_of_integers           =  0 ;

   cout << "\n This program calculates the mean value of"
        << "\n the integers that you enter from the keyboard."
        << "\n Please, start entering numbers. The program"
        << "\n stops when you enter a zero. \n\n" ;

   do
   {
      cout  <<  "   Enter an integer: " ;
      cin   >>  integer_from_keyboard ;

      number_of_integers_given  ++  ;
      sum_of_integers  =  sum_of_integers + integer_from_keyboard ;
   }
      while  ( integer_from_keyboard  !=  0 ) ;

   if ( number_of_integers_given  >  0 )
   {
      mean_value  =  (float) sum_of_integers /
                     (float) number_of_integers_given ;
   }

   cout << "\n The mean value is: "  <<  mean_value  << "\n" ;
}




