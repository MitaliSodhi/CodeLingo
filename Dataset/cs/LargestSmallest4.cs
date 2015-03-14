
//  LargestSmallest4.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  Solution to the second tast of Exercise 6-1.

//  2004-10-28  File created.
//  2004-10-28  Last modification.

using System ;

class LargestSmallest4
{
   static void Main()
   {
      Console.Write( "\n This program can find the largest"
                  +  "\n and the smallest of four integers"
                  +  "\n you enter from the keyboard. \n\n") ;

      Console.Write( " Please, enter the first integer:  " ) ;
      int first_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( " Please, enter the second integer: " ) ;
      int second_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( " Please, enter the third integer:  " ) ;
      int third_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( " Please, enter the fourth integer: " ) ;
      int fourth_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      int found_largest_integer, found_smallest_integer ;

      if ( first_integer  >  second_integer )
      {
         found_largest_integer  =  first_integer ;
         found_smallest_integer =  second_integer ;
      }
      else
      {
         found_largest_integer  =  second_integer ;
         found_smallest_integer =  first_integer ;
      }

      if ( third_integer  >  found_largest_integer )
      {
         found_largest_integer  =  third_integer ;
      }

      if ( fourth_integer  >  found_largest_integer )
      {
         found_largest_integer  =  fourth_integer ;
      }

      if ( third_integer  <  found_smallest_integer )
      {
         found_smallest_integer  =  third_integer ;
      }

      if ( fourth_integer  <  found_smallest_integer )
      {
         found_smallest_integer  =  fourth_integer ;
      }

      Console.Write( "\n The largest integer is "
                  +  found_largest_integer  +  ".\n" ) ;
      Console.Write( "\n The smallest integer is "
                  +  found_smallest_integer  +  ".\n" ) ;
   }
}



