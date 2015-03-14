//  oddbit.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   int integer_from_keyboard ;

   cout << "\n\nThis program can find out whether an integer"
           "\nis odd or even. Please, enter an integer: " ;

   cin  >>  integer_from_keyboard ;

   int least_significant_bit  =  integer_from_keyboard  &  0x0001 ;

   if ( least_significant_bit  ==  0 )
   {
      cout  <<  "\n"  <<  integer_from_keyboard  <<  " is even.\n";
   }
   else
   {
      cout  <<  "\n"  <<  integer_from_keyboard  <<  " is odd. \n";
   }
}


