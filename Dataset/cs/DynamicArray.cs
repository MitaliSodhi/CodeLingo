
//  DynamicArray.cs  (c) 2003 Kari Laitinen

using System ;

class DynamicArray
{
   int[] array_memory_space ;

   int   number_of_integers_in_array  =  0 ;
   int   current_array_size  =  0 ;

   void  enlarge_this_array( int  desired_array_size )
   {
      if ( desired_array_size  >  current_array_size )
      {
         int[]  new_array_memory_space  =  new  int[ desired_array_size ] ;

         for ( int integer_index  =  0 ;
                   integer_index  <  number_of_integers_in_array ;
                   integer_index  ++ )
         {
            new_array_memory_space[ integer_index ]  =
                                   array_memory_space[ integer_index ] ;
         }

         array_memory_space    =  new_array_memory_space ;
         current_array_size    =  desired_array_size ;
      }
   }

   public void add_integer( int integer_to_the_end_of_array )
   {
      if ( current_array_size  <=  number_of_integers_in_array )
      {
         enlarge_this_array( number_of_integers_in_array  +  4 ) ;
      }

      array_memory_space[ number_of_integers_in_array ]  =
                                      integer_to_the_end_of_array ;

      number_of_integers_in_array  ++  ;
   }

   public int Length
   {
      get
      {
         return  number_of_integers_in_array ;
      }

      set
      {
         enlarge_this_array( value ) ;

         number_of_integers_in_array  =  value ;
      }
   }

   public int this[ int index_value ]
   {
      get
      {
         return array_memory_space[ index_value ] ;
      }

      set
      {
         if ( index_value  >=  number_of_integers_in_array )
         {
            Console.Write( "\n\n   Too large index: "  +  index_value ) ;
         }
         else
         {
            array_memory_space[ index_value ]  =  value ;
         }
      }
   }
}


class DynamicArrayTester
{
   static void Main()
   {
      DynamicArray  array_of_integers  =  new  DynamicArray() ;

      for ( int integer_to_array  =   990 ;
                integer_to_array  <  1000 ;
                integer_to_array  ++ )
      {
         array_of_integers.add_integer( integer_to_array ) ;
      }

      for ( int integer_index  =  0 ;
                integer_index  <  array_of_integers.Length ;
                integer_index  ++ )
      {
         Console.Write( "   "  +  array_of_integers[ integer_index ] ) ;
      }

      array_of_integers[  3 ]  =  333 ;
      array_of_integers[ 13 ]  =  888 ;

      array_of_integers.Length  =  14 ;
      array_of_integers[ 13 ]  =  888 ;

      Console.Write( "\n\n" ) ;

      for ( int integer_index  =  0 ;
                integer_index  <  array_of_integers.Length ;
                integer_index  ++ )
      {
         Console.Write( "   "  +  array_of_integers[ integer_index ] ) ;
      }
   }
}



