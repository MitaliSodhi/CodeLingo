
//  StringToUpperCase.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-31  File created.
//  2004-10-31  Last modification.

//  A solutions to Exercise 8-4.

using System ;

class StringToUpperCase
{
   static void Main()
   {
      Console.Write( "\n Please, type in a string. \n\n    " ) ;

      string  given_string  =  Console.ReadLine() ;

      Console.Write( "\n The given string in uppercase form: \n\n    " ) ;


      for ( int character_index  =  0 ;
                character_index  <  given_string.Length ;
                character_index  ++ )
      {
         if ( given_string[ character_index ]  >=  'a'  &&
              given_string[ character_index ]  <=  'z'  )
         {
            //  The result of a subtraction operation is of type int.
            //  Therefore, the conversion (char) is used below to convert
            //  the numerical value to a value of type char

            Console.Write( (char) (given_string[ character_index ] - 0x20) ) ;
         }
         else
         {
            Console.Write( given_string[ character_index ] ) ;
         }
      }

      //  An easier way to solve this problem is to use the
      //  ToUpper() string method in the following way.

      Console.Write(  "\n\n    "  +  given_string.ToUpper() ) ;
   }
}



