
//  argument.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>

void increment_variables( int   input_variable,
                          int&  output_variable )
{
   input_variable   ++ ;
   output_variable  ++ ;

   cout << "\ninput_variable  is in address "
        << &input_variable  << " and contains "
        << input_variable   << "." ;

   cout << "\noutput_variable is in address "
        << &output_variable  << " and contains "
        << output_variable   << ".\n" ;
}


int main()
{
   int  first_integer   =  222  ;
   int  second_integer  =  333  ;

   cout << "\nfirst_integer  is in address "
        << &first_integer   << " and contains "
        << first_integer    << "." ;

   cout << "\nsecond_integer is in address "
        << &second_integer   << " and contains "
        << second_integer    << ".\n" ;

   increment_variables( first_integer, second_integer ) ;

   cout << "\nVariables after call to increment_variables:\n";

   cout << "\nfirst_integer  contains " << first_integer ;
   cout << "\nsecond_integer contains " << second_integer ;

}



