
//  double_to_binary.cpp  (c) 1998-2004 Kari Laitinen

//  2004-10-10  File created.

#include  <iostream.h>

void  print_in_binary_form( char  given_byte )
{
   unsigned char  bit_mask      =  0x80 ;
   unsigned char  one_bit_in_given_byte ;

   for ( int bit_counter  =  0  ;
             bit_counter  <  8 ;
             bit_counter  ++ )
   {
      one_bit_in_given_byte  = given_byte  &  bit_mask ;

      if ( one_bit_in_given_byte  ==  0 )
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
   cout  << "\n\n" ;

   double test_number  =  123.456 ;

   char*  byte_in_test_number  =  (char*) &test_number ;

   for ( int byte_counter  =  0 ;
             byte_counter  <  sizeof( double ) ;
             byte_counter  ++ )
   {
      cout  <<  " " ;
      print_in_binary_form( *byte_in_test_number ) ;
      byte_in_test_number  ++ ;
   }

   cout  << "\n\n" ;

   cout  << "\n  The following is not correct: \n" ;

   int*  first_four_bytes  =  (int*)  &test_number ;
   int*  last_four_bytes   =  first_four_bytes  +  1 ;

   print_in_binary_form( *first_four_bytes ) ;

   cout  <<  "  " ;

   print_in_binary_form( *last_four_bytes ) ;

}



