
//  WhilesumSolution_6_7.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-28  File created.
//  2004-10-28  Last modification.

using System ;

class WhilesumSolution_6_7
{
   static void Main()
   {
      int  integer_from_keyboard   =  -1 ;
      int  sum_of_integers         =   0 ;
      int  number_of_integers_given  =  0 ;

      Console.Write( "\n This program calculates the sum of the integers"
                   + "\n you type in from the keyboard. By entering a"
                   + "\n zero you can terminate the program. \n\n" ) ;

      while ( integer_from_keyboard  !=  0  &&
              number_of_integers_given  <  10 )
      {
         Console.Write( "  Current sum: "
                     +  sum_of_integers.ToString().PadLeft( 8 )
                     +  "    Enter an integer: " ) ;

         integer_from_keyboard  = Convert.ToInt32( Console.ReadLine() );

         sum_of_integers  =  sum_of_integers + integer_from_keyboard ;
         
         number_of_integers_given   ++  ;
         
         if ( number_of_integers_given  ==  10 )
         {
            Console.Write( "\n You have given 10 integers. "
                        +  "\n That terminates this program. \n\n" ) ;
            Console.Write( "  Final sum:   "
                     +  sum_of_integers.ToString().PadLeft( 8 ) ) ;
         }
      }
   }
}


