
//  MilesToKilometersTable.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-29  File created.
//  2004-10-29  Last modification.

//  Solution to exercise 6-9.

using System ;

class MilesToKilometersTable
{
   static void Main()
   {
      double  distance_in_miles  =  10 ;

      double  distance_in_kilometers ;

      Console.Write(  "\n       miles     kilometers  \n"  ) ;

      while ( distance_in_miles  <  160 )
      {
         distance_in_kilometers  =  1.6093 * distance_in_miles ;


         Console.Write( "\n {0, 10:f0}  {1, 10:f2}",
                        distance_in_miles, distance_in_kilometers ) ;

         distance_in_miles  =  distance_in_miles  +  10 ;
      }
   }
}


