
//  stringadding.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>

#include  "class_simple_string.h"

int main()
{
   Simple_string  first_string( "xxAAAAAAAAxx" ) ;

   Simple_string  second_string( "yyBBBBBBBByy" ) ;

   Simple_string  third_string ;

   Simple_string  some_newlines( "\n\n" ) ;

   third_string  =  first_string  +  second_string ;

   cout  <<  some_newlines  <<  third_string ;

   third_string  =  some_newlines  +  third_string
                    +  third_string  +   some_newlines  ;

   cout  <<  third_string ;  
}






