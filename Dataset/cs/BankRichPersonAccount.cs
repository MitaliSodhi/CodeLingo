
//  BankRichPersonAccount.cs  (c) Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-17  File created.
//  2004-11-17  Last modification.

//  A solution to Exercise 12-8.

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

class  RichPersonAccount  :  BankAccount
{
   protected double  minimum_amount_to_deposit ;

   public RichPersonAccount( string  given_account_owner,
                             long    given_account_number,
                             double  initial_balance,
                             double  given_deposit_limit  )

       : base( given_account_owner,
               given_account_number,
               initial_balance )
   {
      minimum_amount_to_deposit  =  given_deposit_limit ;
   }

   public override void deposit_money( double amount_to_deposit )
   {
      if ( amount_to_deposit  <  minimum_amount_to_deposit )
      {
         Console.Write(
                 "\n\nTRANSACTION FOR ACCOUNT OF " +  account_owner
              +  " (Account number " +  account_number  + ")" ) ;

         Console.Write(
                 "\n   -- Transaction not completed: Cannot deposit "
              +  amount_to_deposit   + "\n   -- Minimum deposit amount is "
              +  minimum_amount_to_deposit + "." ) ;
      }
      else
      {
         base.deposit_money( amount_to_deposit ) ;
      }
   }
}

class BankRichPersonAccount
{
   static void Main()
   {
      RichPersonAccount  rockefeller_account  =  new
             RichPersonAccount( "John D.", 55555, 900000.00, 9000.00 ) ;
      
      rockefeller_account.deposit_money( 8000.00 ) ;

      RichPersonAccount  getty_account  =  new
             RichPersonAccount( "Paul Getty", 66666, 900000.00, 7000.00 ) ;
      
      getty_account.deposit_money( 8000.00 ) ;
   }
}



