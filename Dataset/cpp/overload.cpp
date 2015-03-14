
//  overload.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <string.h>

void  print_array( int  array_of_integers[],
                   int  number_of_integers_to_print )
{
   cout << "\n\n Integers in array:" ;

   for ( int integer_index  =  0 ;
             integer_index  <  number_of_integers_to_print ;
             integer_index  ++ )
   {
      cout << "   " << array_of_integers[ integer_index ] ;
   }
}

void  print_array( char  character_array[],
                   int   number_of_characters_to_print )
{
   cout << "\n\n Characters in array:" ;

   for ( int character_index  =  0 ;
             character_index  <  number_of_characters_to_print ;
             character_index  ++ )
   {
      cout << "   " << character_array[ character_index ] ;
   }
}

void  print_array( char  character_array[] )
{
   cout << "\n\n Characters in array:" ;

   for ( int character_index  =  0 ;
             character_index  <  strlen( character_array ) ;
             character_index  ++ )
   {
      cout << "   " << character_array[ character_index ] ;
   }
}

int main()
{
   int  first_array[]  =  { 55, 77, 888, 4444, 33, 22, 11 } ;

   char second_array[] =  "ABCDEFGHIJ" ;

   print_array( first_array, 6 ) ;
   print_array( second_array ) ;
   print_array( second_array, 5 ) ;
}


