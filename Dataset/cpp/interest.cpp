
//  interest.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   float  compound_interest_table [ 3 ] [ 8 ]  =
   {
     { 5.00, 10.25, 15.76, 21.55, 27.63, 34.01, 40.71, 47.75 },
     { 6.00, 12.36, 19.10, 26.25, 33.82, 41.85, 50.36, 59.38 },
     { 7.00, 14.49, 22.50, 31.08, 40.26, 50.07, 60.58, 71.82 }
   } ;

   float  given_sum_of_money ;
   int    interest_percentage,  loan_period_in_years ;

   cout <<  "\n This program calculates the compound interest"
        <<  "\n for a given sum of money (principal). \n"
        <<  "\n  Give the loan amount: " ;
   cin  >>  given_sum_of_money ;

   cout <<  "\n  Give the interest percentage ( 5, 6, or 7): " ;
   cin  >>  interest_percentage ;

   cout <<  "\n  Give the loan period in years ( max. 8 ): " ;
   cin  >>  loan_period_in_years ;

   cout <<  "\n  For a loan of "  <<  given_sum_of_money 
        <<  " you must pay \n  "
        <<  ( given_sum_of_money / 100.0 ) *
            compound_interest_table[ interest_percentage - 5 ]
                                   [ loan_period_in_years - 1 ] 
        <<  " as compound interest after "
        <<  loan_period_in_years  <<  " years." ;
}


