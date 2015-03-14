
//  bank_simple.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <string.h>

class  Bank_account
{
protected:
   char    account_owner[ 32 ] ;
   long    account_number ;
   double  account_balance ;

public:
   void  initialize_account( char  given_name[],
                             long  given_account_number ) ;

   void  show_account_data() ;
   void  deposit_money( double  amount_to_deposit ) ;
} ;


void
Bank_account::initialize_account( char  given_name[],
                                  long  given_account_number )
{
   strcpy( account_owner, given_name ) ;
   account_number   =  given_account_number ;
   account_balance  =  0  ;
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

int main()
{
   Bank_account  first_account ;
   Bank_account  second_account ;

   first_account.initialize_account(  "James Bond", 77007007 ) ;
   second_account.initialize_account( "Philip Marlowe", 22003004 ) ;

   first_account.deposit_money(  5566.77 ) ;
   second_account.deposit_money( 9988.77 ) ;
   first_account.deposit_money(  2222.11 ) ;

   first_account.show_account_data() ;
   second_account.show_account_data() ;
}



