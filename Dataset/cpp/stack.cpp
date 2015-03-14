
//  stack.cpp  (c) 1998-2002 Kari Laitinen

#include <iostream.h>

#define   STACK_INCREMENT_SIZE   4

class  Stack
{
protected:
   int  number_of_items_on_stack ;
   int  current_stack_size ;
   int*  stack_memory_space ;

public:
   Stack( int requested_stack_size  =  STACK_INCREMENT_SIZE ) ;
   ~Stack() ;

   void push( int   item_to_the_stack ) ;
   void pop(  int&  item_from_the_stack ) ;

   bool  stack_is_not_empty() ;
} ;


Stack::Stack( int  requested_stack_size )
{
   stack_memory_space  =  new  int[ requested_stack_size ] ;

   current_stack_size  =  requested_stack_size ;

   number_of_items_on_stack    =  0 ;
}


Stack::~Stack()
{
   delete  []  stack_memory_space ;
}


void  Stack::push( int item_to_the_stack )
{
   if ( number_of_items_on_stack  >=  current_stack_size  )
   {
      //  We must increase the memory space of this stack object.

      int*  new_stack_memory_space ;

      new_stack_memory_space  =  new  int[ current_stack_size +
                                           STACK_INCREMENT_SIZE ] ;

      current_stack_size  =  current_stack_size
                                    + STACK_INCREMENT_SIZE ;

      //  We must first copy the old stack contents to the
      //  new stack memory space and then we can delete the old
      //  stack memory space.

      for ( int item_index  =  0  ;
                item_index  <  number_of_items_on_stack ;
                item_index  ++ )
      {
         new_stack_memory_space[ item_index ]  =
                                stack_memory_space[ item_index ] ;
      }

      delete  []  stack_memory_space ;

      stack_memory_space  =  new_stack_memory_space ;

      cout  <<  " STACK HAS GROWN.\n" ;
   }

   //  Here we push the new value to the stack.

   stack_memory_space[ number_of_items_on_stack ]  =
                                  item_to_the_stack ;
   number_of_items_on_stack  ++  ;
}


void  Stack::pop( int&  item_from_the_stack )
{

   if  ( number_of_items_on_stack  ==  0 )
   {
      cout << "\n ERROR: Attempt to pop on empty stack !\n" ;
   }
   else
   {
      number_of_items_on_stack  -- ;
      item_from_the_stack  =
              stack_memory_space[ number_of_items_on_stack ] ;
   }
}


bool  Stack::stack_is_not_empty()
{
   return  ( number_of_items_on_stack  >  0  ) ;
}


int main()
{
   int  value_to_the_stack ;
   int  value_popped_from_the_stack ;

   Stack  test_stack ;

   cout << "\n Let's test a stack. Please, type in integers."
           "\n I will push those numbers onto a stack, and later"
           "\n take them away from the stack. I will stop reading"
           "\n numbers when you type in a zero."
           "\n Please, press <Enter> after each number. \n\n" ;
   do
   {
      cout  <<  " Give a number:  " ;
      cin   >>  value_to_the_stack ;

      test_stack.push( value_to_the_stack ) ;
   }  
     while  ( value_to_the_stack  !=  0  ) ;

   cout << "\n The numbers popped from the stack are: \n\n " ;

   while ( test_stack.stack_is_not_empty() )
   {
      test_stack.pop(  value_popped_from_the_stack ) ;

      cout  <<  value_popped_from_the_stack  <<  "   "  ;
   }

   cout << "\n" ;
}



