
//  c_style_search.cpp   (c) 1998-2002 Kari Laitinen

//  This program uses C-style file handling mechanisms.
//  Otherwise this behaves like "search.cpp".

#include   <iostream.h>
#include   <stdio.h>
#include   <string.h>

void search_string_from_file( char  file_name_from_caller[],
                              char  string_to_be_searched[] )
{
   FILE   *file_pointer  ;
   char   text_line_from_file[100] ;
   int    line_counter  =  0 ;

   file_pointer  =  fopen( file_name_from_caller, "r" ) ;

   if ( file_pointer  ==  0 )
   {
      cout << "\nError in opening file " << file_name_from_caller ;
   }
   else
   {
      cout << "\n Searching.. \""<< string_to_be_searched <<"\"\n";

      while( fgets( text_line_from_file,
                    sizeof ( text_line_from_file ),
                    file_pointer ) != 0  )
      {
         line_counter  ++ ;
         if ( strstr( text_line_from_file,
                      string_to_be_searched ) )
         {
            cout << "\nString \"" <<  string_to_be_searched
                 << "\" was found on line " << line_counter ;
         }
      }

      fclose( file_pointer ) ;
   }
}

int main( int    number_of_command_line_arguments,
          char*  command_line_arguments[] )
{
   char   file_name_given_by_user[ 50 ] ;
   char   string_to_be_searched[ 100 ] ;

   if ( number_of_command_line_arguments  ==  3 )
   {
      search_string_from_file ( command_line_arguments[ 1 ],
                                command_line_arguments[ 2 ] ) ;
   }
   else
   {
      cout << "\nThis program can search a string in a "
           << "\ntext file. Give first the file name :  " ;
      cin.getline( file_name_given_by_user,
                   sizeof( file_name_given_by_user ) ) ;

      cout << "\nType in the string to be searched: " ;
      cin.getline( string_to_be_searched,
                   sizeof( string_to_be_searched ) ) ;

      search_string_from_file( file_name_given_by_user,
                               string_to_be_searched ) ;
   }
}



