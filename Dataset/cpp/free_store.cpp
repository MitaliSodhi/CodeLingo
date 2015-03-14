
//  free_store.cpp (c) 1998-2004 Kari Laitinen

#include  <iostream.h>

int main()
{
   int*  first_free_store_variable ;

   first_free_store_variable  =  new  int ;

   int*  second_free_store_variable   =  new  int ;

   *first_free_store_variable   =   66 ;
   *second_free_store_variable  =  222 ;

   int*  array_on_free_store  =  new  int[ 10 ] ;

   array_on_free_store[ 0 ]  =  *first_free_store_variable ;
   array_on_free_store[ 1 ]  =  *second_free_store_variable ;

   array_on_free_store[ 2 ]  =  *first_free_store_variable  +
                                       *second_free_store_variable ;

   cout << "\n The contents of the array on free store is: \n\n  " ;

   for ( int integer_index  =   0 ;
             integer_index  <  10 ;
             integer_index  ++ )
   {
      cout  <<  "   "  <<  array_on_free_store[ integer_index ] ;
   }

   cout << "\n" ;

   delete  first_free_store_variable ;
   delete  second_free_store_variable ;

   delete []  array_on_free_store ;
}


