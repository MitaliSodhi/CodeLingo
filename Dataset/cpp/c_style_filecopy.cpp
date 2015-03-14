
//  c_style_filecopy.cpp  (c) 1997-2002 Kari Laitinen

//  This program uses C-style file accessing.
//  Otherwise this behaves like "filecopy.cpp".

#include  <iostream.h>
#include  <stdio.h>  // Functions for C-style file handling.

int  main()
{
   FILE*  file_to_be_copied ;
   FILE*  new_duplicate_file ;
   char   name_of_file_to_be_copied[ 20 ] ;
   char   name_of_new_duplicate_file[ 20 ] ;
   char   text_line_from_file[ 100 ] ;
   int    text_line_counter  =  0 ;

   cout << "\nThis program copies text from one file"
        << "\nto another file. Please, give the name of"
        << "\nthe file to be copied: " ;

   cin.getline( name_of_file_to_be_copied,
                sizeof( name_of_file_to_be_copied ) ) ;

   cout << "\nPlease, give the name of the duplicate file: " ;

   cin.getline( name_of_new_duplicate_file,
                sizeof( name_of_new_duplicate_file ) ) ;

   file_to_be_copied   =  fopen( name_of_file_to_be_copied, "r" ) ;
   new_duplicate_file  =  fopen( name_of_new_duplicate_file,  "w" ) ;

   if ( file_to_be_copied  ==  0 )
   {
      cout << "\nCannot open file "  <<  name_of_file_to_be_copied ;
   }
   else if ( new_duplicate_file  ==  0 )
   {
      cout << "\nCannot open file "  <<  name_of_new_duplicate_file ;
   }
   else
   {
      cout << "\nCopying in progress ... \n" ;

      while( fgets( text_line_from_file,
                    sizeof ( text_line_from_file ),
                    file_to_be_copied ) != 0  )
      {
         fputs( text_line_from_file, new_duplicate_file ) ;
         text_line_counter  ++  ;
      }

      fclose( file_to_be_copied ) ;
      fclose( new_duplicate_file ) ;

      cout << "\nCopying ready. "  <<  text_line_counter
           << " lines were copied. \n" ;
   }
}
