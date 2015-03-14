
//  toupper.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   char  character_from_keyboard ;

   cout << "\n\nThis program converts a sentence to"
        << "\nwide uppercase form. Please, type in"
        << "\na sentence.\n\n   " ;

   cin.get( character_from_keyboard ) ;
   cout << "\n  " ;

   while ( character_from_keyboard  !=  '\n' )
   {
      if ( character_from_keyboard  >=  'a'  &&
           character_from_keyboard  <=  'z' )
      {
         cout << " "  << (char) ( character_from_keyboard - 0x20 ) ;
      }
      else
      {
         cout << " "  <<  character_from_keyboard ;
      }
      cin.get( character_from_keyboard ) ;
   }
}
