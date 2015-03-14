//  evenodd.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   int  integer_from_keyboard ;

   cout << "\n This program can find out whether an integer"
           "\n is even or odd. Please, enter an integer: " ;

   cin  >>  integer_from_keyboard ;

   if ( ( integer_from_keyboard  %  2 )  ==  0 )
   {
      cout  <<  "\n "  <<  integer_from_keyboard  <<  " is even.\n";
   }
   else
   {
      cout  <<  "\n "  <<  integer_from_keyboard  <<  " is odd. \n";
   }
}



