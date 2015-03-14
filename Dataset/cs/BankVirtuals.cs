
//  BankVirtuals.cs  (c) 2003 Kari Laitinen

using System ;

class  BankAccount
{
   protected  string  account_owner ;
   protected  long    account_number ;
   protected  double  account_balance ;

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

   public virtual void deposit_money( double amount_to_deposit )
   {
      Console.Write( "\n\nTRANSACTION FOR ACCOUNT OF " +  account_owner
                  +  " (Account number " +  account_number  + ")" ) ;
      Console.Write( "\n   Amount deposited: "  +  amount_to_deposit
                  +  "\n   Old account balance: "  +  account_balance ) ;
      account_balance  =  account_balance  +  amount_to_deposit ;
      Console.Write( "   New balance: "  +  account_balance  ) ;
   }

   public virtual void withdraw_money( double amount_to_withdraw )
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

         Console.Write("\n   " + amount_to_transfer + " was transferred to "
              + receiving_account.account_owner  +  " (Account no. "
              + receiving_account.account_number +  ")."
              + "\n   Balance before transfer: " +  account_balance ) ;
         account_balance  =  account_balance  -  amount_to_transfer ;
         Console.Write("   New balance:  " +  account_balance ) ;
      }
      else
      {
         Console.Write( "\n   -- Not enough money for transfer." ) ;
      }
   }
}

class  AccountWithCredit  :  BankAccount
{
   protected  double  credit_limit ;

   public  AccountWithCredit( string  given_account_owner,
                              long    given_account_number,
                              double  initial_balance,
                              double  given_credit_limit  )

       : base( given_account_owner,
               given_account_number,
               initial_balance )
   {
      credit_limit  =  given_credit_limit ;
   }

   public override void withdraw_money( double amount_to_withdraw )
   {
      Console.Write( "\n\nTRANSACTION FOR ACCOUNT OF " +  account_owner
                  +  " (Account number " +  account_number  + ")" ) ;

      if ( account_balance  +  credit_limit  <  amount_to_withdraw )
      {
         Console.Write(
               "\n   --  Transaction not completed: "
             + "Not enough credit to withdraw "+ amount_to_withdraw ) ;
      }
      else
      {
         Console.Write(
                "\n   Amount withdrawn:    "  +  amount_to_withdraw
              + "\n   Old account balance: "  +  account_balance ) ;
         account_balance  =  account_balance  -  amount_to_withdraw ;
         Console.Write( "   New balance: "  +  account_balance ) ;
      }
   }
}

class  RestrictedAccount  :  BankAccount
{
   protected double  maximum_amount_to_withdraw ;

   public RestrictedAccount( string  given_account_owner,
                             long    given_account_number,
                             double  initial_balance,
                             double  given_withdrawal_limit  )

       : base( given_account_owner,
               given_account_number,
               initial_balance )
   {
      maximum_amount_to_withdraw  =  given_withdrawal_limit ;
   }

   public override void withdraw_money( double amount_to_withdraw )
   {
      if ( amount_to_withdraw  >  maximum_amount_to_withdraw )
      {
         Console.Write(
                 "\n\nTRANSACTION FOR ACCOUNT OF " +  account_owner
              +  " (Account number " +  account_number  + ")" ) ;

         Console.Write(
                 "\n   -- Transaction not completed: Cannot withdraw "
              +  amount_to_withdraw   + "\n   -- Withdrawal limit is "
              +  maximum_amount_to_withdraw + "." ) ;
      }
      else
      {
         base.withdraw_money( amount_to_withdraw ) ;
      }
   }
}

class BankVirtuals
{
   static void Main()
   {
      BankAccount  beatles_account  =
                     new  BankAccount( "John Lennon", 222222, 2000.00 ) ;

      AccountWithCredit  stones_account  =
                       new  AccountWithCredit( "Brian Jones", 333333,
                                                2000.00,  1000.00 ) ;

      RestrictedAccount   doors_account  =
                       new  RestrictedAccount( "Jim Morrison", 444444,
                                               4000.00,  1000.00 ) ;

      beatles_account.withdraw_money( 2500.00 ) ;
      stones_account.withdraw_money( 2500.00 ) ;
      doors_account.withdraw_money( 2500.00 ) ;
   }
}



