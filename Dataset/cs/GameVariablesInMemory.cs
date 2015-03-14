
//  GameVariablesInMemory.cs  (c) 2004 Kari Laitinen

//  Compile: csc GameVariablesInMemory.cs /unsafe

using System ;

unsafe class GameVariablesInMemory
{
   static void print_bytes_in_memory( void* memory_address,
                                      int   number_of_bytes_to_print )
   {
      byte* byte_in_memory = (byte*) memory_address ;

      for ( int byte_counter  =  0 ;
                byte_counter  <  number_of_bytes_to_print ;
                byte_counter  ++  )
      {
         Console.Write( "\n Address "
              +  ( (int) byte_in_memory ).ToString("X")
              +  " contains "
              +  ( *byte_in_memory ).ToString("X2") ) ;

         byte_in_memory  ++ ;
      }
   }


   static void Main()
   {
      int  integer_from_keyboard  ;
      int  one_larger_integer ;

      print_bytes_in_memory( &one_larger_integer, 4 ) ;
      print_bytes_in_memory( &integer_from_keyboard, 4 ) ;

      Console.Write( "" + integer_from_keyboard ) ;

      Console.Write(
          "\n This program is a computer game. Please, type in "
        + "\n an integer in the range  1 ... 2147483646 : " ) ;

      integer_from_keyboard  =  Convert.ToInt32( Console.ReadLine() ) ;

      print_bytes_in_memory( &one_larger_integer, 4 ) ;
      print_bytes_in_memory( &integer_from_keyboard, 4 ) ;

      one_larger_integer  =  integer_from_keyboard  +  1 ;

      Console.Write( "\n You typed in " + integer_from_keyboard + "."
                  +  "\n My number is " + one_larger_integer    + "."
                  +  "\n Sorry, you lost. I won. The game is over.\n") ;


      print_bytes_in_memory( &one_larger_integer, 4 ) ;
      print_bytes_in_memory( &integer_from_keyboard, 4 ) ;

   }
}



