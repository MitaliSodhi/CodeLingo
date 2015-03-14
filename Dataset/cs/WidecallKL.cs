
//  WidecallKL.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-05  File created.
//  2004-11-05  Last modification.

using System ;

class WidecallKL
{
   static void print_wide_string( string given_string )
   {
      // You must add program lines here!

      Console.Write( "\n   " ) ;

      for ( int character_index  =  0 ;
                character_index  <  given_string.Length ;
                character_index  ++ )
      {
         Console.Write( " "  +  given_string[ character_index ] ) ;
      }
   }

   static void Main()
   {
      string  example_string  =  "Hello, world." ;
      print_wide_string( example_string ) ;
   }
}



