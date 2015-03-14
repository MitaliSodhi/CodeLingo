
//  storelines.cpp  (c) 2000 Kari Laitinen

#include <iostream.h>
#include <fstream.h>   // Functions for file handling.

int main()
{
   ofstream  output_file ;

   char   file_name_from_user[ 20 ] ;
   char   text_line_from_keyboard[ 200 ] ;

   cout << "\n This program allows you to store text lines"
        << "\n into a file. Give first a file name: " ;

   cin.getline( file_name_from_user,
                sizeof( file_name_from_user ) ) ;

   output_file.open( file_name_from_user ) ;

   if ( output_file.fail() )
   {
      cout << "\n Cannot open file " << file_name_from_user ;
   }
   else
   {
      cout << "\n Please, start typing in text lines."
           << "\n The program stops after 8 lines. \n\n" ;

      int  line_counter  =  0 ;

      while( line_counter  <  8 )
      {
         cin.getline( text_line_from_keyboard,
                      sizeof( text_line_from_keyboard ) ) ;

         output_file  <<  text_line_from_keyboard  <<  "\n" ;

         line_counter  ++  ;
      }
   }
}



