
//  Sentence.cs  (c) 2003 Kari Laitinen

//  This program is included among other programs because
//  there is the corresponding C++ program called sentence.cpp
//  The purpose of that program is to demonstrate the nature
//  of the switch-case construct in C++. Because switch-case
//  is different in C#, there is no need to have this program
//  discussed in the C# book.

using System ;

class Sentence
{
   static void Main()
   {
      char  character_from_keyboard ;

      Console.Write( "\n Type in L, M, or S, depending on whether you want" 
                   + "\n a long, medium, or short sentence displayed:  " ) ;

      character_from_keyboard  =  Convert.ToChar( Console.ReadLine() ) ;
      character_from_keyboard  =  (char) (character_from_keyboard  &  0xDF) ;

      Console.Write( "\n This is a" ) ;

      switch ( character_from_keyboard )
      {
      case  'L':
         Console.Write( " switch statement in a \n" ) ;
         Console.Write( " program in a" ) ;
         Console.Write( " book that teaches C# programming." ) ; 
         Console.Write( "\n I hope that this is an interesting book.\n" ) ;
         break ;
      case  'M':
         Console.Write( " program in a" ) ;
         Console.Write( " book that teaches C# programming." ) ; 
         Console.Write( "\n I hope that this is an interesting book.\n" ) ;
         break ;
      case  'S':
         Console.Write( " book that teaches C# programming." ) ; 
         Console.Write( "\n I hope that this is an interesting book.\n" ) ;
         break ;
      default: 
         Console.Write( "\n I hope that this is an interesting book.\n" ) ;
         break ;
      }
   }
}





