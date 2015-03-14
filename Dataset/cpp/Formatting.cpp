
//  Formatting.cpp  (c) Kari Laitinen

//  http://www.naturalprogramming.com

//  2006-06-09  File created.
//  2006-06-09  Last modification.

//  This is the C++ version of corresponding Java/C#/Python
//  programs. This program is not presented in the C++ book.

//  Note that, for example, the manipulator 'hex' operates so
//  that numbers are printed in hexadecimal form as long as manipulators
//  'dec' or 'oct' have not been used. It is thus not necessary to
//  repeat the name 'hex' as often as is done in the statements below.
//  Many of the manipulators work in this way.

#include <iostream.h>
#include <iomanip.h>

int main()
{
   int  some_integer  =  123456 ;

   cout << "\n 12345678901234567890 \n"  ;

   cout << "\n " << right << setw( 9 ) << some_integer << "   right justified";
   cout << "\n " << left  << setw( 9 ) << some_integer << "   left justified";
   cout << "\n " << right << setw( 9 ) << hex << some_integer 
                                              << "   right hexadecimal" ;
   cout << "\n " << left  << setw( 9 ) << hex << some_integer
                                              << "   left hexadecimal" ;
   cout << "\n " << right << dec << some_integer << "   no printing field";
   cout << "\n " << right << hex << uppercase << some_integer 
                                              << "   hexadecimal uppercase" ;
   cout << "\n " << left  << hex << nouppercase << some_integer
                                              << "   hexadecimal lowercase" ;
   cout << "\n " << left  << hex << showbase << some_integer
                                             << "   hexadecimal with prefix 0x";
   cout << "\n " << left  << hex << noshowbase << some_integer
                                             << "   hexadecimal without prefix";
   cout << "\n " << right << dec << setfill( '0' ) << setw( 12 ) << some_integer
                                             << "   leading zeroes" ;
   cout << "\n " << right << hex << setfill( '0' ) << setw( 12 ) << some_integer
                                             << "   hexadecimal" << "\n" ;

   char another_text_to_print[]  =  "SOME TEXT" ;
   cout << "\n " <<  another_text_to_print << " is a string." ;

   char some_character  =  'k' ;
   cout << "\n " << some_character << " is a character." ; 
}



