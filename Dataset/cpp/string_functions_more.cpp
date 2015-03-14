
//  string_functions_more.cpp  (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <string.h>

int main()
{
   char  first_string[]   = "AAABBBCCCDDD" ;
   char  second_string[]  = "xxxyyyzzz" ;

   cout << "\n Original first_string  : " << first_string ;
   cout << "\n Original second_string : " << second_string ;
   strncpy( first_string, second_string, 5 ) ;
   cout << "\n Modified first_string  : " << first_string ;

   if ( strncmp( first_string, second_string, 5 ) == 0 )
   {
      cout << "\n The first 5 characters in both strings are the same" ;
   }

   if ( strstr( first_string, "CCCD" ) )
   {
      cout << "\n String \"" <<  first_string
           << "\"includes string \"CCCD\" in index position "
           << strstr( first_string, "CCCD" ) - first_string
           << ".\n" ;
   }
}



