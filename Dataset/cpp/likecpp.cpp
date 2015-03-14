
//  likecpp.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   char  character_from_keyboard ;

   cout  <<  "\n Do you like the C++ programming language? " 
         <<  "\n Please, answer Y or N :  "  ;

   cin   >>  character_from_keyboard ;

   if ( ( character_from_keyboard  ==  'Y' ) ||
        ( character_from_keyboard  ==  'y' ) )
   {
       cout  <<  "\n That's nice to hear. \n" ;
   }
   else if ( ( character_from_keyboard  ==  'N' ) ||
             ( character_from_keyboard  ==  'n' ) )
   {
       cout  <<  "\n That is not so nice to hear. "
             <<  "\n I hope you change your mind soon. \n " ;
   }
   else
   {
       cout  <<  "\n I do not understand \""
             <<   character_from_keyboard   <<  "\".\n" ;
   }
}


