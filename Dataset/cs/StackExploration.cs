
//  StackExploration.cs (c) 1998-2002 Kari Laitinen

using System ;

unsafe class StackExploration
{
   static void some_dummy_method( int[] some_array )
   {
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

      int   memory_positions_printed   =  0 ;
      int*  memory_pointer  =  &sum_xx ;

      memory_pointer  -- ;

      while ( memory_positions_printed  <  21 )
      {
         Console.Write( "\n Memory address "
                      + ((int) memory_pointer).ToString("X")
                      + " contains "
                      + ( *memory_pointer ).ToString("X") ) ;
         memory_pointer ++ ;
         memory_positions_printed  ++ ;
      }

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
      int[] array_yy    =  { 0x3333, 0x4444 } ;

      some_dummy_method( array_yy ) ;

      int   sum_yy      =  array_yy[ 0 ] + array_yy[ 1 ] ;

      Console.Write( "\n sum_yy contains " + sum_yy.ToString("X")
                   + " in address "
                   + ((int) &sum_yy).ToString("X") ) ;

      Console.Write( "    " +  array_yy[ 0 ].ToString("X")
                   + "    " +  array_yy[ 1 ].ToString("X") ) ;
      function_xx() ;
   }

   static void function_zz()
   {
      int[] array_zz  =  { 0x5555, 0x6666, 0x7777 } ;

      some_dummy_method( array_zz ) ;

      int   sum_zz    =  array_zz[ 0 ] + array_zz[ 1 ]  ;

      Console.Write( "\n sum_zz contains " + sum_zz.ToString("X")
                   + " in address "
                   + ((int) &sum_zz ).ToString("X") ) ;


      Console.Write( "    " +  array_zz[ 0 ].ToString("X")
                   + "    " +  array_zz[ 1 ].ToString("X") ) ;

      function_yy() ;
   }

   static void Main()
   {
/*****
      Console.Write(
       "\n function_xx starts in address " + (int) function_xx
       "\n function_yy starts in address " + (int) function_yy
       "\n function_zz starts in address " + (int) function_zz  ) ;
******/
      function_zz() ;
   }
}



