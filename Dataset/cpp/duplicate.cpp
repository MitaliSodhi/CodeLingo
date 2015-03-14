
//  duplicate.cpp  (c) 1999-2002 Kari Laitinen

#include  <iostream.h>
#include  <fstream.h>  // C++ classes for file handling.
#include  <string>     // definitions for class string

int main()
{
   string   name_of_file_to_be_copied ;
   string   name_of_new_duplicate_file ;

   cout << "\n This program copies text from one file"
        << "\n to another file. Please, give the name of"
        << "\n the file to be copied: " ;

   getline( cin, name_of_file_to_be_copied ) ;

   cout << "\n Give the name of the duplicate file: " ;

   getline( cin, name_of_new_duplicate_file ) ;

   ifstream file_to_be_copied( name_of_file_to_be_copied.c_str() ) ;

   if ( ! file_to_be_copied )
   {
      cout << "\n Cannot open file " << name_of_file_to_be_copied ;
   }
   else
   {
      ofstream new_duplicate_file( name_of_new_duplicate_file.c_str() ) ;

      if ( ! new_duplicate_file )
      {
         cout << "\n Cannot open file " << name_of_new_duplicate_file ;
      }
      else
      {
         cout << "\n Copying in progress ... \n" ;

         string  text_line_from_file ;
         int     text_line_counter  =  0 ;

         while( ! file_to_be_copied.eof() )
         {
            getline( file_to_be_copied, text_line_from_file ) ;
            new_duplicate_file  <<  text_line_from_file  << "\n" ;
            text_line_counter  ++  ;
         }

         cout << "\n Copying ready. "  <<  text_line_counter
              << " lines were copied. \n" ;
      }
   }
}


