
//  translate.cpp (c) 1999-2004 Kari Laitinen

#include  <iostream.h>
#include  <string>
#include  <vector>

class  Bilingual_translation
{
protected:
   string  first_word ;
   string  second_word ;

public:
   Bilingual_translation() {}
   Bilingual_translation( char  given_first_word[],
                          char  given_second_word[] )
   {
      first_word   =  given_first_word ;
      second_word  =  given_second_word ;
   }

   virtual bool translate( string& given_word ) ;
} ;


bool Bilingual_translation::translate( string& given_word )
{
   bool  translation_was_successful  =  false ;

   if ( given_word  ==  first_word )
   {
      cout << "\n \"" << given_word << "\" translates to \""
           << second_word  << "\"" ;

      translation_was_successful  =  true ;
   }

   if ( given_word  ==  second_word )
   {
      cout << "\n \"" << given_word << "\" translates to \""
           << first_word  <<  "\"" ;

      translation_was_successful  =  true ;
   }

   return  translation_was_successful ;
}


class  Trilingual_translation  :  public  Bilingual_translation
{
protected:
   string  third_word ;

public:
   Trilingual_translation( char  given_first_word[],
                           char  given_second_word[],
                           char  given_third_word[] )
   {
      first_word   =  given_first_word ;
      second_word  =  given_second_word ;
      third_word   =  given_third_word ;
   }

   bool translate( string& given_word ) ;
} ;

bool Trilingual_translation::translate( string& given_word )
{
   bool  translation_was_successful  =  false ;

   if ( given_word  ==  first_word )
   {
      cout << "\n \"" << given_word << "\" translates to \""
           << second_word  << "\" and \"" << third_word  << "\"" ;

      translation_was_successful  =  true ;
   }

   if ( given_word  ==  second_word )
   {
      cout << "\n \"" << given_word << "\" translates to \""
           << first_word  << "\" and \"" << third_word  << "\"" ;

      translation_was_successful  =  true ;
   }

   if ( given_word  ==  third_word )
   {
      cout << "\n \"" << given_word << "\" translates to \""
           << first_word  << "\" and \"" << second_word  << "\"" ;

      translation_was_successful  =  true ;
   }

   return  translation_was_successful ;
}


int main( int    number_of_command_line_arguments,
          char*  command_line_arguments[] )
{
   if ( number_of_command_line_arguments  ==  2 )
   {
      vector< Bilingual_translation* >  translation_table ;

      translation_table.push_back(
          new Bilingual_translation( "week", "semana" ) ) ;
      translation_table.push_back(
          new Trilingual_translation( "street", "calle", "rue" ) ) ;
      translation_table.push_back(
          new Bilingual_translation( "eat", "comer" ) ) ;
      translation_table.push_back(
          new Trilingual_translation( "woman", "mujer", "femme" ) ) ;
      translation_table.push_back(
          new Trilingual_translation( "man", "hombre", "homme" ) ) ;
      translation_table.push_back(
          new Bilingual_translation( "sleep", "dormir" ) ) ;

      unsigned int  translation_index  =  0 ;

      while ( translation_index  <  translation_table.size() )
      {
         translation_table[ translation_index ] ->

                       translate( command_line_arguments[ 1 ] ) ;

         delete  translation_table[ translation_index ] ;

         translation_index  ++  ;
      }

      cout << "\n" ;
   }
   else
   {
      cout << "\n Give a word on command line.\n\n" ;
   }
}


