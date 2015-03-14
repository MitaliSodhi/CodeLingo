
//  c_style_showfile.cpp  (c) 1998-2002 Kari Laitinen

//  This program uses C-style file access mechanisms.
//  Otherwise this works in the same way as "showfile.cpp"

#include  <iostream.h>
#include  <stdio.h>  // Functions for C-stype file handling.
#include  <stdlib.h> // Definition for EOF (End Of File).

int main()
{
   FILE*  file_to_print ;
   char   file_name_from_user[ 20 ] ;
   char   character_from_file ;
   int    character_counter  =  0  ;

   cout << "\n\nThis program prints the contents of a text"
        << "\nfile to the screen. Please, give the name"
        << "\nof a text file: " ;

   cin.getline( file_name_from_user,
                sizeof( file_name_from_user ) ) ;

   file_to_print  =  fopen( file_name_from_user, "r" ) ;

   if ( file_to_print  ==  0 )
   {
      cout  <<  "\nCannot open file "  <<  file_name_from_user ;
   }
   else
   {
      character_from_file  =  getc( file_to_print ) ;

      while ( character_from_file  !=  EOF )
      {
         cout  <<  character_from_file ;
         character_counter  ++  ;
         character_from_file  =  getc( file_to_print ) ;
      }

      fclose( file_to_print ) ;

      cout << "\n\n "  <<  character_counter
           << " characters were printed to the screen.\n" ;
   }
}



