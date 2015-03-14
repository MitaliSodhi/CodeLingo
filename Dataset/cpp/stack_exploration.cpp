
//  stack_exploration.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>

void  function_xx()
{
   int  array_xx[]  =  { 0x1111, 0x2222 } ;
   int  sum_xx      =  array_xx[ 0 ] + array_xx[ 1 ] ;

   cout << "\n sum_xx is in address " << (long) &sum_xx ;

   int   memory_positions_printed   =  0 ;
   int*  memory_pointer  =  &sum_xx ;

   while ( memory_positions_printed  <  16 )
   {
      cout << "\n Memory address " << (long) memory_pointer
           << " contains " << *memory_pointer ;
      memory_pointer ++ ;
      memory_positions_printed  ++ ;
   }
}

void  function_yy()
{
   int  array_yy[]  =  { 0x3333, 0x4444 } ;
   int  sum_yy      =  array_yy[ 0 ] + array_yy[ 1 ] ;

   cout << "\n sum_yy is in address " << (long) &sum_yy ;

   function_xx() ;
}

void  function_zz()
{
   int  array_zz[]  =  { 0x5555, 0x6666 } ;
   int  sum_zz      =  array_zz[ 0 ] + array_zz[ 1 ] ;

   cout << "\n sum_zz is in address " << (long) &sum_zz ;

   function_yy() ;
}

int main()
{
   cout <<  hex
    << "\n function_xx starts in address " << (long) function_xx
    << "\n function_yy starts in address " << (long) function_yy
    << "\n function_zz starts in address " << (long) function_zz ;

   function_zz() ;
}


