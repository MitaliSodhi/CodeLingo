
//  fullname.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   char  first_name[ 40 ] ;
   char  last_name [ 40 ] ;

   cout <<  "\n Please, type in your first name: " ;
   cin  >>  first_name ;
   cout <<  "\n Please, type in your last name:  " ;
   cin  >>  last_name ;

   cout <<  "\n Your full name is "
        <<  first_name  <<  " "  <<  last_name  <<  ".\n" ;
}


