
//  SumWithInt32Parse.cs  Copyright 2004 Kari Laitinen

//  www.naturalprogramming.com

//  This program works like Sum.cs.
//  Method Int32.Parse() is used in place of Convert.ToInt32()

using System ;

class SumWithInt32Parse
{
   static void Main()
   {
      int  first_integer ;
      int  second_integer ;
      int  sum_of_two_integers ;

      Console.Write( "\n Please, type in an integer:      " ) ;
      first_integer  =  Int32.Parse( Console.ReadLine() ) ;

      Console.Write( "\n Please, type in another integer: " ) ;
      second_integer =  Int32.Parse( Console.ReadLine() ) ;

      sum_of_two_integers  =  first_integer  +  second_integer ;

      Console.Write( "\n The sum of the given integers is " +
                     sum_of_two_integers ) ;
   }
}




