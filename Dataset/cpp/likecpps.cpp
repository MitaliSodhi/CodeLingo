
//  likecpps.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   char  character_from_keyboard ;

   cout  <<  "\n Do you like the C++ programming language? " 
         <<  "\n Please, answer Y or N :  "  ;

   cin   >>  character_from_keyboard ;

   switch ( character_from_keyboard )
   {
   case  'Y':
   case  'y':
       cout  <<  "\n That's nice to hear. \n" ;
       break ;
   case  'N':
   case  'n':
       cout  <<  "\n That is not so nice to hear. "
             <<  "\n I hope you change your mind soon. \n " ;
       break ;
   default:   
       cout  <<  "\n I do not understand \""
             <<   character_from_keyboard   <<  "\".\n" ;
   }
}







