
//  forascx.cpp  (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <iomanip.h>

int main()
{
   int   number_of_codes_on_this_line  =  0 ;

   cout  << "\nASCII-coded characters are the following:\n\n" ;
   cout  <<  setfill( '0' ) ;

   for ( int numerical_code  =  0x20 ;
             numerical_code  <  0xFF ;
             numerical_code  ++ )
   {
      char  ascii_character  =  numerical_code  ;
      cout  <<  ascii_character  <<  " "
            <<  setw(3)  <<  numerical_code  <<  "  " ;

      number_of_codes_on_this_line  ++  ;

      if (  number_of_codes_on_this_line  ==  8  )
      {
         cout  <<  "\n" ;
         number_of_codes_on_this_line   =  0 ;
      }
   }
}




