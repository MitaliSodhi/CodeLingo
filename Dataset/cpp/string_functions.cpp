
//  string_functions.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>
#include  <string.h>

int main()
{
   char  name_of_user[ 40 ] ;
   char  first_part_of_sentence[]  = "\n This program shows you, ";
   char  third_part_of_sentence[]  = ", the string functions." ;

   char  sentence_to_screen[ 100 ] ;

   cout  <<  "\n Please, type in your name: " ;
   cin.getline( name_of_user, sizeof( name_of_user ) ) ;

   strcpy( sentence_to_screen, first_part_of_sentence ) ;
   strcat( sentence_to_screen, name_of_user ) ;
   strcat( sentence_to_screen, third_part_of_sentence ) ;

   cout  <<  sentence_to_screen  ;

   cout  <<  "\n\n By the way, your name has "
         <<  strlen( name_of_user )  <<  " characters. \n" ;
}



