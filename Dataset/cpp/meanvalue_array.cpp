
//  meanvalue_array.cpp (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

#define   ARRAY_SIZE     100

int main()
{
   double  array_of_numbers[ ARRAY_SIZE ] ;
   double  number_from_keyboard  ;
   int     number_index   =  0  ;

   cout <<  "\n This program calculates the mean value of"
        <<  "\n the numbers that you enter from the keyboard."
        <<  "\n The program stops when you enter a letter."
        <<  "\n\n   Enter a number: " ;

   while ( ( cin  >>  number_from_keyboard )  &&
           ( number_index  <  ARRAY_SIZE    )  )
   {
      array_of_numbers[ number_index ]  =  number_from_keyboard ;
      number_index  ++ ;
      cout  <<  "   Enter a number: " ;
   }

   int     number_of_numbers_in_array  =  number_index ;
   double  sum_of_numbers  =  0 ;

   for (  number_index  =  0 ;
          number_index  <  number_of_numbers_in_array ;
          number_index  ++ )
   {
      sum_of_numbers  =  sum_of_numbers  +
                         array_of_numbers[ number_index ] ;
   }

   double  mean_value  =  0 ;

   if ( number_of_numbers_in_array  >  0 )
   {
      mean_value  =  sum_of_numbers /
                     (double) number_of_numbers_in_array ;
   }

   cout  <<  "\n The mean value is: "  <<  mean_value  ;
}




