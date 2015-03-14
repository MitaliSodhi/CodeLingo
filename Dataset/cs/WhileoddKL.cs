
//  WhileoddKL.cs  (c) 2003 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-28  File created.
//  2004-11-05  Last modification.

//  Solution to Exercise 6-6.

using System ;

class WhileoddKL
{
   static void Main()
   {
      int  number_to_print  =  0 ;

      Console.Write( "\n Odd numbers from 0 to 20 are the following:\n\n ") ;

      while ( number_to_print  <= 20 )
      {
         if ( ( number_to_print % 2 )  ==  1 )
         {
            Console.Write( " "  +  number_to_print ) ;
         }
         
         number_to_print  ++  ;
      }

      Console.Write( "\n\n Another solution to the problem ... \n\n ") ;

      number_to_print  =  1 ;

      while ( number_to_print  <= 20 )
      {
         Console.Write( " "  +  number_to_print ) ;
         
         number_to_print  =  number_to_print  +  2 ;  ;
      }
   }
}



