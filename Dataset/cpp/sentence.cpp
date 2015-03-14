
//  sentence.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   char  character_from_keyboard ;

   cout << "\n Type in L, M, or S, depending on whether you want" 
        << "\n a long, medium, or short sentence displayed:  "  ;

   cin  >>  character_from_keyboard ;
   character_from_keyboard   =  character_from_keyboard  & 0xDF ;

   cout << "\n This is a" ;

   switch ( character_from_keyboard )
   {
   case  'L':
      cout  <<  " switch statement in a \n" ;
   case  'M':
      cout  <<  " program in a" ;
   case  'S':
      cout  <<  " book that teaches C++ programming." ; 
   default: 
      cout  <<  "\n I hope that this is an interesting book.\n" ;
   }
}



