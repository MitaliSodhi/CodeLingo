
//  array_in_memory.cpp  (c) 1997-2002 Kari Laitinen

/*  This is an improved version of array.cpp. This program
    prints the bytes of the array in binary form.  */

#include  <iostream.h>
#include  <iomanip.h>

#include  "useful_functions.h"


int main()
{
   int  array_of_integers[ 50 ] ;
   int  integer_index ;

   array_of_integers[ 0 ]  =  333 ;
   array_of_integers[ 1 ]  =   33 ;
   array_of_integers[ 2 ]  =    3 ;
   array_of_integers[ 3 ]  =  array_of_integers[ 2 ]  +  2 ;

   for ( integer_index  =  4 ;
         integer_index  <  50 ;
         integer_index  ++ )
   {
      array_of_integers[ integer_index ]  =
                array_of_integers[ integer_index - 1 ]  +  2 ;
   }

   cout << "\n The contents of \"array_of_integers\" is:\n" ;

   for ( integer_index  =  0 ;
         integer_index  <  50 ;
         integer_index  ++ )
   {
      if ( ( integer_index  %  10 )  ==  0 )
      {
         cout  <<  "\n" ;
      }

      cout <<  setw( 5 )  <<  array_of_integers[ integer_index ] ;
   }

   char*  byte_in_array  =  (char*) array_of_integers ;

   int  number_of_bytes_printed  =  0 ;

   while ( number_of_bytes_printed  <  16 )
   {
      cout  <<  "\n" ;
      print_binary( *byte_in_array ) ;
      byte_in_array  ++ ;

      number_of_bytes_printed  ++ ;
   }

}


