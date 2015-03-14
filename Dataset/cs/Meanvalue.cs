
//  Meanvalue.cs  (c) 2003 Kari Laitinen

using System ;

class Meanvalue
{
   static void Main()
   {
      int   integer_from_keyboard     =  0 ;
      int   number_of_integers_given  = -1 ;
      float mean_value                =  0 ;
      int   sum_of_integers           =  0 ;

      Console.Write( "\n This program calculates the mean value of"
                  +  "\n the integers you enter from the keyboard."
                  +  "\n Please, start entering numbers. The program"
                  +  "\n stops when you enter a zero. \n\n" ) ;

      do
      {
         Console.Write( "   Enter an integer: " ) ;
         integer_from_keyboard  =  Convert.ToInt32( Console.ReadLine() );

         number_of_integers_given  ++  ;
         sum_of_integers  =  sum_of_integers + integer_from_keyboard ;
      }
        while  ( integer_from_keyboard  !=  0 ) ;

      if ( number_of_integers_given  >  0 )
      {
         mean_value  =  (float) sum_of_integers /
                        (float) number_of_integers_given ;
      }

      Console.Write( "\n The mean value is: " + mean_value + " \n" ) ;
   }
}




