
//  sums.cpp (c) 1998-2002 Kari Laitinen

/*  Note that is different program than sum.cpp
    which is discussed in the beginning of the book.
    So if you by accident found this program while
    trying to find sum.cpp, keep searching. This is
    not the correct program in the beginning of
    your studies.
*/

#include  <iostream.h>

void  print_sum( int first_integer_from_caller,
                 int second_integer_from_caller )
{
   int calculated_sum ;

   calculated_sum  =  first_integer_from_caller  +
                      second_integer_from_caller ;

   cout << "\n The sum of " << first_integer_from_caller
        << " and "  <<  second_integer_from_caller
        << " is "   <<  calculated_sum  << ".\n" ;
}

int main()
{
   int  first_integer,  second_integer ;

   print_sum( 555, 222 ) ;

   cout << "\n As you can see, this program can print"
        << "\n the sum of two integers. Please, type in"
        << "\n two integers separated with a space:\n\n " ;

   cin  >>  first_integer  >>  second_integer ;

   print_sum( first_integer, second_integer ) ;
}



