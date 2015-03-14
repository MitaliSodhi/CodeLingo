
//  Codefinder.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-29  File created.
//  2004-10-29  Last modification.

using System ;

class Codefinder
{
   static void Main()
   {
      Console.Write( "\n This program can find character codes"
                  +  "\n of different characters. The program"
                  +  "\n stops when you enter the percent sign %.\n\n ");

      char  character_from_keyboard  =  '?' ;

      while ( character_from_keyboard  !=  '%' )
      {
         Console.Write( "   Give a character "  ) ;

         character_from_keyboard  =  Convert.ToChar( Console.ReadLine() ) ;

         int  character_code  =  character_from_keyboard ;

         Console.Write( "   Code of "  +  character_from_keyboard
                     +  " is  "  +  character_code.ToString().PadLeft( 4 )
                     +  "  ("
                     +  character_code.ToString( "X" ) +  " hexadecimal)" ) ;
      }
   }
}



