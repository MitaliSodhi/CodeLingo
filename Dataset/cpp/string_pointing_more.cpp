
//  string_pointing_more.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <string.h>

int main()
{
   char   string_to_modify[]  =  "xxxxxYYYYYzzzzz" ;
   char*  character_in_string ;

   cout << "\n Original string:  " <<  string_to_modify ;

   character_in_string  =  string_to_modify  +  
                           strlen( string_to_modify ) - 1 ;
   *character_in_string          =  'A' ;
   *( character_in_string - 1 )  =  'B' ;

   cout << "\n Modified string:  " <<  string_to_modify ;

   character_in_string    =  string_to_modify  +  7  ;
   *character_in_string   =  '_' ;

   cout << "\n Modified string:  " <<  string_to_modify ;

   *( string_to_modify + 1 )  =  'C' ;
   *( string_to_modify + 2 )  =  'D' ;

   cout << "\n Modified string:  " <<  string_to_modify ;
}




