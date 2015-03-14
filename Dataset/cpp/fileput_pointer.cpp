
//  fileput_pointer.cpp  (c) 1998-2002 Kari Laitinen

#include <iostream.h>
#include <fstream.h>   // Functions for file handling.

int main()
{
   ofstream*  output_file  =  new  ofstream() ;

   char   file_name_from_user[ 20 ] ;
   char   character_from_keyboard ;

   cout << "\n This program allows you to store text into a"
        << "\n text file. Give first a file name: " ;

   cin.getline( file_name_from_user,
                sizeof( file_name_from_user ) ) ;

   output_file -> open( file_name_from_user ) ;

   if ( output_file -> fail() )
   {
      cout << "\n Cannot open file " << file_name_from_user ;
   }
   else
   {
      cout << "\n Please, start typing in text from keyboard."
           << "\n Type in Ctrl-Z and Enter to finish. \n\n" ;

      cin.get( character_from_keyboard ) ;

      while( ! cin.eof()  )
      {
         *output_file  <<  character_from_keyboard ;

         cin.get( character_from_keyboard ) ;
      }

      output_file -> close() ;  // This is not necessary because ...

      delete  output_file ;  // ... the destructor closes the file
   }
}



