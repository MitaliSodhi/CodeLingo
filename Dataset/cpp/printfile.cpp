//  printfile.cpp  (c) 2002  Kari Laitinen

#include  <iostream.h>
#include  <fstream.h>

int main( int   number_of_command_line_arguments,
          char* command_line_arguments[] )
{
   if ( number_of_command_line_arguments  ==  1 )
   {
      cout << "\n\n You have to command this program as: "
              "\n\n printfile filename.ext \n\n" ;
   }
   else
   {
      ifstream  file_to_be_displayed( command_line_arguments[ 1 ] ) ;

      if ( ! file_to_be_displayed )
      {
         cout  <<  "\n Cannot open " <<  command_line_arguments[ 1 ] ;
      }
      else
      {
         char  text_line_from_file[ 100 ] ;

         while ( ! file_to_be_displayed.eof() )
         {
            file_to_be_displayed.getline( text_line_from_file,
                                  sizeof( text_line_from_file ) ) ;

            cout  << "\n" << text_line_from_file ;
         }
      }
   }
}





