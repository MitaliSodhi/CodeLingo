
//  StringCharactersCounted.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-30  File created.
//  2006-02-15  Last modification.

//  A solutions to Exercise 8-2.

using System ;

class StringCharactersCounted
{
   static void Main()
   {
      Console.Write( "\n Please, type in a string. \n\n    " ) ;

      string given_string  =  Console.ReadLine() ;

      int  number_of_unprintable_characters  =  0 ;
      int  number_of_digits              =  0 ;
      int  number_of_uppercase_letters   =  0 ;
      int  number_of_lowercase_letters   =  0 ;
      int  number_of_special_characters  =  0 ;

      for ( int character_index  =  0 ;
                character_index  <  given_string.Length ;
                character_index  ++ )
      {

         if ( given_string[ character_index ]  <  ' ' )
         {
            number_of_unprintable_characters  ++ ;
         }
         else if ( given_string[ character_index ] >= '0'  &&
                   given_string[ character_index ] <= '9' )
         {
            number_of_digits  ++ ;
         }
         else if ( given_string[ character_index ] >= 'A'  &&
                   given_string[ character_index ] <= 'Z' )
         {
            number_of_uppercase_letters  ++ ;
         }
         else if ( given_string[ character_index ] >= 'a'  &&
                   given_string[ character_index ] <= 'z' )
         {
            number_of_lowercase_letters  ++ ;
         }
         else
         {
            number_of_special_characters  ++ ;
         }
      }

      Console.Write( "\n The given string contains \n    "
                  +  number_of_unprintable_characters
                  +  " unprintable characters \n    "
                  +  number_of_digits  +  " digits \n    "
                  +  number_of_uppercase_letters
                  +  " uppercase letters \n    "
                  +  number_of_lowercase_letters
                  +  " lowercase letters \n    "
                  +  number_of_special_characters
                  +  " special characters \n    " ) ;
   }
}



