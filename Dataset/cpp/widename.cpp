
//  widename.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   char  name_from_keyboard[ 80 ] ;
   int   character_index  =  0 ;

   cout << "\n Please, type in your name: " ;
   cin.getline( name_from_keyboard, 80 ) ;

   cout << "\n Here is your name in a wider form: \n\n  " ;

   while ( name_from_keyboard[ character_index ]  !=  0 )
   {
      cout  <<  " "  <<  name_from_keyboard[ character_index ] ;
      character_index  ++  ;
   }
}


