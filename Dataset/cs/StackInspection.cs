
//  StackInspection.cs  (c) 2003 Kari Laitinen

//  Compile: csc StackInspection.cs /unsafe

using System ;

unsafe class StackInspection
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

   static void high_method()
   {
      int  high_value    =  0xAAAAAA ;

      print_memory( &high_value - 4, 16 ) ;
   }

   static void middle_method()
   {
      int  middle_value          =  0x111111 ;
      int  another_middle_value  =  0x222222 ;

      high_method() ;

      print_memory( &middle_value, 0 ) ;
      print_memory( &another_middle_value, 0 ) ;
   }

   static void low_method()
   {
      int low_value    =  0x333333 ;

      middle_method() ;

      print_memory( &low_value, 0 ) ;
   }

   static void Main()
   {
      low_method() ;
   }
}



