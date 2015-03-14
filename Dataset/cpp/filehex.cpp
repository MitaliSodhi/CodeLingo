
//  filehex.cpp  (c) 2001 Kari Laitinen

#include  <iostream.h>
#include  <iomanip.h>
#include  <fstream.h>  // File handling classes.

int main( int   number_of_command_line_arguments,
          char* command_line_arguments[] )
{
   if ( number_of_command_line_arguments  ==  2 )
   {
      ifstream  file_to_show ;

      file_to_show.open( command_line_arguments[ 1 ], ios::binary ) ;

      if ( file_to_show.fail() )
      {
         cout << "\n Cannot open " << command_line_arguments[ 1 ] ;
      }
      else
      {
         cout  <<  hex  <<  setfill( '0' )  <<  uppercase ;

         while ( ! file_to_show.eof() )
         {
            char  byte_from_file ;

            file_to_show.read( &byte_from_file, 1 ) ;

            if ( file_to_show.gcount()  ==  1 )
            {
               if ( byte_from_file  >=  ' ' )
               {
                  cout << byte_from_file ;
               }
               else
               {
                  cout << " " ;
               }

               cout << "   "  <<  setw( 2 )  <<  (int) byte_from_file ;

               cout <<  "H\n" ;
            } 
         }
      }
   }
   else
   {
      cout << "\n\n COMMAND:  filehex filename.ext  \n\n" ;
   }
}


