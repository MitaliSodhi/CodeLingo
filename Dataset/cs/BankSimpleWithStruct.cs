
//  BankSimpleWithStruct.cs  (c) 2003 Kari Laitinen

//  www.naturalprogramming.com

//  This program works in the same way as BankSimple.cs
//  but in this program BankAccount is a struct, not a class.

using System ;

struct  BankAccount
{
   string  account_owner ;
   long    account_number ;
   double  account_balance ;

   public void initialize_account( string given_name,
                                   long   given_account_number )
   {
      account_owner    =  given_name  ;
      account_number   =  given_account_number ;
      account_balance  =  0  ;
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
}

class BankSimpleWithStruct
{
   static void Main()
   {
      BankAccount  first_account   =  new  BankAccount() ;
      BankAccount  second_account  =  new  BankAccount() ;

      first_account.initialize_account(  "James Bond", 77007007 ) ;
      second_account.initialize_account( "Philip Marlowe", 22003004 ) ;

      first_account.deposit_money(  5566.77 ) ;
      second_account.deposit_money( 9988.77 ) ;
      first_account.deposit_money(  2222.11 ) ;

      first_account.show_account_data() ;
      second_account.show_account_data() ;
   }
}


