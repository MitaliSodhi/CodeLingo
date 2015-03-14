
//  whilesum.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>
#include  <iomanip.h>

int main()
{
   int  integer_from_keyboard    =  -1 ;
   int  sum_of_integers          =   0 ;

   cout << "\n This program calculates the sum of integers you"
           "\n type in from the keyboard. By entering a zero you"
           "\n can terminate the program. \n\n" ;

   while ( integer_from_keyboard  !=  0 )
   {
      cout  <<  "  Current sum: "  <<  setw( 8 )  
            <<  sum_of_integers
            <<  "    Enter an integer: "  ;
      cin   >>  integer_from_keyboard ;
      sum_of_integers  =  sum_of_integers + integer_from_keyboard ;
   }
}



