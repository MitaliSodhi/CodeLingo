
//  filecopy.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>
#include  <fstream.h>  // File handling classes.

int main()
{
   ifstream  file_to_be_copied ;
   ofstream  new_duplicate_file ;

   char  name_of_file_to_be_copied[ 50 ] ;
   char  name_of_new_duplicate_file[ 50 ] ;

   cout << "\n This program copies text from one file"
        << "\n to another file. Please, give the name of"
        << "\n the file to be copied: " ;

   cin.getline( name_of_file_to_be_copied,
                sizeof( name_of_file_to_be_copied ) ) ;

   cout << "\n Give the name of the duplicate file: " ;

   cin.getline( name_of_new_duplicate_file,
                sizeof( name_of_new_duplicate_file ) ) ;

   file_to_be_copied.open( name_of_file_to_be_copied ) ;
   new_duplicate_file.open( name_of_new_duplicate_file ) ;

   if ( file_to_be_copied.fail() )
   {
      cout << "\n Cannot open "  <<  name_of_file_to_be_copied ;
   }
   else if ( new_duplicate_file.fail() )
   {
      cout << "\n Cannot open "  <<  name_of_new_duplicate_file ;
   }
   else
   {
      char text_line_from_file[ 150 ] ;
      int  text_line_counter  =  0 ;

      cout << "\n Copying in progress ... \n" ;

      while( ! file_to_be_copied.eof() )
      {
         file_to_be_copied.getline( text_line_from_file,
                                    sizeof( text_line_from_file) );

         new_duplicate_file  <<  text_line_from_file ;

         if ( ! file_to_be_copied.eof() )
         {
            new_duplicate_file  <<  "\n" ;
         }

         text_line_counter  ++  ;
      }

      cout << "\n Copying ready. "  <<  text_line_counter
           << " lines were copied. \n" ;
   }
}



