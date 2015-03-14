//  forcodes80toFF.cpp  (c) 1997-2004 Kari Laitinen

#include  <iostream.h>

int main()
{
   int   number_of_codes_on_this_line  =  0 ;

   cout  << "\n The visible ASCII-coded characters from 0x80"
         << "\n to 0xFF (hexadecimal) are the following:\n\n " ;

   for ( int numerical_code  =  0x80 ;
             numerical_code  <  0x100 ;
             numerical_code  ++ )
   {
      char  ascii_character  =  numerical_code  ;
      cout  <<  ascii_character  <<  " "
            <<  hex  <<  numerical_code  <<  "  " ;

      number_of_codes_on_this_line  ++  ;

      if (  number_of_codes_on_this_line  ==  8  )
      {
         cout  <<  "\n " ;
         number_of_codes_on_this_line   =  0 ;
      }
   }
}



