
//  BankBetter.cs  (c) 2003 Kari Laitinen

//  www.naturalprogramming.com

using System ;

class  BankAccount
{
   string  account_owner ;
   long    account_number ;
   double  account_balance ;

   public BankAccount( string  given_account_owner,
                       long    given_account_number,
                       double  initial_balance )
   {
      account_owner    =  given_account_owner ;
      account_number   =  given_account_number ;
      account_balance  =  initial_balance  ;
   }

   public void show_account_data()
   {
      Console.Write( "\n\nB A N K   A C C O U N T   D A T A : "
                  +  "\n   Account owner :  "  +  account_owner
                  +  "\n   Account number:  "  +  account_number
                  +  "\n   Current balance: "  +  account_balance ) ;
   }

   public void deposit_money( double amount_to_deposit )
   {
      Console.Write( "\n\nTRANSACTION FOR ACCOUNT OF " +  account_owner
                  +  " (Account number " +  account_number  + ")" ) ;
      Console.Write( "\n   Amount deposited: "  +  amount_to_deposit
                  +  "\n   Old account balance: "  +  account_balance ) ;
      account_balance  =  account_balance  +  amount_to_deposit ;
      Console.Write( "   New balance: "  +  account_balance  ) ;
   }

   public void withdraw_money( double amount_to_withdraw )
   {
      Console.Write( "\n\nTRANSACTION FOR ACCOUNT OF " +  account_owner
                  +  " (Account number " +  account_number  + ")" ) ;

      if ( account_balance  <  amount_to_withdraw )
      {
         Console.Write("\n   -- Transaction not completed: "
                + "Not enough money to withdraw " + amount_to_withdraw ) ;
      }
      else
      {
         Console.Write("\n   Amount withdrawn:    "  +  amount_to_withdraw
                     + "\n   Old account balance: "  +  account_balance ) ;
         account_balance  =  account_balance  -  amount_to_withdraw ;
         Console.Write("   New balance: "  +  account_balance ) ;
      }
   }

   public void transfer_money_to( BankAccount  receiving_account,
                                  double       amount_to_transfer )
   {
      Console.Write( "\n\nTRANSACTION FOR ACCOUNT OF " +  account_owner
                  +  " (Account number " +  account_number  + ")" ) ;

      if ( account_balance  >=  amount_to_transfer )
      {
         receiving_account.account_balance  =
            receiving_account.account_balance  +  amount_to_transfer ;

         Console.Write(
               "\n   " + amount_to_transfer + " was transferred to "
             +  receiving_account.account_owner  +  " (Account no. "
             +  receiving_account.account_number +  ")."
             +  "\n   Balance before transfer: " +  account_balance ) ;
         account_balance  =  account_balance  -  amount_to_transfer ;
         Console.Write( "   New balance:  " +  account_balance ) ;
      }
      else
      {
         Console.Write( "\n   -- Not enough money for transfer." ) ;
      }
   }
}

class BankBetter
{
   static void Main()
   {
      BankAccount  jazz_player_account  =
                       new  BankAccount( "Louis Armstrong", 121212, 0 ) ;
      BankAccount  moon_walker_account  =
                       new  BankAccount( "Neil Armstrong",  191919,
                                                            7777.77 ) ;
      jazz_player_account.deposit_money( 3333.33 ) ;

      jazz_player_account.withdraw_money( 4444.44 ) ;

      moon_walker_account.transfer_money_to( jazz_player_account,
                                             2222.22 ) ;

      moon_walker_account.show_account_data() ;
      jazz_player_account.show_account_data() ;
   }
}



