
//  StackExploration2.cs (c) 1998-2002 Kari Laitinen

using System ;

unsafe class StackExploration2
{

   static int  modifier ;

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



   static string get_string()
   {
      string  string_to_return  =  "000" + modifier.ToString() ;

      modifier  ++  ;

      return  string_to_return ;
   }

   static void function_xx()
   {
      int[] array_xx  =  { 0x1111, 0x2222 } ;
      int   sum_xx    =  array_xx[ 0 ] + array_xx[ 1 ] ;

      Console.Write( "\n sum_xx contains " + sum_xx.ToString("X") 
                   + " in address " +
                     ((int) &sum_xx).ToString("X") ) ;

      Console.Write( "    " +  array_xx[ 0 ].ToString("X")
                   + "    " +  array_xx[ 1 ].ToString("X") ) ;

      string  string_xx  =  get_string() ;

      Console.Write( "\n  "  +  string_xx ) ;

      int   memory_positions_printed   =  0 ;
      int*  memory_pointer  =  &sum_xx ;

      memory_pointer  -= 20 ;

      while ( memory_positions_printed  <  40 )
      {
         Console.Write( "\n "
                      + ((int) memory_pointer).ToString("X")
                      + " contains "
                      + ( *memory_pointer ).ToString("X8") ) ;

         if ( (int) *memory_pointer  >  0x120000 )
         {
            print_memory_line( ( (int*) (*memory_pointer) + 3), 10 ) ;
         }

         memory_pointer ++ ;
         memory_positions_printed  ++ ;
      }

      Console.Write( "   "  +  string_xx ) ;

/********

      memory_pointer  =  (int*) *memory_pointer ;

      memory_positions_printed  =  0 ;

      while ( memory_positions_printed  <  12 )
      {
         Console.Write( "\n Memory address "
                      + ((int) memory_pointer).ToString("X")
                      + " contains "
                      + ( *memory_pointer ).ToString("X") ) ;
         memory_pointer ++ ;
         memory_positions_printed  ++ ;
      }

*************/
   }

   static void function_yy()
   {
      string  string_yy  =  get_string() ;
      string  string_yyy  =  get_string() ;

      Console.Write( "\n  "  +  string_yy  +  " " + string_yyy ) ;

      function_xx() ;
      Console.Write( "    "  +  string_yy  +  " " + string_yyy ) ;
   }

   static void function_zz()
   {
      string  string_zz  =  get_string() ;
      string  string_zzz  =  get_string() ;

      Console.Write( "\n  "  +  string_zz  + " " + string_zzz ) ;


      function_yy() ;
      Console.Write( "    "  +  string_zz  + " " + string_zzz ) ;
   }

   static void function_zzy()
   {
      string  string_zz  =  get_string() ;
      string  string_zzz  =  get_string() ;

      Console.Write( "\n  "  +  string_zz  + " " + string_zzz ) ;


      function_zz() ;
      Console.Write( "    "  +  string_zz  + " " + string_zzz ) ;
   }

   static void function_zzyy()
   {
      string  string_zz  =  get_string() ;
      string  string_zzz  =  get_string() ;

      Console.Write( "\n  "  +  string_zz  + " " + string_zzz ) ;


      function_zzy() ;
      Console.Write( "    "  +  string_zz  + " " + string_zzz ) ;
   }

   static void Main()
   {
/*****
      Console.Write(
       "\n function_xx starts in address " + (int) function_xx
       "\n function_yy starts in address " + (int) function_yy
       "\n function_zz starts in address " + (int) function_zz  ) ;
******/
      function_zzyy() ;
   }
}



