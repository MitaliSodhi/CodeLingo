
//  VariablesInMemory.cs  (c) 2004 Kari Laitinen

//  Compile: csc VariablesInMemory.cs /unsafe

using System ;

unsafe class VariablesInMemory
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
      byte  byte_variable   =  12 ;
      char  char_variable   =  'A' ;
      short short_variable  =  1234 ;
      int   int_variable    =  1234 ;
      long  long_variable   =  1234 ;
      float float_variable  =  123.456F ;
      double double_variable  =  123.456 ;

      print_bytes_in_memory( &double_variable, 8 ) ;
      print_bytes_in_memory( &float_variable, 4 ) ;
//      print_bytes_in_memory( &long_variable, 8 ) ;
//      print_bytes_in_memory( &int_variable, 4 ) ;
//      print_bytes_in_memory( &short_variable, 2 ) ;
//      print_bytes_in_memory( &char_variable, 2 ) ;
//      print_bytes_in_memory( &byte_variable, 1 ) ;

/***

      Console.Write( "\n byte_variable  is in address  " +
                     ( (int) &byte_variable ).ToString("X") ) ;
      Console.Write( "\n char_variable  is in address  " +
                     ( (int) &char_variable ).ToString("X") ) ;
      Console.Write( "\n int_variable   is in address  " +
                     ( (int) &int_variable ).ToString("X") ) ;
      Console.Write( "\n long_variable  is in address  " +
                     ( (int) &long_variable ).ToString("X") + "\n" ) ;

****/
   }
}



