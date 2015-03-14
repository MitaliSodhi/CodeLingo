
//  Interest.cs  (c) 2003 Kari Laitinen

using System ;

class Interest
{
   static void Main()
   {
      double[ , ]  compound_interest_table  =
      {
        { 5.00, 10.25, 15.76, 21.55, 27.63, 34.01, 40.71, 47.75 },
        { 6.00, 12.36, 19.10, 26.25, 33.82, 41.85, 50.36, 59.38 },
        { 7.00, 14.49, 22.50, 31.08, 40.26, 50.07, 60.58, 71.82 }
      } ;

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
                     compound_interest_table[ interest_percentage - 5,
                                              loan_period_in_years - 1 ] 
                  +  " as compound interest after "
                  +  loan_period_in_years  +  " years." ) ;
   }
}


