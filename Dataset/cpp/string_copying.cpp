
//  string_copying.cpp  (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <string.h>

int main()
{
   char  string_to_modify[]     =  "ABCDEFGHIJK" ;
   char  string_to_be_copied[]  =  "1234567" ;

   cout << "\n Original string:  "  << string_to_modify  ;
   strcpy( string_to_modify, string_to_be_copied ) ;
   strcpy( string_to_modify, "abc" ) ;
   cout << "\n Modified string:  "  << string_to_modify << "\n" ;

   cout << hex  <<  "\n  LOCATION  CODE  CHARACTER  \n"  ;

   for ( int character_index  =  0 ;
             character_index  <  sizeof( string_to_modify ) ;
             character_index  ++ )
   {
      cout << "\n  " <<  (long) &string_to_modify[ character_index ]
           << "    " <<  ( int)  string_to_modify[ character_index ]
           << "    " <<          string_to_modify[ character_index ] ;
   }
}


