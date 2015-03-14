
//  c_style_fileprint.cpp  (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <stdio.h>  // Functions for C-stype file handling.

//  This program works in the same way as "fileprint.cpp"
//  but this one employs C-style file access mechanisms.

int main()
{
   FILE*  file_to_print ;
   char   file_name_from_user[ 20 ] ;
   char   text_line_from_file[ 150 ] ;

   cout << "\n This program prints the contents of a text"
        << "\n file to the screen. Give file name: " ;

   cin.getline( file_name_from_user,
                sizeof( file_name_from_user ) ) ;

   file_to_print  =  fopen( file_name_from_user, "r" ) ;

   if ( file_to_print  ==  0 )
   {
      cout  <<  "\nCannot open file "  <<  file_name_from_user ;
   }
   else
   {
      int line_counter  =  0 ;

      while ( fgets( text_line_from_file,
                     sizeof( text_line_from_file),
                     file_to_print )  !=  0  )
      {
         cout  <<  text_line_from_file  ;

         line_counter  ++  ;
      }

      fclose( file_to_print ) ;

      cout  << "\n  " <<  line_counter  << " lines printed." ;
   }
}


