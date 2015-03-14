
//  decorations.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <string.h>

void  multiprint_character( char character_from_caller,
                            int  number_of_times_to_repeat )
{
   int  repetition_counter  =  0 ;

   while ( repetition_counter  <  number_of_times_to_repeat )
   {
      cout  <<  character_from_caller ;
      repetition_counter  ++ ;
   }
}

void  print_text_in_decorated_box( char text_from_caller[] )
{
   int text_length  =  strlen( text_from_caller ) ;

   cout  << "\n " ;
   multiprint_character( '=',  text_length  +  8  ) ;
   cout  << "\n "  ;
   multiprint_character( '*',  text_length  +  8  ) ;
   cout  << "\n **" ;
   multiprint_character( ' ',  text_length  +  4  ) ;

   cout  << "**\n **  "  << text_from_caller << "  **\n **" ;

   multiprint_character( ' ',  text_length  +  4  ) ;
   cout  <<  "**\n " ;
   multiprint_character( '*',  text_length  +  8  ) ;
   cout  <<  "\n " ;
   multiprint_character( '=',  text_length  +  8  ) ;
   cout  <<  "\n " ;
}

int main()
{
   char  first_text[]  =  "Hello, world." ;

   print_text_in_decorated_box( first_text ) ;

   print_text_in_decorated_box(

         "I am a computer program written in C++.") ;
}


