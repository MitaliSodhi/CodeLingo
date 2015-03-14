
//  Additions.cs  (c) 2003 Kari Laitinen

using System ;

class Additions
{
   static void Main()
   {
      int  some_integer  =  1234 ;

      Console.Write( "\n " ) ;
      Console.Write( "xxxx" + some_integer + "zzzz" ) ;
      Console.Write( "\n " ) ;
      Console.Write( "xxxx" + some_integer + some_integer + "zzzz" ) ;
      Console.Write( "\n " ) ;
      Console.Write( "xxxx" + ( some_integer + some_integer ) + "zzzz" ) ;
      Console.Write( "\n " ) ;
      Console.Write( some_integer + some_integer + "xxxx" + "zzzz" ) ;
      Console.Write( "\n " ) ;
      Console.Write( some_integer + ( some_integer + "xxxx" ) + "zzzz" ) ;
      Console.Write( "\n " ) ;
      Console.Write( "xxxx" + "zzzz" + some_integer + ( some_integer + 1 ) ) ;
      Console.Write( "\n " ) ;
      Console.Write( "xxxx" + "zzzz" + some_integer + some_integer + 1 ) ;

   }
}



