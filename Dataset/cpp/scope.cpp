
//  scope.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>

int  global_array[]  =  { 0x1111, 0x2222 } ;
int  variable_aa     =  0x3333 ;

void  function_aa()
{
   int  variable_aa  =  0x4444 ;

   do
   {
      int  variable_aa  =  0x5555 ;

      cout << "\n variable_aa (loop)   contains "<< variable_aa
           << " in address " << (long) &variable_aa ;
   }
      while ( 1 == 0 ) ;

   cout << "\n variable_aa (local)  contains " << variable_aa
        << " in address " << (long) &variable_aa ;

   global_array[ 0 ]  =  0x8888 ;
}

void  function_bb()
{
   cout << "\n variable_aa (global) contains " << variable_aa
        << " in address " << (long) &variable_aa ;

   function_aa() ;

   global_array[ 1 ]  =  0x9999 ;
}

int main()
{
   cout << hex ;
   cout << "\n global_array contains " << global_array[ 0 ]
        << " and " << global_array[ 1 ] << " in addresses "
        << (long) &global_array[ 0 ] << " and "
        << (long) &global_array[ 1 ] << "\n" ;

   function_bb() ;

   cout << "\n\n global_array contains " << global_array[ 0 ]
        << " and " << global_array[ 1 ] << " in addresses "
        << (long) &global_array[ 0 ] << " and "
        << (long) &global_array[ 1 ] ;
}



