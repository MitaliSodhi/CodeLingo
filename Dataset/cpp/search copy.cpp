
//  search.cpp  (c) 2002  Kari Laitinen

#include   <iostream.h>
#include   <fstream.h>
#include   <string.h>

void search_string_in_file( char  file_name_from_caller[],
                            char  string_to_be_searched[] )
{
   ifstream   file_to_read  ;

   char  text_line_from_file[ 100 ] ;
   int   line_counter  =  0 ;

   file_to_read.open( file_name_from_caller ) ;

   if ( file_to_read.fail() )
   {
      cout << "\n Cannot open file " << file_name_from_caller ;
   }
   else
   {
      cout << "\n Searching.. \""<< string_to_be_searched <<"\"\n";

      while( ! file_to_read.eof() )
      {
         file_to_read.getline( text_line_from_file,
                               sizeof( text_line_from_file ) ) ;

         line_counter  ++ ;

         if ( strstr( text_line_from_file,
                      string_to_be_searched ) )
         {
            cout << "\n String \"" <<  string_to_be_searched
                 << "\" was found on line " << line_counter ;
         }
      }
   }
}


int main( int    number_of_command_line_arguments,
          char*  command_line_arguments[] )
{
   if ( number_of_command_line_arguments  ==  3 )
   {
      search_string_in_file ( command_line_arguments[ 1 ],
                              command_line_arguments[ 2 ] ) ;
   }
   else
   {
      char file_name_given_by_user[ 50 ] ;
      char string_to_be_searched[ 100 ] ;

      cout << "\n This program can search a string in a "
           << "\n text file. Give first the file name :  " ;
      cin.getline( file_name_given_by_user,
                   sizeof( file_name_given_by_user ) ) ;

      cout << "\n Type in the string to be searched: " ;
      cin.getline( string_to_be_searched,
                   sizeof( string_to_be_searched ) ) ;

      search_string_in_file( file_name_given_by_user,
                             string_to_be_searched ) ;
   }
}



