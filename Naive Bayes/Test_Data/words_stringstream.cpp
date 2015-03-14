
//  words_stringstream.cpp  (c) 2001-2002 Kari Laitinen

#include  <iostream.h>
#include  <sstream>
#include  <string>

int main()
{
   string  sentence_from_keyboard ;

   cout << "\n This program separates the words of a sentence and"
        << "\n prints them on different lines. Type in a sentence.\n\n   ";

   getline( cin, sentence_from_keyboard ) ;

   stringstream  sentence_as_stream ;

   sentence_as_stream  <<  sentence_from_keyboard ;

   string  word_of_sentence ;

   while ( sentence_as_stream  >>  word_of_sentence )
   {
      cout  <<  "\n  "  <<  word_of_sentence ;
   }
}



