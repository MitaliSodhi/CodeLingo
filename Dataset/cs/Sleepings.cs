
//  Sleepings.cs  (c) Kari Laitinen

//  http://www.naturalprogramming.com

//  2006-06-10  File created.
//  2006-06-10  Last modification.

//  This program is not presented in the C# book.

using System ;
using System.Threading ;

class Sleepings
{
   static void Main()
   {
      Console.Write( "\n  Let's first wait 5 seconds ... \n" ) ;

      Thread.Sleep( 5000 ) ;    //  5 s  =  5000 milliseconds

      Console.Write( "\n  Counting down ... \n\n" ) ;

      for ( int shrinking_number  =  10 ;
                shrinking_number  >=  0 ;
                shrinking_number  -- )
      {
         Thread.Sleep( 1000 ) ;  // 1 second pause.

         Console.Write( "    "  +  shrinking_number  +  "\u0007" ) ;
      }

      Console.Write( "\n\n" ) ;
   }
}





