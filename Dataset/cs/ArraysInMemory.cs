
//  ArraysInMemory.cs  (c) 2003 Kari Laitinen

//  Compile: csc ArraysInMemory.cs /unsafe

using System ;

class ArraysInMemory
{
   unsafe static void Main()
   {
      int[]  some_array  =  new int[ 3 ]; // { 0x1111, 0x2222, 0x3333 } ;

      int    sum_of_elements  =  some_array[ 0 ] +
                                 some_array[ 1 ] +
                                 some_array[ 2 ] ;

      Console.Write( "\n sum_of_elements contains " 
                  +  sum_of_elements.ToString("X")
                  +  " in address  "
                  +  ( (int) &sum_of_elements ).ToString("X") ) ;


      int   memory_positions_printed   =  0 ;
      int*  memory_pointer  =  &sum_of_elements ;

      memory_pointer  -- ;
      memory_pointer  -- ;
      memory_pointer  -- ;
      memory_pointer  -- ;

      while ( memory_positions_printed  <  19 )
      {
         Console.Write( "\n Memory address "
                      + ((int) memory_pointer).ToString("X")
                      + " contains "
                      + ( *memory_pointer ).ToString("X") ) ;
         memory_pointer ++ ;
         memory_positions_printed  ++ ;
      }


   }
}



