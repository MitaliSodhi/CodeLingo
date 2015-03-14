
//  StackSolution_10_9.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-06  File created.
//  2004-11-06  Last modification.

namespace BookNamespace
{
using System ;

class Stack
{
   const int STACK_INCREMENT_SIZE  =  4 ;

   int    number_of_items_on_stack ;
   int    current_stack_size ;
   int[]  stack_memory_space ;

   public Stack()
        :  this( STACK_INCREMENT_SIZE )
   {
      //  This method does not have any actual internal
      //  statements in its body.
   }

   public Stack( int  requested_stack_size )
   {
      stack_memory_space  =  new  int[ requested_stack_size ] ;

      current_stack_size  =  requested_stack_size ;

      number_of_items_on_stack    =  0 ;
   }

   public void push( int item_to_the_stack )
   {
      if ( number_of_items_on_stack  >=  current_stack_size  )
      {
         //  We must increase the memory space of this stack object.

         int[]  new_stack_memory_space ;

         new_stack_memory_space  =  new  int[ current_stack_size +
                                              STACK_INCREMENT_SIZE ] ;

         current_stack_size  =  current_stack_size
                                       + STACK_INCREMENT_SIZE ;

         //  We must copy the old stack contents to the new stack
         //  memory space.

         for ( int item_index  =  0  ;
                   item_index  <  number_of_items_on_stack ;
                   item_index  ++ )
         {
            new_stack_memory_space[ item_index ]  =
                                   stack_memory_space[ item_index ] ;
         }

         //  Let's make stack_memory_space reference the reserved
         //  new memory space. The old memory space shall be freed
         //  by the garbage collector as nobody is referencing that
         //  memory area any more.

         stack_memory_space  =  new_stack_memory_space ;

         Console.Write( " STACK HAS GROWN.\n" ) ;
      }

      //  Here we push the new value to the stack.

      stack_memory_space[ number_of_items_on_stack ]  =
                                     item_to_the_stack ;
      number_of_items_on_stack  ++  ;
   }


   public void pop( out int item_from_the_stack )
   {
      if  ( number_of_items_on_stack  ==  0 )
      {
         Console.Write( "\n ERROR: Attempt to pop on empty stack !\n" ) ;
         item_from_the_stack  =  -1 ;  // out parameter must get a value
      }
      else
      {
         number_of_items_on_stack  -- ;
         item_from_the_stack  =
                 stack_memory_space[ number_of_items_on_stack ] ;
      }
   }


   public bool stack_is_not_empty()
   {
      return  ( number_of_items_on_stack  >  0  ) ;
   }
}


class StackTester
{
   static void Main()
   {
      int  value_to_the_stack ;
      int  value_popped_from_the_stack ;

      Stack  even_stack  =  new  Stack() ;
      Stack  odd_stack   =  new  Stack() ;

      Console.Write( "\n Let's test stacks. Please, type in integers."
            +  "\n I will push those numbers onto stacks, and later"
            +  "\n take them away from the stacks. I will stop reading"
            +  "\n numbers when you type in a zero."
            +  "\n Please, press <Enter> after each number. \n\n" ) ;
      do
      {
         Console.Write( " Give a number:  " ) ;
         value_to_the_stack  =  Convert.ToInt32( Console.ReadLine() ) ;

         if ( ( value_to_the_stack  %  2 )  ==  0 )
         {
            even_stack.push( value_to_the_stack ) ;
         }
         else
         {
            odd_stack.push( value_to_the_stack ) ;
         }
      }  
        while  ( value_to_the_stack  !=  0  ) ;

      Console.Write( "\n Even numbers popped from the stack are:\n\n ") ;

      while ( even_stack.stack_is_not_empty() )
      {
         even_stack.pop( out value_popped_from_the_stack ) ;

         Console.Write( value_popped_from_the_stack  +  "   "  ) ;
      }

      Console.Write( "\n\n Odd numbers popped from the stack are:\n\n ") ;

      while ( odd_stack.stack_is_not_empty() )
      {
         odd_stack.pop( out value_popped_from_the_stack ) ;

         Console.Write( value_popped_from_the_stack  +  "   "  ) ;
      }

      Console.Write( "\n" ) ;
   }
}
}  // end of namespace definition




