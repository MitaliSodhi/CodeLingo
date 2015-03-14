
//  Iffing.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  03.04.2003  File created.
//  02.06.2004  Last modification.

//  The corresponding C++ program has the name ifascii.cpp

using System ;

class Iffing
{
   static void Main()
   {
      char  given_character ;

      Console.Write( "\n Please, type in a character:  " ) ;

      given_character  =  Convert.ToChar( Console.ReadLine() ) ;

      if ( given_character  <  ' ' )
      {
         Console.Write( "\n That is an unprintable character \n" ) ;
      }
      else if ( given_character >= '0'  &&  given_character <= '9' )
      {
         Console.Write( "\n You hit the number key "
                     +  given_character  +  ". \n " ) ;
      }
      else if ( given_character >= 'A'  &&  given_character <= 'Z' )
      {
         Console.Write( "\n "  +  given_character
                     +  " is an uppercase letter. \n" ) ; 
      }
      else if ( given_character >= 'a'  &&  given_character <= 'z' )
      {
         Console.Write( "\n "  +  given_character
                     +  " is a lowercase letter. \n" ) ; 
      }
      else
      {
         Console.Write( "\n "  +  given_character
                     +  " is a special character. \n" ) ;
      }
   }
}



