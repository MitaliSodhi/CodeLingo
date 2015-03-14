
//  SumSolution_2_2.cs  (c) Kari Laitinen

//  http://www.naturalprogramming.com

using System ;

class SumSolution_2_2
{
   static void Main()
   {
      int  first_integer ;
      int  second_integer ;
      int  third_integer ;
      int  sum_of_three_integers ;

      Console.Write( "\n Please, type in an integer:      " ) ;
      first_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( "\n Please, type in another integer: " ) ;
      second_integer =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( "\n Please, type in a third integer: " ) ;
      third_integer =  Convert.ToInt32( Console.ReadLine() ) ;

      sum_of_three_integers  =  first_integer  +  second_integer  +
                                third_integer ;

      Console.Write( "\n " +  first_integer  +  " + "
                  +  second_integer  +  " +  "  +  third_integer
                  +  " = "  +  sum_of_three_integers ) ;
   }
}




