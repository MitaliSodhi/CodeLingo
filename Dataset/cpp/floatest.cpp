
//  floatest.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>
#include  <iomanip.h>

void
print_memory_in_hexadecimal( void*  memory_address,
                             int    number_of_bytes_to_print )
{
   char*  a_byte_in_memory        =  (char*)  memory_address ;
   long   current_memory_address  =  0 ;
   int    byte_counter      =  0 ;

   while  (  byte_counter  <  number_of_bytes_to_print  )
   {
      if  ( ( byte_counter  %  16  )  ==  0  )
      {
         current_memory_address  =  (long) a_byte_in_memory ;
         cout  <<  "\n" << hex <<  current_memory_address  <<  " " ;
      }
      short  higher_order_nibble  =  *a_byte_in_memory  &  0x00F0 ;
      higher_order_nibble  =  higher_order_nibble  >>  4  ;
      short  lower_order_nibble   =  *a_byte_in_memory  &  0x000F ;

      cout  <<  " "
            <<  higher_order_nibble  <<  lower_order_nibble ;
      a_byte_in_memory  ++  ;
      byte_counter      ++  ;
   }
}


int main()
{
   float   a_float_variable     =   123.456789 ;
   double  a_double_variable    =   11223344.5566 ;

   cout  <<  "\n\nThe contents of float is: \n" ;
   print_memory_in_hexadecimal(  &a_float_variable,  14  ) ;

   cout  <<  "\n\nThe contents of double is: \n" ;
   print_memory_in_hexadecimal(  &a_double_variable, 14  ) ;

   cout  <<  "\n\nThe code of function "
         <<  " \"print_memory_in_hexadecimal\" starts : \n" ;
   print_memory_in_hexadecimal(
                print_memory_in_hexadecimal,  100 ) ;
}




