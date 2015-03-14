
//  Translate.cs (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;
using System.Collections ;

class  BilingualTranslation
{
   protected string first_word ;
   protected string second_word ;

   public BilingualTranslation() {}

   public BilingualTranslation( string  given_first_word,
                                string  given_second_word )
   {
      first_word   =  given_first_word ;
      second_word  =  given_second_word ;
   }

   public virtual bool translate( string given_word )
   {
      bool  translation_was_successful  =  false ;

      if ( given_word.Equals( first_word ) )
      {
         Console.Write( "\n \"" + given_word + "\" translates to \""
                       + second_word  + "\"" ) ;

         translation_was_successful  =  true ;
      }

      if ( given_word.Equals( second_word ) )
      {
         Console.Write( "\n \"" + given_word + "\" translates to \""
                       + first_word  +  "\"" ) ;

         translation_was_successful  =  true ;
      }

      return  translation_was_successful ;
   }
}


class  TrilingualTranslation  :  BilingualTranslation
{
   protected string third_word ;

   public TrilingualTranslation( string given_first_word,
                                 string given_second_word,
                                 string given_third_word )
   {
      first_word   =  given_first_word ;
      second_word  =  given_second_word ;
      third_word   =  given_third_word ;
   }

   public override bool translate( string given_word )
   {
      bool  translation_was_successful  =  false ;

      if ( given_word.Equals( first_word ) )
      {
         Console.Write( "\n \"" + given_word + "\" translates to \""
                   + second_word  + "\" and \"" + third_word + "\"" ) ;

         translation_was_successful  =  true ;
      }

      if ( given_word.Equals( second_word ) )
      {
         Console.Write( "\n \"" + given_word + "\" translates to \""
                   + first_word  + "\" and \"" + third_word  + "\"" ) ;

         translation_was_successful  =  true ;
      }

      if ( given_word.Equals( third_word ) )
      {
         Console.Write( "\n \"" + given_word + "\" translates to \""
                   + first_word  + "\" and \"" + second_word  + "\"" ) ;

         translation_was_successful  =  true ;
      }

      return  translation_was_successful ;
   }
}

class Translate
{
   static void Main( string[]  command_line_parameters )
   {
      if ( command_line_parameters.Length  ==  1 )
      {
         ArrayList  array_of_translations  =  new  ArrayList() ;

         array_of_translations.Add(
             new BilingualTranslation( "week", "semana" ) ) ;
         array_of_translations.Add(
             new TrilingualTranslation( "street", "calle", "rue" ) ) ;
         array_of_translations.Add(
             new BilingualTranslation( "eat", "comer" ) ) ;
         array_of_translations.Add(
             new TrilingualTranslation( "woman", "mujer", "femme" ) ) ;
         array_of_translations.Add(
             new TrilingualTranslation( "man", "hombre", "homme" ) ) ;
         array_of_translations.Add(
             new BilingualTranslation( "sleep", "dormir" ) ) ;

         int  translation_index  =  0 ;

         while ( translation_index  <  array_of_translations.Count )
         {
            (  ( BilingualTranslation )
               array_of_translations[ translation_index ] ).

                       translate( command_line_parameters[ 0 ] ) ;

            translation_index  ++  ;
         }

         Console.Write( "\n" ) ;
      }
      else
      {
         Console.Write( "\n Give a word on command line.\n\n" ) ;
      }
   }
}



