
//  fileprint.cpp  (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <fstream.h>  // File handling classes.

int main()
{
   ifstream  file_to_print ;

   char   file_name_from_user[ 50 ] ;
   char   text_line_from_file[ 150 ] ;

   cout << "\n This program prints the contents of a text"
        << "\n file to the screen. Give a file name: " ;

   cin.getline( file_name_from_user,
                sizeof( file_name_from_user ) ) ;

   file_to_print.open( file_name_from_user ) ;

   if ( file_to_print.fail() )
   {
      cout << "\n Cannot open file " << file_name_from_user ;
   }
   else
   {
      int line_counter  =  0 ;

      while ( ! file_to_print.eof() )
      {
         file_to_print.getline( text_line_from_file,
                                sizeof( text_line_from_file ) ) ;

         cout  <<  text_line_from_file  <<  "\n" ;

         line_counter  ++  ;
      }

      file_to_print.close() ;

      cout  << "\n  " <<  line_counter  << " lines printed." ;
   }
}


