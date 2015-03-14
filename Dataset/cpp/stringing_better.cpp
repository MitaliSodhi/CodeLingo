
//  stringing_better.cpp (c) 2000-2004 Kari Laitinen

//  This program works in the same way as stringing.cpp
//  but this one includes the file <iostream> instead of
//  <iostream.h> and there is the appropriate using statement.
//  This program can probably be compiled with a wider range of
//  of C++ compilers as this is a more standard C++ program.

#include  <iostream>
#include  <string>    // class string etc.

using namespace std ;

int main()
{
   string  abcdefgh_string( "abcdefgh" ) ;

   string  xxxxxxxx_string( 8, 'x' ) ;

   string  defgzzzz_string( abcdefgh_string, 3, 4 ) ;

   defgzzzz_string  =  defgzzzz_string  +  "zzzz" ;

   string  text_to_print  =  "  "  +  abcdefgh_string  +
                             "  "  +  xxxxxxxx_string  +
                             "  "  +  defgzzzz_string  +  "  " ;
   cout  <<  "\n"  ;

   for ( int character_index  =  0  ;
             character_index  <  text_to_print.length() ;
             character_index  ++ )
   {
      cout  <<  text_to_print[ character_index ] ;
   }


   cout  <<  "\n\n"  ;

   string::iterator  character_in_text ;

   character_in_text  =  text_to_print.begin() ;

   while ( character_in_text  !=  text_to_print.end() )
   {
      cout  <<  " "  <<  *character_in_text  ;

      character_in_text  ++  ;
   }

   cout  <<  "\n" ;

   character_in_text  =  text_to_print.end() ;

   while ( character_in_text  >  text_to_print.begin() )
   {
      character_in_text  --  ;

      cout  <<  " "  <<  *character_in_text  ;
   }
}



