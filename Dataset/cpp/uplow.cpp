
//  uplow.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>

void  convert_string_uppercase( char given_string[] )
{
   int  character_index  =  0 ;

   while ( given_string[ character_index ]  !=  0 )
   {
      if ( given_string[ character_index ]  >=  'a'  &&
           given_string[ character_index ]  <=  'z'  )
      {
         given_string[ character_index ]  =  
                given_string[ character_index ]  &  0xDF ;
      }

      character_index  ++  ;
   }
}

int main()
{
   char  test_string[]  =  "Bjarne Stroustrup invented C++." ;

   cout << "\n String before conversion:  " << test_string ;

   convert_string_uppercase( test_string ) ;

   cout << "\n String after conversion:   " << test_string ;
}




