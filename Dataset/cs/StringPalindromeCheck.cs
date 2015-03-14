
//  StringPalindromeCheck.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-31  File created.
//  2004-10-31  Last modification.

//  A solutions to Exercise 8-5.

using System ;

class StringPalindromeCheck
{
   static void Main()
   {
      Console.Write( "\n Please, type in a string. \n\n    " ) ;

      string  given_string  =  Console.ReadLine() ;

      int  growing_index    =  0 ;
      int  shrinking_index  =  given_string.Length - 1 ;

      bool  given_string_is_a_palindrome  =  true ;

      while ( growing_index  <  shrinking_index )
      {
         if ( given_string[ growing_index ]  !=
              given_string[ shrinking_index ]  )
         {
            given_string_is_a_palindrome  =  false ;
         }

         growing_index    ++ ;
         shrinking_index  -- ;
      }

      if ( given_string_is_a_palindrome  ==  true )
      {
         Console.Write( "\n  The given string is a palindrome. \n " ) ;
      }
      else
      {
         Console.Write( "\n  The given string is not a palindrome. \n " ) ;
      }

      //  The following program lines use methods of classes string and
      //  Array to do the above checking. The given string is first
      //  coverted to an array of type char, then the array is reversed,
      //  and finally a string is created of the characters of the
      //  reversed array.

      Console.Write( "\n\n  The same test by using standard methods ... \n" ) ;

      char[] given_string_as_character_array  = 
                                            given_string.ToCharArray() ;

      Array.Reverse( given_string_as_character_array ) ;

      string  reversed_string  =  new  string(
                                    given_string_as_character_array ) ;

      Console.Write( "\n    Reversed string:  "  +  reversed_string ) ;
 
      if ( reversed_string  ==  given_string )
      {
         Console.Write( "\n\n  The given string is a palindrome. \n " ) ;
      }
      else
      {
         Console.Write( "\n\n  The given string is not a palindrome. \n " ) ;
      }

   }
}



