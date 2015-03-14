
//  pointer_simple.cpp  (c) 1998-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   int  first_integer   =  44, second_integer  =  66,
        third_integer   =  88 ;

   int*  pointer_to_integer ;

   cout << "\n Address of first_integer:  " << &first_integer
        << "\n Address of second_integer: " << &second_integer
        << "\n Address of third_integer:  " << &third_integer ;

   cout << "\n\n first   second  third   *pointer    pointer \n" ;

   pointer_to_integer   =  &first_integer ;

   cout << "\n   " <<  first_integer  << "     "<< second_integer
        << "       "  <<  third_integer 
        << "       "  <<  *pointer_to_integer
        << "       "  <<  pointer_to_integer ;

   second_integer         =  *pointer_to_integer ;
   *pointer_to_integer =  333 ;

   cout << "\n  " <<  first_integer  << "     " << second_integer
        << "       "  <<  third_integer 
        << "      "   <<  *pointer_to_integer
        << "       "  <<  pointer_to_integer ;

   pointer_to_integer  =  &third_integer ;
   *pointer_to_integer =  999 ;

   cout << "\n  " <<  first_integer  << "     " << second_integer
        << "      "   <<  third_integer 
        << "      "   <<  *pointer_to_integer
        << "       "  <<  pointer_to_integer  <<  "\n" ;
}



