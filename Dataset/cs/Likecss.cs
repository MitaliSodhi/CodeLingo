
//  Likecss.cs  (c) 2003 Kari Laitinen

//  03.04.2003  File created.
//  03.04.2003  Last modification.

using System ;

class Likecss
{
   static void Main()
   {
      char  character_from_keyboard ;

      Console.Write( "\n Do you like the C# programming language?" 
                  +  "\n Please, answer Y or N :  " ) ;

      character_from_keyboard  =  Convert.ToChar( Console.ReadLine() ) ;

      switch ( character_from_keyboard )
      {
      case  'Y':
      case  'y':
         Console.Write( "\n That's nice to hear. \n" ) ;
         break ;
      case  'N':
      case  'n':
         Console.Write( "\n That is not so nice to hear. "
                     +  "\n I hope you change your mind soon.\n" ) ;
         break ;
      default:
         Console.Write( "\n I do not understand \""
                     +  character_from_keyboard   +  "\".\n" ) ;
         break ;
      }
   }
}


