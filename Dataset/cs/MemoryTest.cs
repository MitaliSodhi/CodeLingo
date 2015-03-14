
//  MemoryTest.cs  (c) 2002 Kari Laitinen

using System ;

class PointerSimple
{
   unsafe static void Main()
   {
      int  first_integer   =  0x44, second_integer  =  0x66,
           third_integer   =  0x88 ;

      third_integer  =  sizeof( int ) ;

      int*  pointer_to_integer ;

      Console.Write( "\n Address of first_integer:  {0}" +  
                     "\n Address of second_integer: {1}" +
                     "\n Address of third_integer:  {2}",
                    (int) &first_integer, (int) &second_integer,
                    (int) &third_integer ) ;

      int   memory_positions_printed   =  0 ;
      byte*  memory_pointer  = (byte*) &first_integer ;

      while ( memory_positions_printed  <  16 )
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



