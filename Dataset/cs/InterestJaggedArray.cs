
//  InterestJaggedArray.cs  (c) 2003 Kari Laitinen

//  This program works in the same way as Interest.cs.
//  The difference between this program and Interest.cs is
//  that the array compound_interest_table is implemented
//  as a jagged array in this program.

//  A jagged array is an array of arrays. Each row of a jagged
//  array can be created separately, and the rows do not need
//  to have the same size. The rows in the compound_interest_table
//  of this program are not of equal size. Therefore, this program
//  can calculate "more interest" that program Interest.cs.

using System ;

class InterestJaggedArray
{
   static void Main()
   {
      double[][]  compound_interest_table  =  new  double [ 3 ] [] ;

      compound_interest_table[ 0 ]  =  new  double[ 8 ]
        { 5.00, 10.25, 15.76, 21.55, 27.63, 34.01, 40.71, 47.75 } ;

      compound_interest_table[ 1 ]  =  new  double[ 10 ]
        {  6.00, 12.36, 19.10, 26.25, 33.82, 41.85, 50.36, 59.38,
          68.95, 79.08 } ;

      compound_interest_table[ 2 ]  =  new  double[ 9 ]
        {  7.00, 14.49, 22.50, 31.08, 40.26, 50.07, 60.58, 71.82,
          83.85 } ;

      double given_sum_of_money ;
      int    interest_percentage,  loan_period_in_years ;

      Console.Write( "\n This program calculates the compound interest"
                  +  "\n for a given sum of money (principal). \n"
                  +  "\n  Give the loan amount: " ) ;
      given_sum_of_money  =  Convert.ToDouble( Console.ReadLine() ) ;

      Console.Write( "\n  Give the interest percentage (5, 6, or 7): ");
      interest_percentage  =  Convert.ToInt32( Console.ReadLine() );

      Console.Write( "\n  Give the loan period in years (max. 8): ") ;
      loan_period_in_years  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( "\n  For a loan of "  +  given_sum_of_money 
                  +  " you must pay \n  "
                  +  ( given_sum_of_money / 100.0 ) *
                     compound_interest_table[ interest_percentage - 5 ]
                                            [ loan_period_in_years - 1 ] 
                  +  " as compound interest after "
                  +  loan_period_in_years  +  " years." ) ;
   }
}


