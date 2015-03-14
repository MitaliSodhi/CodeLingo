
//  BankSimpleWithStructUnsafe.cs  (c) 2003 Kari Laitinen

//  Compile: csc BankSimpleWithStructUnsafe.cs /unsafe

//  www.naturalprogramming.com

//  This program is a modified version of program
//  BankSimpleWithStruct.cs which is a modified version
//  of BankSimple.cs. This program prints the stack contents
//  to the screen, so that you can verify that the
//  struct-based BankAccount objects are indeed in the
//  stack memory.


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

unsafe class BankSimpleWithStructUnsafe
{
   static void print_memory( int*  memory_pointer,
                             int   number_of_positions_to_print )
   {
      for ( int position_counter  =  0 ;
                position_counter  <  number_of_positions_to_print ;
                position_counter  ++  )
      {
         Console.Write( "\n Address "
              +  ( (int) memory_pointer ).ToString("X")
              +  " contains "
              +  ( *memory_pointer ).ToString("X").PadLeft( 8 ) ) ;

         memory_pointer  ++ ;
      }
   }

   static void Main()
   {
      BankAccount  first_account   =  new  BankAccount() ;
      BankAccount  second_account  =  new  BankAccount() ;

      int  integer_on_top_of_the_stack  =  0x11223344 ;

      //  Note that the account numbers are hexadecimal values
      //  and the same amounts are deposited to both accounts
      //  in this program version.

      first_account.initialize_account(  "James Bond", 0x77007007 ) ;
      second_account.initialize_account( "Philip Marlowe", 0x22003004 ) ;

      first_account.deposit_money(  5566.77 ) ;
      second_account.deposit_money( 5566.77 ) ;

      first_account.show_account_data() ;
      second_account.show_account_data() ;

      print_memory( &integer_on_top_of_the_stack, 12 ) ;
   }
}


