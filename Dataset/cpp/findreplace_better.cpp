
//  findreplace_better.cpp   (c) 2000-2004  Kari Laitinen

//  This program works in the same way as findreplace.cpp
//  but this one includes the file <iostream> instead of
//  <iostream.h> and there is the appropriate using statement.
//  This program can probably be compiled with a wider range of
//  of C++ compilers as this is a more standard C++ program.

#include  <iostream>
#include  <fstream.h>  // C++ classes for file handling.
#include  <string>    // class string etc.
#include  <sstream>

using namespace std ;

void
store_stringstream_to_file( stringstream&  given_stringstream,
                            string         given_file_name )
{
   ofstream   output_file( given_file_name.c_str() ) ;

   if ( output_file.fail() )
   {
      cout << "\n Cannot open output file \""
           << given_file_name  <<  "\"\n" ;
   }
   else
   {
      while ( ! given_stringstream.eof() )
      {
         string  line_from_stream ;

         getline( given_stringstream, line_from_stream ) ;

         output_file  <<  line_from_stream  <<  "\n" ;
      }
   }
}


void replace_string_in_file( string  original_file_name,
                             string  string_to_replace,
                             string  replacement_string )
{
   stringstream  original_text_lines ;
   stringstream  modified_text_lines ;

   string  text_line_from_file ;
   int     line_counter  =  0 ;

   ifstream  original_file( original_file_name.c_str() ) ;

   if ( original_file.fail() )
   {
      cout << "\n Cannot open file " << original_file_name ;
   }
   else
   {
      while( ! original_file.eof() )
      {
         getline( original_file, text_line_from_file ) ;

         line_counter  ++ ;

         original_text_lines  <<  text_line_from_file  <<  "\n" ;

         unsigned int replacement_position ;

         while ( ( replacement_position  =  
                    text_line_from_file.find( string_to_replace ) )
                                          !=  string::npos )
         {
            text_line_from_file.replace( replacement_position,
                                         string_to_replace.length(),
                                         replacement_string ) ;

            cout << "\n \""  <<  string_to_replace
                 << "\" was replaced with \"" << replacement_string
                 << "\" on line "  <<  line_counter  ;
         }

         modified_text_lines  <<  text_line_from_file  <<  "\n" ;
      }

      original_file.close() ;

      string  backup_file_name  =  original_file_name  +  ".bak" ;

      store_stringstream_to_file( original_text_lines,
                                  backup_file_name   ) ; 

      store_stringstream_to_file( modified_text_lines,
                                  original_file_name ) ;
   }
}


int main( int    number_of_command_line_arguments,
          char*  command_line_arguments[] )
{
   string  file_name_given_by_user ;
   string  string_to_replace ;
   string  replacement_string ;

   if ( number_of_command_line_arguments  ==  4 )
   {
      file_name_given_by_user  =  command_line_arguments[ 1 ] ;
      string_to_replace        =  command_line_arguments[ 2 ] ;
      replacement_string       =  command_line_arguments[ 3 ] ;
   }
   else
   {
      cout << "\n This program can replace a string in a "
           << "\n text file. Give first the file name :  " ;

      getline( cin, file_name_given_by_user ) ;

      cout << "\n Type in the string to be replaced: " ;
      getline( cin, string_to_replace ) ;

      cout << "\n Type in the replacement string:    " ;
      getline( cin, replacement_string ) ;
   }

   if ( string_to_replace  ==  ""  ||
        string_to_replace  ==  replacement_string )
   {
      cout << "\n Cannot replace \"" << string_to_replace
           << "\" with \""  <<  replacement_string << "\"\n\n" ;
   }
   else
   {
      replace_string_in_file( file_name_given_by_user,
                              string_to_replace,
                              replacement_string ) ;
   }
}




