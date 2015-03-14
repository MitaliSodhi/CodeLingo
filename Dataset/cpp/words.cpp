
//  words.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   char  character_in_sentence ;

   cout << "\n This program separates the words of a sentence and"
        << "\n prints them in wide form. Type in a sentence.\n\n   ";

   cin.get( character_in_sentence ) ;
   cout << "\n  " ;

   while ( character_in_sentence  !=  '\n' )
   {
      if ( character_in_sentence  ==  ' ' )
      {
          cout  <<  "\n  " ;
      }
      else
      {
          cout  <<  " "  <<  character_in_sentence ;
      }
      cin.get( character_in_sentence ) ;
   }
}



