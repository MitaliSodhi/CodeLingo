
//  bit_operator_tests.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

#include  <iostream.h>

void  print_in_binary_form( int  given_integer )
{
   // This program works only with 32-bit int variables.
   // To make this program work with 16-bit int variables,
   // you should use initial mask 0x8000 and let the loop
   // be executed only 16 times.

   unsigned int  bit_mask      =  0x80000000 ;
   unsigned int  one_bit_in_given_integer ;

   for ( int bit_counter  =  0  ;
             bit_counter  <  32 ;
             bit_counter  ++ )
   {
      one_bit_in_given_integer  = given_integer & bit_mask ;

      if ( one_bit_in_given_integer  ==  0 )
      {
         cout  <<  "0"  ;
      }
      else
      {
         cout  <<  "1"  ;
      }

      bit_mask  =  bit_mask  >>  1 ;
   }  
}


   int main()
   {
      cout << hex ;

      cout << "\n (0x61 & 0xDF) produces 0x"
                  << ( 0x61 & 0xDF) ;
      cout << "\n (0xF0 & 0x0F) produces 0x"
                  <<  (0xF0 & 0x0F) <<  "\n" ;

      cout << "\n (0x41 | 0x20) produces 0x"
                  <<  (0x41 | 0x20) ;
      cout << "\n (0xF0 | 0x0F) produces 0x"
                  <<  (0xF0 | 0x0F) <<  "\n" ;

      cout << "\n (0xAF ^ 0xFF) produces 0x"
                  <<  (0xAF ^ 0xFF) ;
      cout << "\n (0xFF ^ 0xFF) produces 0x"
                  <<  (0xFF ^ 0xFF) <<  "\n" ;

      cout << "\n ( ~ 0xE1 ) produces 0x"
                  <<  ( ~ 0xE1 ) ;
      cout << "\n ( ~ 0xF0 ) produces 0x"
                  <<  ( ~ 0xF0 ) <<  "\n" ;

      cout << "\n ( 0x49 >> 2 ) produces 0x"
                  <<  ( 0x49 >> 2 ) ;
      cout << "\n ( 0x49 >> 3 ) produces 0x"
                  <<  ( 0x49 >> 3 ) <<  "\n" ;

      cout << "\n ( 0x12 << 3 ) produces 0x"
                  <<  ( 0x12 << 3 ) ;
      cout << "\n ( 0x12 << 4 ) produces 0x"
             <<  ( 0x12 <<   4 ) <<  "\n" ;

      cout << "\n "  ;

      unsigned short  variable_of_16_bits  =  0xA26B ;

      print_in_binary_form( variable_of_16_bits ) ;

      variable_of_16_bits  =  variable_of_16_bits  >>  3  ;

      cout << "\n "  ;

      print_in_binary_form( variable_of_16_bits ) ;

   }


