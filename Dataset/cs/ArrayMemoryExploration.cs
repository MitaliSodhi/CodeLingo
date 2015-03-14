
//  ArrayMemoryExploration.cs  (c) 2004 Kari Laitinen

//  Compile: csc ArrayMemoryExploration.cs /unsafe

/*  With this program you can see what an array of type
    int looks like in the heap memory. On my computer the
    program produces the following output where the
    array referenced by first_array begins in address
    C92AF0H.

  12F88C    C935FC  0012F894  43 02 E7 02 F0 2A C9 00 04 2B  C    *   +
  12F890   2E701FD  00C93B58  06 00 00 00 31 00 32 00 46 00      1 2 F 
  12F894    C92B58  02E70233  8B 0E 83 C1 08 BA 0A 00 00 00            
  12F898    C92AF0  00C92AF8  22 11 00 00 44 33 00 00 00 00  "   D3    
  12F89C    C92B04  00C92B0C  66 55 00 00 88 77 00 00 00 00  fU   w    
  12F8A0    C92B18  00C92B20  BB AA 00 00 DD CC 00 00 00 00            
  12F8A4    12F90C  0012F914  DF B4 1E 79 F2 B4 1E 79 8B 50     y   y P
  12F8A8        10
  12F8AC         8
  12F8B0    12F8B0  0012F8B8  D0 F8 12 00 00 00 00 00 E8 F8            
  12F8B4   2E700D8  02E700E0  05 B6 79 E8 30 1F AE FD 8B C8    y 0     
  12F8B8    12F8D0  0012F8D8  1C F9 12 00 00 00 00 00 F4 F8            
  12F8BC         0
  12F8C0    12F8E8  0012F8F0  4C FC 12 00 00 00 00 00 00 00  L         
  12F8C4    12F90C  0012F914  DF B4 1E 79 F2 B4 1E 79 8B 50     y   y P
  12F8C8         9
  first_array[ 0 ]  4386
  another_array[ 0 ]  21862
  third_array[ 0 ]  43707

****/


using  System ;

unsafe class ArrayMemoryExploration
{
   static void print_memory_line( void*  memory_address,
                                  int    number_of_bytes_to_print )
   {
      // This method works like print_memory_contents() but
      // this one prints less newlines.

      byte* a_byte_in_memory = (byte*) memory_address ;

      int    number_of_bytes_on_this_line  =  0 ;
      char[] bytes_as_characters  =  new  char[ 20 ] ;

      Console.Write(  "  " 
               + ((int) a_byte_in_memory).ToString( "X8" )  +  " " ) ;

      while  (  number_of_bytes_to_print  >  0  &&
                number_of_bytes_on_this_line  <  16 )
      {
         Console.Write( " "  +  ( *a_byte_in_memory).ToString("X2") ) ;

         //  We'll make sure that bytes_as_characters contains
         //  just printable characters.

         if ( *a_byte_in_memory  > 0x1F && *a_byte_in_memory < 0x7F )
         {
            bytes_as_characters[ number_of_bytes_on_this_line ]  =
                                            (char)  *a_byte_in_memory ;
         }
         else
         {
            bytes_as_characters[ number_of_bytes_on_this_line ] = ' ' ;
         }

         number_of_bytes_on_this_line  ++  ;
         number_of_bytes_to_print      --  ;
         a_byte_in_memory  ++  ;
      }


      string  bytes_as_string  =
                       new  String( bytes_as_characters, 0,
                                    number_of_bytes_on_this_line ) ;

      Console.Write( "  "  +  bytes_as_string  ) ; 
   }


   static void print_memory( int*  memory_pointer,
                             int   number_of_positions_to_print )
   {
      for ( int position_counter  =  0 ;
                position_counter  <  number_of_positions_to_print ;
                position_counter  ++  )
      {
         Console.Write( "\n  "
              +  ( (int) memory_pointer ).ToString("X")
              +  "  "
              +  ( *memory_pointer ).ToString("X").PadLeft( 8 ) ) ;


         //  Let's print stuff from the address that was found
         //  in memory. By using an offset of 2 times 4 bytes
         //  we can see the individual array elements in memory.

         if ( (int) *memory_pointer  >  0x120000 )
         {
            print_memory_line( ( (int*) (*memory_pointer) + 2), 10 ) ;
         }

         memory_pointer  ++ ;
      }
   }



   static void Main()
   {
      int[]  first_array  =  { 0x1122, 0x3344 } ;

      int[]  another_array  =  { 0x5566, 0x7788 } ;

      int[]  third_array  =  { 0xAABB, 0xCCDD } ;

      int  some_integer  =  9 ;


      print_memory( ( &some_integer - 15 ), 16 ) ;

      Console.Write( "\n  first_array[ 0 ]  "  +
                     first_array[ 0 ] ) ;

      Console.Write( "\n  another_array[ 0 ]  "  +
                     another_array[ 0 ] ) ;

      Console.Write( "\n  third_array[ 0 ]  "  +
                     third_array[ 0 ] ) ;
   }
}



