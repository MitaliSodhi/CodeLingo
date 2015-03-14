//  binary.cpp  (c) 1998-2002 Kari Laitinen

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
   unsigned  int  test_number  =  0x9A9A ;

   cout << "\n Original test number:    " ;
   print_in_binary_form( test_number ) ;

   cout << "\n Twice left-shifted form: " ;
   test_number  =  test_number  <<  2  ;  
   print_in_binary_form( test_number ) ;

   cout << "\n Back to original form:   " ;
   test_number  =  test_number  >>  2  ;
   print_in_binary_form( test_number ) ;

   cout << "\n Last four bits zeroed:   " ;
   test_number  =  test_number  &  0xFFF0 ;
   print_in_binary_form( test_number ) ;

   cout << "\n Last four bits to one:   " ;
   test_number  =  test_number  |  0x000F ;
   print_in_binary_form( test_number ) ;

   cout << "\n A complemented form:     " ;
   test_number  =  ~test_number ;
   print_in_binary_form( test_number ) ;

   cout << "\n Exclusive OR with 0xF0F0:" ;
   test_number  =  test_number ^ 0xF0F0 ;
   print_in_binary_form( test_number ) ;
}



