
//  MeanvalueSolution_6_8.cs  (c) 2003 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-29  File created.
//  2004-10-29  Last modification.

using System ;

class MeanvalueSolution_6_8
{
   static void Main()
   {
      int   integer_from_keyboard     =  0 ;
      int   number_of_integers_given  =  0 ;
      float mean_value                =  0 ;
      int   sum_of_integers           =  0 ;

      Console.Write( "\n This program calculates the mean value of"
                  +  "\n the integers you enter from the keyboard."
                  +  "\n Please, start entering numbers. The program"
                  +  "\n stops when you enter a zero. \n\n" ) ;

      do
      {
         Console.Write(  "  Current mean value: "
                     +   mean_value.ToString().PadLeft( 10 ) 
                     +   "   Enter an integer: " ) ;

         integer_from_keyboard  =  Convert.ToInt32( Console.ReadLine() );

         sum_of_integers  =  sum_of_integers + integer_from_keyboard ;

         number_of_integers_given  ++  ;

         mean_value  =  (float) sum_of_integers /
                        (float) number_of_integers_given ;

      }
        while  ( integer_from_keyboard  !=  0 ) ;

   }
}




