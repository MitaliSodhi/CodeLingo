
//  ascii.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <iomanip.h>
#include  <conio.h>

int main()
{
   unsigned char  character_code  =  '?' ;

   cout << "\nThis program prints the ascii codes of "
        << "\ncharacters. Please, type in characters. "
        << "\nThe program stops when you type in A.\n" ;

   while ( character_code  !=  'A'  &&
           character_code  !=  'a'  )
   {
      character_code  =  getch() ;

      cout << "\n  "  <<  setfill( '0' )
           << character_code        <<  "   "
           << hex     <<  setw( 2 ) << (int) character_code << "   " 
           << dec     <<  setw( 3 ) << (int) character_code << "   " ;

      putch( character_code ) ;
   }
}
