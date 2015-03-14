
//  bank_better.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <string.h>

class  Bank_account
{
protected:
   char    account_owner[ 32 ] ;
   long    account_number ;
   double  account_balance ;

public:
   Bank_account( char    given_account_owner[],
                 long    given_account_number,
                 double  initial_balance  =  0 ) ;
   ~Bank_account() ;

   void  show_account_data() ;
   void  deposit_money(  double  amount_to_deposit ) ;
   void  withdraw_money( double  amount_to_withdraw ) ;

   void  transfer_money_to( Bank_account&  receiving_account,
                            double         amount_to_transfer ) ;
} ;


Bank_account::Bank_account( char    given_account_owner[],
                            long    given_account_number,
                            double  initial_balance )
{
   strcpy( account_owner, given_account_owner ) ;
   account_number   =  given_account_number ;
   account_balance  =  initial_balance  ;
}

Bank_account::~Bank_account()
{
   cout << "\n\nObject with owner name \"" << account_owner
        << "\" has been destroyed." ;
}

void
Bank_account::show_account_data()
{
   cout  <<  "\n\nB A N K   A C C O U N T   D A T A : "
         <<  "\n   Account owner :  "  <<  account_owner
         <<  "\n   Account number:  "  <<  account_number
         <<  "\n   Current balance: "  <<  account_balance ;
}

void
Bank_account::deposit_money( double amount_to_deposit )
{
   cout <<  "\n\nTRANSACTION FOR ACCOUNT OF " <<  account_owner
        <<  " (Account number " <<  account_number  << ")" ;
   cout <<  "\n   Amount deposited: "  <<  amount_to_deposit
        <<  "\n   Old account balance: "  <<  account_balance ;
   account_balance  =  account_balance  +  amount_to_deposit ;
   cout <<  "   New balance: "  <<  account_balance ;
}


void
Bank_account::withdraw_money( double amount_to_withdraw )
{
   cout <<  "\n\nTRANSACTION FOR ACCOUNT OF " <<  account_owner
        <<  " (Account number " <<  account_number  << ")" ;

   if ( account_balance  <  amount_to_withdraw )
   {
      cout << "\n   -- Transaction not completed: "
           << "Not enough money to withdraw " << amount_to_withdraw ;
   }
   else
   {
      cout << "\n   Amount withdrawn:    "  <<  amount_to_withdraw
           << "\n   Old account balance: "  <<  account_balance ;
      account_balance  =  account_balance  -  amount_to_withdraw ;
      cout << "   New balance: "  <<  account_balance ;
   }
}

void
Bank_account::transfer_money_to( Bank_account&  receiving_account,
                                 double         amount_to_transfer )
{
   cout <<  "\n\nTRANSACTION FOR ACCOUNT OF " <<  account_owner
        <<  " (Account number " <<  account_number  << ")" ;

   if ( account_balance  >=  amount_to_transfer )
   {

      receiving_account.account_balance  =
         receiving_account.account_balance  +  amount_to_transfer ;

      cout << "\n   " << amount_to_transfer << " was transferred to "
           << receiving_account.account_owner  <<  " (Account no. "
           << receiving_account.account_number <<  ")."
           << "\n   Balance before transfer: " <<  account_balance ;
      account_balance  =  account_balance  -  amount_to_transfer ;
      cout << "   New balance:  " <<  account_balance ;
   }
   else
   {
      cout << "\n   -- Not enough money for transfer." ;
   }
}
    

int main()
{
   Bank_account  jazz_player_account( "Louis Armstrong", 121212 ) ;
   Bank_account  moon_walker_account( "Neil Armstrong",  191919,
                                                         7777.77 ) ;
   jazz_player_account.deposit_money( 3333.33 ) ;

   jazz_player_account.withdraw_money( 4444.44 ) ;

   moon_walker_account.transfer_money_to( jazz_player_account,
                                          2222.22 ) ;

   moon_walker_account.show_account_data() ;
   jazz_player_account.show_account_data() ;
}


