
//  commanding.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>

int main( int    number_of_command_line_arguments,
          char*  command_line_arguments[] )
{
   cout << "\n Function main was given the following "
        << number_of_command_line_arguments << " strings"
        << "\n as command line arguments: \n" ;

   int  argument_index  =  0 ;

   while ( argument_index  <  number_of_command_line_arguments )
   {
      cout << "\n     "
           << command_line_arguments[ argument_index ] ;

      argument_index  ++ ;
   }
}



