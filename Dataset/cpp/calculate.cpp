
//  calculate.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <stdlib.h>

void  print_calculations ( int first_integer,
                           int second_integer )
{
   cout << "\n    " << first_integer << " + "
        << second_integer << " = "
        << first_integer + second_integer 
        << "\n    " << first_integer << " - "
        << second_integer << " = "
        << first_integer - second_integer
        << "\n    " << first_integer << " * "
        << second_integer << " = "
        << first_integer * second_integer ;

   if ( second_integer  !=  0 )
   {
      cout << "\n    " << first_integer << " / "
           << second_integer << " = "
           << first_integer / second_integer
           << "\n    " << first_integer << " % "
           << second_integer << " = "
           << first_integer % second_integer << "\n" ;
   }
   else
   {
      cout << "\n    Cannot divide with zero. \n" ;
   }
}

int main( int    number_of_command_line_arguments,
          char*  command_line_arguments[] )
{
   int  first_operand, second_operand ;

   if ( number_of_command_line_arguments  ==  3 )
   {
      first_operand   =  atoi( command_line_arguments[ 1 ] ) ;
      second_operand  =  atoi( command_line_arguments[ 2 ] ) ;

      print_calculations( first_operand, second_operand ) ;
   }
   else
   {
      cout << "\n This program can perform basic calculations."
           << "\n Give two integers separated by a space:  " ;

      cin  >> first_operand  >>  second_operand ;

      print_calculations( first_operand, second_operand ) ;
   }
}



