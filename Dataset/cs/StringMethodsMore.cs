
//  StringMethodsMore.cs  (c) 2003 Kari Laitinen

using System ;

class StringMethodsMore
{
   static void Main()
   {
      string  first_string   =  "AAABBBCCCDDD" ;
      string  second_string  =  "xxxyyyzzz" ;

      Console.Write( "\n CHARACTER POSITIONS    : 01234567890123456" ) ;
      Console.Write( "\n Original first_string  : " + first_string ) ;
      Console.Write( "\n Original second_string : " + second_string ) ;

      first_string  =  second_string.Substring( 0, 5 ) +
                                first_string.Substring( 5 ) ;
      Console.Write( "\n Modified first_string  : " + first_string ) ;


      if ( String.Compare( first_string,  0,
                           second_string, 0,  5 ) == 0 )
      {
         Console.Write(
          "\n The first five characters in both strings are the same" ) ;
      }

      if ( first_string.IndexOf( "CCCD" )  !=  -1 )
      {
         Console.Write( "\n String \"" +  first_string
              + "\"includes string \"CCCD\" in index position "
              + first_string.IndexOf( "CCCD" )  + ".\n" ) ;
      }
   }
}





