
//  ifascii.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   char  character_code ;

   cout  <<  "\n Please, type in a character:  "  ;

   cin   >>  character_code  ;

   if ( character_code  <  ' ' )
   {
      cout  <<  "\n That is an unprintable character \n" ;
   }
   else if ( character_code >= '0'  &&  character_code <= '9' )
   {
      cout  <<  "\n You hit the number key "
            <<  character_code  <<  ". \n " ;
   }
   else if ( character_code >= 'A'  &&  character_code <= 'Z' )
   { 
      cout  <<  "\n "  <<  character_code
            <<  " is an uppercase letter. \n"  ; 
   }
   else if ( character_code >= 'a'  &&  character_code <= 'z' )
   {
      cout  <<  "\n "  <<  character_code
            <<  " is a lowercase letter. \n"  ; 
   }
   else
   {
      cout  <<  "\n "  <<  character_code
            <<  " is a special character. \n" ;
   }
}




