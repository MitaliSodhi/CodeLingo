
//  showfile_better.cpp  (c) 2002-2004 Kari Laitinen

//  This program works in the same way as showfile.cpp
//  but this one includes the file <iostream> instead of
//  <iostream.h> and there is the appropriate using statement.
//  This program can probably be compiled with a wider range of
//  of C++ compilers as this is a more standard C++ program.

#include  <iostream>
#include  <fstream.h>  // C++ classes for file handling.
#include  <string>    // class string etc.

using namespace std ;

int main()
{
   string  file_name_from_user ;
   char    character_from_file ;
   int     character_counter  =  0  ;

   cout <<"\n This program prints the contents of a text"
          "\n file to the screen. Please, give the name"
          "\n of a text file: " ;

   getline( cin, file_name_from_user ) ;

   ifstream  file_to_print( file_name_from_user.c_str() ) ;

   if ( file_to_print.fail() )
   {
      cout << "\n Cannot open file "  <<  file_name_from_user ;
   }
   else
   {
      cout << "\n The contents of file is: \n\n" ;

      while ( ! file_to_print.eof() )
      {
         character_from_file  =  file_to_print.get() ;
         cout  <<  character_from_file ;
         character_counter  ++  ;
      }

      cout << "\n "  <<  character_counter
           << " characters were displayed on the screen.\n" ;
   }
}


