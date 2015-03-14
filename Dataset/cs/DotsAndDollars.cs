
// DotsAndDollars.cs  (c) 2004 Kari Laitinen

using System ;
using System.Threading ;

class DotsAndDollars
{
   static void print_dots()
   {
      while ( true )
      {
         Thread.Sleep( 1000 ) ; // Wait one second.
         Console.Write( " ." ) ;
      }
   }

   static void print_dollar_signs()
   {
      while ( true )
      {
         Thread.Sleep( 4050 ) ; // Wait 4.05 seconds.
         Console.Write( " $" ) ;
      }
   }

   static void Main()
   {
      ThreadStart  method_for_thread_to_print_dots =
                                 new  ThreadStart( print_dots ) ;
      Thread thread_to_print_dots  =
               new Thread( method_for_thread_to_print_dots ) ;

      Thread thread_to_print_dollar_signs  =
               new Thread( new ThreadStart( print_dollar_signs ) ) ;

      thread_to_print_dots.Start() ;
      thread_to_print_dollar_signs.Start() ;

      Console.Write( "\n Press the Enter key to stop the program. \n\n" ) ;

      string  any_string_from_keyboard  =  Console.ReadLine() ;

      thread_to_print_dots.Abort() ;
      thread_to_print_dollar_signs.Abort() ;
   }
}


