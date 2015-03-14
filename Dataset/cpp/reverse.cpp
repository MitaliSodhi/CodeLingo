
//  reverse.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   int  array_of_integers[ 100 ] ;
   int  integer_index              =  0  ;
   int  integer_from_keyboard      =  0  ;

   cout <<  "\n This program reads integers from the keyboard and,"
        <<  "\n after receiving a zero, it prints the numbers"
        <<  "\n in reverse order. Please, start entering numbers."
        <<  "\n The program will stop when you enter a zero.\n\n" ;
   do
   {
      cout  <<  " "  <<  integer_index  <<  "  Enter an integer: " ;
      cin   >>  integer_from_keyboard ;

      array_of_integers[ integer_index ]  =  integer_from_keyboard ;
      integer_index  ++ ;
   }
      while  ( integer_from_keyboard  !=  0 ) ;

   cout  << "\n Reverse order:  " ;

   while  ( integer_index  >  0 )
   {
      integer_index  -- ;
      cout  <<  array_of_integers[ integer_index ]  <<  "   " ;
   } 
}


