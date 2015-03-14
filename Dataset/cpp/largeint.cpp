//  largeint.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   int  first_integer,  second_integer,  third_integer ;
   int  found_largest_integer ;

   cout <<  "\n This program can find the largest of three"
        <<  "\n integers you enter from the keyboard."
        <<  "\n Please, enter three integers:  " ;

   cin  >>  first_integer >> second_integer >> third_integer ;

   if ( first_integer  >  second_integer )
   {
      found_largest_integer  =  first_integer ;
   }
   else
   {
      found_largest_integer  =  second_integer ;
   }

   if ( third_integer  >  found_largest_integer )
   {
      found_largest_integer  =  third_integer ;
   }

   cout  <<  "\n The largest integer is "
         <<  found_largest_integer  <<  ".\n" ;
}


