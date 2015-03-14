//  lines.cpp  (c)  1999-2002 Kari Laitinen

#include  <iostream.h>
#include  <fstream.h>
#include  <strstrea.h>
#include  <string.h>

int main()
{
   char text_line[ 100 ] ;

   strstream  buffer_for_text_lines ;

   cout << "\nTYPE IN TEXT LINES! \n\n" ;

   cin.getline( text_line, sizeof( text_line ) ) ;

   while ( strlen( text_line )  >  0 )
   {
      buffer_for_text_lines  <<  text_line  <<  "\n" ;

      cin.getline( text_line, sizeof( text_line ) ) ;
   }

   buffer_for_text_lines  <<  ends ;

   cout << "\nHERE ARE YOUR TEXT LINES: \n\n" ;

   cout << buffer_for_text_lines.rdbuf() ;
}



