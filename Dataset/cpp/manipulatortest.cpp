
//  manipulatortest.cpp  (c) 2002 Kari Laitinen

/*  This program can be used to test how the input/output
    manipulators work in practice.

    In Borland C++ 5.5.1 seem to be the following defaults

      -  right is the default for justification in printing fields
      -  noshowbase, no prefix 0x in hexadecimal numbers
      -  nouppercase, hexadecimal numbers have digits a, b, c, etc.
      -  noboolalpha, boolean values are 1 and 0.

*/

#include  <iostream.h>
#include  <iomanip.h>

int main()
{
   int  some_number  =  888 ;
   char some_text[]  =  "This is test text." ;

   cout << "\n         1         2         3         4         5"
             "         6         7"
           "\n12345678901234567890123456789012345678901234567890"
             "12345678901234567890\n" ;

   cout << setfill( '-' ) ;
//   cout << right ;
   cout << showpos ;
   cout << internal ;

   cout << "\n" << setw( 10 )  <<  some_number
                << setw( 30 )  <<  some_text
                << setw( 30 )  <<  "Another text" ;

   cout << ends ;

}



