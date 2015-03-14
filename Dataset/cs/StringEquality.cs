
//  StringEquality.cs  (c) 2003 Kari Laitinen

using System ;

class StringEquality
{
   static void Main()
   {
      string  first_string   =  "aaaaaa" ;
      string  second_string  =  "bbbbbb" ;

      Console.Write( "\n  " + first_string + "  " + second_string ) ;

      if ( first_string.Equals( second_string ) )
      {
         Console.Write( "\n     Equal string objects." ) ;
      }
      else
      {
         Console.Write( "\n     Not equal string objects." ) ;
      }

      if ( String.ReferenceEquals( first_string, second_string ) )
      {
         Console.Write( "\n     Referencing the same object." ) ;
      }
      else
      {
         Console.Write( "\n     Different objects referenced." ) ;
      }


      second_string  =  first_string ;

      Console.Write( "\n  " + first_string + "  " + second_string ) ;

      if ( first_string.Equals( second_string ) )
      {
         Console.Write( "\n     Equal string objects." ) ;
      }
      else
      {
         Console.Write( "\n     Not equal string objects." ) ;
      }

      if ( String.ReferenceEquals( first_string, second_string ) )
      {
         Console.Write( "\n     Referencing the same object." ) ;
      }
      else
      {
         Console.Write( "\n     Different objects referenced." ) ;
      }

      second_string  =  String.Copy( first_string ) ;

      Console.Write( "\n  " + first_string + "  " + second_string ) ;

      if ( first_string.Equals( second_string ) )
      {
         Console.Write( "\n     Equal string objects." ) ;
      }
      else
      {
         Console.Write( "\n     Not equal string objects." ) ;
      }

      if ( String.ReferenceEquals( first_string, second_string ) )
      {
         Console.Write( "\n     Referencing the same object." ) ;
      }
      else
      {
         Console.Write( "\n     Different objects referenced." ) ;
      }
   }
}



