
//  bank_virtuals.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  "class_bank_account.h"

class  Account_with_credit  :  public  Bank_account
{
protected:
   double  credit_limit ;

public:
   Account_with_credit( char    given_accoung_owner[],
                        long    given_account_number,
                        double  initial_balance,
                        double  given_credit_limit  )

       : Bank_account( given_accoung_owner,
                       given_account_number,
                       initial_balance )
   {
      credit_limit  =  given_credit_limit ;
   }

   void  withdraw_money( double  amount_to_withdraw ) ;
} ;


void
Account_with_credit::withdraw_money( double amount_to_withdraw )
{
   cout <<  "\n\nTRANSACTION FOR ACCOUNT OF " <<  account_owner
        <<  " (Account number " <<  account_number  << ")" ;

   if ( account_balance  +  credit_limit  <  amount_to_withdraw )
   {
      cout << "\n   --  Transaction not completed: "
           << "Not enough credit to withdraw "<< amount_to_withdraw ;
   }
   else
   {
      cout << "\n   Amount withdrawn:    "  <<  amount_to_withdraw
           << "\n   Old account balance: "  <<  account_balance ;
      account_balance  =  account_balance  -  amount_to_withdraw ;
      cout << "   New balance: "  <<  account_balance ;
   }
}


class  Restricted_account  :  public  Bank_account
{
protected:
   double  maximum_amount_to_withdraw ;

public:
   Restricted_account( char    given_account_owner[],
                       long    given_account_number,
                       double  initial_balance,
                       double  given_withdrawal_limit  )

       : Bank_account( given_account_owner,
                       given_account_number,
                       initial_balance )
   {
      maximum_amount_to_withdraw  =  given_withdrawal_limit ;
   }

   void  withdraw_money( double  anount_to_withdraw ) ;

} ;

void
Restricted_account::withdraw_money( double amount_to_withdraw )
{
   if ( amount_to_withdraw  >  maximum_amount_to_withdraw )
   {
      cout <<  "\n\nTRANSACTION FOR ACCOUNT OF " <<  account_owner
           <<  " (Account number " <<  account_number  << ")" ;

      cout << "\n   -- Transaction not completed: Cannot withdraw "
           << amount_to_withdraw   << "\n   -- Withdrawal limit is "
           << maximum_amount_to_withdraw << "." ;
   }
   else
   {
      Bank_account::withdraw_money( amount_to_withdraw ) ;
   }
}

int main()
{
   Bank_account  beatles_account( "John Lennon", 222222, 2000.00 ) ;

   Account_with_credit  stones_account( "Brian Jones", 333333,
                                             2000.00,  1000.00 ) ;

   Restricted_account   doors_account( "Jim Morrison", 444444,
                                        4000.00,  1000.00 ) ;

   beatles_account.withdraw_money( 2500.00 ) ;
   stones_account.withdraw_money( 2500.00 ) ;
   doors_account.withdraw_money( 2500.00 ) ;
}


