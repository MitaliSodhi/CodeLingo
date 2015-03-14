
using System ;

class Sum
{
   static void Main()
   {
      int  first_integer ;
      int  second_integer ;
      int  sum_of_two_integers ;

      Console.Write( "\n Please, type in an integer:      " ) ;
      first_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( "\n Please, type in another integer: " ) ;
      second_integer =  Convert.ToInt32( Console.ReadLine() ) ;

      sum_of_two_integers  =  first_integer  +  second_integer ;

      Console.Write( "\n The sum of the given integers is " +
                     sum_of_two_integers ) ;
   }
}




