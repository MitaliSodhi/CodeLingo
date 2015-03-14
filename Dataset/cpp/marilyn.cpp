
//  marilyn.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>
#include  <string.h>

int main()
{
   char  name_to_be_known[]  =  "Marilyn Monroe" ;
   char  name_from_keyboard[ 40 ] ;

   cout <<  "\n Who played a main role in movies:"
        <<  "\n\n   \"How To Marry a Millionaire\" (1953)"
        <<    "\n   \"The Seven Year Itch\" (1955)"
        <<    "\n   \"The Misfits\" (1961) \n\n   ? " ;

   cin.getline( name_from_keyboard, sizeof( name_from_keyboard ) ) ;

   if ( strcmp( name_from_keyboard, name_to_be_known ) == 0 )
   {
      cout  <<  "\n   Yes, that is correct.\n" ;
   }
   else
   {
      cout  <<  "\n   No, it\'s Marilyn Monroe.\n" ;
   }
}



