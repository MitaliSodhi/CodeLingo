
//  Likecs.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;

class Likecs
{
   static void Main()
   {
      char  character_from_keyboard ;

      Console.Write( "\n Do you like the C# programming language?" 
                  +  "\n Please, answer Y or N :  " ) ;

      character_from_keyboard  =  Convert.ToChar( Console.ReadLine() ) ;

      if ( ( character_from_keyboard  ==  'Y' ) || 
           ( character_from_keyboard  ==  'y' ) )
      {
         Console.Write( "\n That's nice to hear. \n" ) ;
      }
      else if ( ( character_from_keyboard  ==  'N' ) ||
                ( character_from_keyboard  ==  'n' ) )
      {
         Console.Write( "\n That is not so nice to hear. "
                     +  "\n I hope you change your mind soon.\n" ) ;
      }
      else
      {
         Console.Write( "\n I do not understand \""
                     +  character_from_keyboard   +  "\".\n" ) ;
      }
   }
}





