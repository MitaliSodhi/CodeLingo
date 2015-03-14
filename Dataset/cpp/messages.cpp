
//  messages.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>

void  print_message()
{
   cout << "\n   This is function named \"print_message\"." ;
   cout << "\n   Functions usually contain many statements. " ;
   cout << "\n   Let us now return to the calling program." ;
}

int main()
{
   cout << "\n THIS IS THE FIRST STATEMENT IN FUNCTION \"main\"." ;

   print_message() ;

   cout << "\n THIS IS BETWEEN TWO FUNCTION CALLS." ;

   print_message() ;

   cout << "\n END OF FUNCTION \"main\".\n" ;
}



