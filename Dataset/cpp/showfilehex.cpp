
//  showfilehex.cpp  (c) 2002 Kari Laitinen

#include  <iostream.h>
#include  <fstream.h>  // C++ classes for file handling.

#include  "useful_functions.h"

int main( int   number_of_command_line_arguments,
          char* command_line_arguments[] )
{
   if ( number_of_command_line_arguments  !=  2 )
   {
      cout << "\n You have to command this program as: \n"
              "\n  showfilehex filename.ext \n" ;
   }
   else
   {
      ifstream  given_file( command_line_arguments[ 1 ],
                            ios::binary ) ;

      if ( given_file.fail() )
      {
         cout << "\n Cannot open " << command_line_arguments[ 1 ] ;
      }
      else
      {
         while ( ! given_file.eof() )
         {
            unsigned char  bytes_from_file[ 30 ] ;

            given_file.read( bytes_from_file,  16 ) ;

            int number_of_bytes_read  =  given_file.gcount() ;

            print_memory_contents( bytes_from_file, number_of_bytes_read ) ;
         }

      }
   }
}





