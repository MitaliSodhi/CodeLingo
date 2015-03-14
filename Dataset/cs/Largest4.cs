
//  Largest4.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  This program is a solution to the first task of Exercise 6-1.
//  The solution to the second task is in file
//  LargestSmallest4.cs.

//  2004-10-28  File created.
//  2004-10-28  Last modification.

using System ;

class Largest4
{
   static void Main()
   {
      Console.Write( "\n This program can find the largest of four"
                  +  "\n integers you enter from the keyboard. \n\n") ;

      Console.Write( " Please, enter the first integer:  " ) ;
      int first_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( " Please, enter the second integer: " ) ;
      int second_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( " Please, enter the third integer:  " ) ;
      int third_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( " Please, enter the fourth integer: " ) ;
      int fourth_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      int found_largest_integer ;

      if ( first_integer  >  second_integer )
      {
         found_largest_integer  =  first_integer ;
      }
      else
      {
         found_largest_integer  =  second_integer ;
      }

      if ( third_integer  >  found_largest_integer )
      {
         found_largest_integer  =  third_integer ;
      }

      if ( fourth_integer  >  found_largest_integer )
      {
         found_largest_integer  =  fourth_integer ;
      }

      Console.Write( "\n The largest integer is "
                  +  found_largest_integer  +  ".\n" ) ;
   }
}



