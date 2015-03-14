
//  forascii.cpp  (c) 1997-2004 Kari Laitinen

#include  <iostream.h>

int main()
{
   int   number_of_codes_on_this_line  =  0 ;

   cout  << "\n The visible ASCII-coded characters from"
         << "\n 20 to 7F (hexadecimal) are the following:\n\n " ;

   for ( int numerical_code  =  0x20 ;
             numerical_code  <  0x80 ;
             numerical_code  ++ )
   {
      char  character_to_print  =  numerical_code  ;
      cout  <<  character_to_print  <<  " "
            <<  hex  <<  numerical_code  <<  "  " ;

      number_of_codes_on_this_line  ++  ;

      if (  number_of_codes_on_this_line  ==  8  )
      {
         cout  <<  "\n " ;
         number_of_codes_on_this_line   =  0 ;
      }
   }
}



