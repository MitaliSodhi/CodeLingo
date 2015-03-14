
//  threeint.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   int   first_integer_from_keyboard ;
   int   second_integer_from_keyboard ;
   int   third_integer_from_keyboard ;
   int   sum_of_three_integers, product_of_three_integers ;

   cout  <<  "\nThis program can calculate sum and product of three"
         <<  "\nintegers. Please, enter three integers from keyboard."
         <<  "\nSeparate the integers with spaces and press <Enter>"
         <<  "\nafter the last integer: " ;

   cin   >>  first_integer_from_keyboard
         >>  second_integer_from_keyboard 
         >>  third_integer_from_keyboard  ;

   sum_of_three_integers  =  first_integer_from_keyboard  +
                             second_integer_from_keyboard  +
                             third_integer_from_keyboard ;

   product_of_three_integers  =  first_integer_from_keyboard  *
                                 second_integer_from_keyboard  *
                                 third_integer_from_keyboard ;

   cout  <<  "\nThe sum of "  <<  first_integer_from_keyboard  << ", "  
         <<  second_integer_from_keyboard  <<  ", and "
         <<  third_integer_from_keyboard   <<  " is "
         <<  sum_of_three_integers         <<  ". Their product is "
         <<  product_of_three_integers     <<  "." ;
}



