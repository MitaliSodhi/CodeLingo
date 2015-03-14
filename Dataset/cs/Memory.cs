
//  Memory.cs  (c) 2003 Kari Laitinen

//  www.naturalprogramming.com

//  Compilation: csc Memory.cs /unsafe

//  This program is a C# version of program memory.cpp that
//  was presented in my C++ book. Because this program uses pointers
//  it may be hard to understand. If you want to study pointers,
//  my C++ book "A Natural Introduction to Computer Programming with C++"
//  might be a book to read. Pointers are not, however, needed
//  in C# programming, and C# pointers cannot do everything that
//  can be done with C/C++ pointers.

using System ;
using System.Text ;  // Class StringBuilder etc.

unsafe class Memory
{
   static void print_memory_contents( void*  memory_address,
                                      int    number_of_bytes_to_print )
   {
      byte* a_byte_in_memory = (byte*) memory_address ;

      StringBuilder  line_of_bytes        =  new  StringBuilder() ;
      StringBuilder  bytes_as_characters  =  new  StringBuilder() ;

      int    number_of_bytes_on_this_line  =  0 ;

      Console.Write(  "\n" 
               + ((int) a_byte_in_memory).ToString( "X8" )  +  " " ) ;

      while  (  number_of_bytes_to_print  >  0  )
      {
         if  (  number_of_bytes_on_this_line  ==  16  )
         {
            // We'll start a new line on the screen.

            Console.Write(  line_of_bytes.ToString() 
                 + "  "  +  bytes_as_characters.ToString()  +  "\n" 
                 + ((int) a_byte_in_memory).ToString( "X8" ) + " " ) ;

            line_of_bytes        =  new  StringBuilder() ;
            bytes_as_characters  =  new  StringBuilder() ;

            number_of_bytes_on_this_line   =  0 ;
         }

         line_of_bytes.Append( " " +  ( *a_byte_in_memory).ToString("X2") ) ;

         //  We'll make sure that bytes_as_characters contains
         //  just printable characters.

         if ( *a_byte_in_memory  > 0x1F && *a_byte_in_memory < 0x7F )
         {
            bytes_as_characters.Append( (char) *a_byte_in_memory ) ;
         }
         else
         {
            bytes_as_characters.Append( ' ' ) ;
         }

         number_of_bytes_on_this_line  ++  ;
         number_of_bytes_to_print      --  ;
         a_byte_in_memory  ++  ;
      }

      //  The last line of memory contents may contain less than
      //  16 bytes. Now we finish that line.

      if ( number_of_bytes_on_this_line  >  0 )
      {

         Console.Write( line_of_bytes.ToString().PadRight( 16 * 3 )
                     +  "  "  +  bytes_as_characters.ToString() ) ;  ;
      }

      Console.Write( "\n" ) ;
   }


   static void  Main()
   {

      int    some_integer       =  0xEE ;
      int    another_integer    =  0xCC ;

      print_memory_contents( &another_integer, 16 ) ;

      some_integer     =  0x66  ;
      another_integer  =  0x77  ;

      print_memory_contents( &another_integer, 10 ) ;
      print_memory_contents( &some_integer, 4 ) ;

      //  struct types (e.g. DateTime) can be printed with pointers

      DateTime  date_and_time_now  =  DateTime.Now ;
 
      print_memory_contents( &date_and_time_now, 32 ) ;

      //  Not all hexadecimal addresses work in the following statement.
      //  Probably address 0xC9039C is within the heap memory area.

      print_memory_contents( (int*)0xC9039C, 16  ) ;


   }
}


/*****
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

******/




