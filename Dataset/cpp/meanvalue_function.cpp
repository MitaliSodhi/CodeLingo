
//  meanvalue_function.cpp (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

#define   ARRAY_SIZE     100

void read_array_of_numbers( double array_of_numbers[],
                            int&   number_of_numbers_in_array )
{
   int      number_index  =  0  ;
   double   number_from_keyboard   ;

   cout  <<  "   Enter a number: " ;

   while ( ( cin  >>  number_from_keyboard )  &&
           ( number_index  <  ARRAY_SIZE    )  )
   {
      array_of_numbers[ number_index ]  =  number_from_keyboard ;
      number_index  ++ ;
      cout  <<  "   Enter a number: " ;
   }

   number_of_numbers_in_array  =  number_index ;
}


void calculate_mean_value( double array_of_numbers[],
                           int    number_of_numbers_in_array,

                            double& calculated_mean_value )
{
   double  sum_of_numbers   =  0  ;

   for ( int number_index  =  0 ;
             number_index  <  number_of_numbers_in_array ;
             number_index  ++ )
   {
      sum_of_numbers  =  sum_of_numbers  +
                          array_of_numbers[ number_index ] ;
   }

   if ( number_of_numbers_in_array  >  0 )
   {
      calculated_mean_value  = (double) sum_of_numbers /
                               (double) number_of_numbers_in_array ;
   }
   else
   {
      calculated_mean_value  =  0 ;
   }
}

int main()
{
   double  array_of_numbers[ ARRAY_SIZE ] ;
   int     number_of_numbers_read ;
   double  mean_value ;

   cout << "\n This program calculates the mean value of"
        << "\n the numbers that you enter from the keyboard."
        << "\n The program stops when you enter a letter. \n\n" ;

   read_array_of_numbers( array_of_numbers,
                          number_of_numbers_read ) ;

   calculate_mean_value( array_of_numbers,
                         number_of_numbers_read,

                         mean_value ) ;

   cout  <<  "\n The mean value is: "  <<  mean_value  ;
}




