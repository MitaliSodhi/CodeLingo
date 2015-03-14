
//  elvis.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   char  character_positions[]  =  "0123456789012345678901" ;

   char  elvis_sentence[]       =  "Elvis was a rock star." ;

   cout  <<   "\n   "  <<  character_positions  ;

   cout  << "\n\n   "  <<  elvis_sentence  ;

   elvis_sentence[ 12 ]  =  'm' ;
   elvis_sentence[ 14 ]  =  'v' ;
   elvis_sentence[ 15 ]  =  'i' ;
   elvis_sentence[ 16 ]  =  'e' ;

   cout  << "\n\n   "  <<  elvis_sentence  <<  "\n" ;
}



