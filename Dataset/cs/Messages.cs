
//  Messages.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;

class Messages
{
   static void print_message()
   {
      Console.Write( "\n   This is method named \"print_message()\"." ) ;
      Console.Write( "\n   Methods usually contain many statements. " ) ;
      Console.Write( "\n   Let us now return to the calling method." ) ;
   }

   static void Main()
   {
      Console.Write( "\n THE FIRST STATEMENT IN METHOD \"Main()\"." ) ;

      print_message() ;

      Console.Write( "\n THIS IS BETWEEN TWO METHOD CALLS." ) ;

      print_message() ;

      Console.Write( "\n END OF METHOD \"Main()\".\n" ) ;
   }
}



