
//  pointer_arrays.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   int  first_array[]   =  { 0x11,  0x22,  0x33,  0x44 } ;
   int  second_array[]  =  { 0x666, 0x777, 0x888, 0x999 } ;

   int*  memory_pointer  =  second_array  -  1 ;

   cout << hex <<  "\n The address of first_array is:    "
        <<  (long) first_array 
        <<  "\n The address of second_array is:   "
        <<  (long) second_array
        <<  "\n The address of memory_pointer is: "
        <<  (long) &memory_pointer
        <<  "\n\n And here are 10 integers in memory:\n " ;

   for ( int memory_position_counter  =  0  ;
             memory_position_counter  <  10 ;
             memory_position_counter  ++ )
   {
      cout <<  "\n   Address "  <<  (long) memory_pointer 
           <<  " contains "  <<  *memory_pointer ;
      memory_pointer  ++  ;
   }

   cout <<  "\n\n   Address "  <<  (long) &memory_pointer 
        <<  " contains "    <<  (long) *( &memory_pointer ) <<"\n";
}



