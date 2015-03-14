
//  c_style_fileput.cpp  (c) 1998-2002 Kari Laitinen

//  This program should work in the same way as fileput.cpp,
//  but this version uses C-style file handling mechanisms.

#include  <iostream.h>
#include  <stdio.h>   // Functions for C-style file handling.

int main()
{
   FILE*  output_file_pointer ;
   char   file_name_from_user[ 20 ] ;
   char   character_from_keyboard ;

   cout << "\nThis program writes text you type in to a"
        << "\ntext file. Please, give first a file name: " ;

   cin.getline( file_name_from_user,
                sizeof( file_name_from_user ) ) ;

   output_file_pointer  =  fopen( file_name_from_user, "w" ) ;

   if ( output_file_pointer  ==  0 )
   {
      cout << "\nCannot open file "  <<  file_name_from_user ;
   }
   else
   {
      cout << "\n Please, start typing in text from keyboard."
           << "\n Type in Ctrl-Z and Enter to finish. \n\n" ;

      cin.get( character_from_keyboard ) ;
      while( ! cin.eof()  )
      {
         putc( character_from_keyboard, output_file_pointer ) ;
         cin.get( character_from_keyboard ) ;
      }

      fclose( output_file_pointer ) ;
   }
}
