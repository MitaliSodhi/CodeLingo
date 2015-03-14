
//  Elvis.cs  (c) 2003 Kari Laitinen

using System ;
using System.Text ;  // StringBuilder namespace

class Elvis
{
   static void Main()
   {
      string  character_positions  =      "0123456789012345678901" ;

      StringBuilder  elvis_sentence  =
                      new  StringBuilder( "Elvis was a rock star." ) ;

      Console.Write(   "\n   "  +  character_positions ) ;

      Console.Write( "\n\n   "  +  elvis_sentence  ) ;

      elvis_sentence[ 12 ]  =  'm' ;
      elvis_sentence[ 14 ]  =  'v' ;
      elvis_sentence[ 15 ]  =  'i' ;
      elvis_sentence[ 16 ]  =  'e' ;

      Console.Write( "\n\n   "  +  elvis_sentence  +  "\n" ) ;
   }
}



