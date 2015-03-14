
//  truth.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   bool  true_boolean_variable   =  true ;
   bool  false_boolean_variable  =  false ;

   cout <<  "\n In C++, expressions are evaluated so that\n"
        <<  "\n   - a true  expression has value "
        <<  ( 99 ==  99 )
        <<  "\n   - a false expression has value "
        <<  ( 99 ==  88 )
        <<  "\n\n Boolean variables can have values"
        <<  "\n   - " << true_boolean_variable  << " means true "
        <<  "\n   - " << false_boolean_variable << " means false\n" ;
}



