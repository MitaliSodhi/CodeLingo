
//  ShowcodeKL.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-06  File created.
//  2004-11-06  Last modification.

using System ;

class ShowcodeKL
{
   static void Main( string[] command_line_parameters )
   {
      if ( command_line_parameters.Length  ==  1 )
      {
         //  The following statement takes the first character
         //  of the first command line parameter. Alternatively,
         //  you could use a statement like

         //  char  given_character  =  Convert.ToChar(
         //                               command_line_parameters[ 0 ] ) ;

         char given_character  =  command_line_parameters[ 0 ] [ 0 ] ;

         int  numerical_code   =  given_character ;

         Console.Write( "\n\n   The character code of "
                     +  given_character  +  " is "
                     +  numerical_code.ToString( "X" )  +  "H  ("
                     +  numerical_code  +  ")  \n" ) ;
      }
      else
      {
         Console.Write( "\n You must give a character from command line." ) ;
      }
   }
}



