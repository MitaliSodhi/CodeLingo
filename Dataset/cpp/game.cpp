//  game.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   int  integer_from_keyboard ;
   int  one_larger_integer ;

   cout << "\n This program is a computer game. Please, type in "
        << "\n an integer in the range  1 ... 2147483646 : " ;

   cin  >>  integer_from_keyboard ;

   one_larger_integer  =  integer_from_keyboard  +  1 ;

   cout << "\n You typed in "  <<  integer_from_keyboard  <<  "."
        << "\n My number is "  <<  one_larger_integer     <<  "."
        << "\n Sorry, you lost. I won. The game is over. \n" ;
}



