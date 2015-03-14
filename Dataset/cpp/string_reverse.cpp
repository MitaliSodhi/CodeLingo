
//  string_reverse.cpp   (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   char  string_from_keyboard[ 80 ] ;
   int   character_index   =  0 ;

   cout << "\n This program is able to reverse a string."
           "\n Please, type in a string.\n\n   " ;

   cin.getline( string_from_keyboard,
                sizeof( string_from_keyboard ) ) ;

   while ( string_from_keyboard[ character_index ]  !=  0 )
   {
      character_index  ++  ;
   }

   cout << "\n String length is " <<  character_index << "."
        << "\n\n String in reverse character order: \n\n   " ;

   while (  character_index  >  0  )
   {
      character_index  --  ;
      cout  <<  string_from_keyboard[ character_index ] ;
   }
}



