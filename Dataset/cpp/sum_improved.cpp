
//  sum_improved.cpp (c) 1998-2002 Kari Laitinen

//  This is a simple calculator program that can
//  calculate the sum of the two integers that are
//  typed in from the keyboard.

#include  <iostream.h>

int main()
{
   int  first_integer_from_keyboard ;
   int  second_integer_from_keyboard ;
   int  sum_of_two_integers ;

   cout <<  "\n Please, type in two integers separated "
        <<  "with spaces:  " ;

   cin  >>  first_integer_from_keyboard
        >>  second_integer_from_keyboard ;

   sum_of_two_integers  =  first_integer_from_keyboard  +
                           second_integer_from_keyboard  ;

   cout <<  "\n The sum of "
        <<  first_integer_from_keyboard
        <<  " and "
        <<  second_integer_from_keyboard
        <<  " is "
        <<  sum_of_two_integers
        <<  "\n" ;
}


