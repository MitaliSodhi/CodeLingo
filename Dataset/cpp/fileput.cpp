
//  fileput.cpp  (c) 1998-2002 Kari Laitinen

#include <iostream.h>
#include <fstream.h>   // Functions for file handling.

int main()
{
   ofstream  output_file ;

   char   file_name_from_user[ 20 ] ;
   char   character_from_keyboard ;

   cout << "\n This program allows you to store text in a"
        << "\n text file. First give a file name: " ;

   cin.getline( file_name_from_user,
                sizeof( file_name_from_user ) ) ;

   output_file.open( file_name_from_user ) ;

   if ( output_file.fail() )
   {
      cout << "\n Cannot open file " << file_name_from_user ;
   }
   else
   {
      cout << "\n Please, start typing in text from the keyboard."
           << "\n Type in Ctrl-Z and Enter to finish. \n\n" ;

      cin.get( character_from_keyboard ) ;

      while( ! cin.eof()  )
      {
         output_file  <<  character_from_keyboard ;

         cin.get( character_from_keyboard ) ;
      }
   }
}



