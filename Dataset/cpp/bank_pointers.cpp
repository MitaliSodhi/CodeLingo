
//  bank_pointers.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>

#include  "class_bank_account.h"

int main()
{
   Bank_account*  mouse_account ;

   mouse_account  =  new  Bank_account(
                                "Mickey Mouse", 222333, 3000.00 ) ;

   Bank_account*  duck_account  =  new  Bank_account(
                                "Donald Duck", 444555, 4000.00 ) ;

   duck_account -> transfer_money_to( *mouse_account, 500.00 ) ;

   mouse_account  -> show_account_data() ;
   duck_account   -> show_account_data() ;

   delete  duck_account ;
   delete  mouse_account ;
}


