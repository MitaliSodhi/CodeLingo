
//  FileToNumbers.cpp  (c) Kari Laitinen

//  http://www.naturalprogramming.com

//  2006-06-09  File created.
//  2006-06-09  Last modification.

//  This is the C++ version of corresponding Java/C#/Python
//  programs. This program is not presented in the C++ book.

#include  <iostream.h>
#include  <fstream.h>  // C++ classes for file handling.
#include  <iomanip.h>
#include  <sstream>    // Class stringstream
#include  <string>     // Class string

int main( int   number_of_command_line_arguments,
          char* command_line_arguments[] )
{
   if ( number_of_command_line_arguments  !=  2 )
   {
      cout << "\n You have to command this program as: \n"
              "\n  FileToNumbers file.ext \n" ;
   }
   else
   {
      ifstream  file_to_read( command_line_arguments[ 1 ],
                               ios::binary ) ;

      if ( file_to_read.fail() )
      {
         cout << "\n Cannot open " << command_line_arguments[ 1 ] ;
      }
      else
      {
         while ( ! file_to_read.eof() )
         {
            unsigned char  bytes_from_file[ 16 ] ;

            file_to_read.read( bytes_from_file,  16 ) ;

            int number_of_bytes_read  =  file_to_read.gcount() ;

            stringstream  stream_of_bytes  ;
            string        bytes_as_characters  =  "" ;

            for ( int byte_index  =  0 ;
                      byte_index  <  number_of_bytes_read ;
                      byte_index  ++ )
            {
               stream_of_bytes <<  " "  <<  setfill( '0' )  <<  hex
                               <<  setw( 2 )
                               <<  (int) bytes_from_file[ byte_index ]  ;

               if ( bytes_from_file[ byte_index ]  >=  ' ' )
               {
                  bytes_as_characters.append( 1,
                                              bytes_from_file[ byte_index ] );
               }
               else
               {
                  bytes_as_characters.append( 1, ' ' ) ;
               }
            }

            string  line_of_bytes ;

            getline( stream_of_bytes, line_of_bytes ) ;

            cout <<  "\n"  <<  left  <<  setw( 48 ) <<  line_of_bytes
                 <<  "  "  <<  bytes_as_characters ;
         }
      }
   }
}





