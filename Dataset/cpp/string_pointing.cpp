
//  string_pointing.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   char   string_from_keyboard[ 80 ] ;
   char*  character_in_string ;

   cout << "\n This program manipulates a string by using a"
           "\n pointer. Please, type in a string. \n\n   " ;

   cin.getline( string_from_keyboard,
                sizeof( string_from_keyboard ) ) ;

   character_in_string  =  string_from_keyboard ;

   while ( *character_in_string  !=  0 )
   {
      character_in_string  ++ ;
   }

   int  string_length   =   character_in_string  -
                                   string_from_keyboard ;

   cout << "\n String length is " << string_length << "."
        << "\n\n Here is the string in wide form: \n\n   " ;

   character_in_string  =  string_from_keyboard ;

   while ( character_in_string  <
                      string_from_keyboard  +  string_length )
   {
      cout  <<  *character_in_string  << " " ;
      character_in_string  ++  ;
   }

   cout << "\n\n Here is the string in reverse form: \n\n   ";

   while ( character_in_string  >  string_from_keyboard )
   {
      character_in_string  --  ;
      cout  <<  *character_in_string  ;
   }
}


