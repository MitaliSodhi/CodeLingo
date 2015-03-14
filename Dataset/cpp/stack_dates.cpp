
//  stack_dates.cpp  (c) 2001-2002 Kari Laitinen

#include <iostream.h>
#include <string.h>

#include "class_date.h"

#define   STACK_INCREMENT_SIZE   4

template <class Type>
class  Stack_template
{
protected:
   int    number_of_items_on_stack ;
   int    current_stack_size ;
   Type*  stack_memory_space ;

public:
   Stack_template( int requested_stack_size  =  STACK_INCREMENT_SIZE ) ;
   ~Stack_template() ;

   void push( Type   item_to_the_stack ) ;
   void pop(  Type&  item_from_the_stack ) ;

   bool  stack_is_not_empty() ;
} ;

template <class Type>
Stack_template<Type>::Stack_template( int  requested_stack_size )
{
   stack_memory_space  =  new  Type[ requested_stack_size ] ;

   current_stack_size  =  requested_stack_size ;

   number_of_items_on_stack    =  0 ;
}

template <class Type>
Stack_template<Type>::~Stack_template()
{
   delete  []  stack_memory_space ;
}

template <class Type>
void  Stack_template<Type>::push( Type item_to_the_stack )
{
   if ( number_of_items_on_stack  >=  current_stack_size  )
   {
      //  We must increase the size of this stack instance.

      Type*  new_stack_memory_space ;

      new_stack_memory_space  =  new  Type[ current_stack_size +
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

      cout  <<  "\n STACK HAS GROWN.\n" ;
   }

   //  Here we push the new value to the stack.

   stack_memory_space[ number_of_items_on_stack ]  =
                                      item_to_the_stack ;
   number_of_items_on_stack  ++  ;
}

template <class Type>
void  Stack_template<Type>::pop( Type&  item_from_the_stack )
{

   if  ( number_of_items_on_stack  ==  0 )
   {
      cout  <<  "\n ERROR: Attempt to pop on empty stack!\n" ;
   }
   else
   {
      number_of_items_on_stack  -- ;
      item_from_the_stack  =
              stack_memory_space[ number_of_items_on_stack ] ;
   }
}

template <class Type>
bool  Stack_template<Type>::stack_is_not_empty()
{
   return  ( number_of_items_on_stack  >  0  ) ;
}

int main()
{
   cout << "\n Let's test a stack. Please, type in dates."
           "\n I will push those dates onto a stack, and later"
           "\n take them away from the stack. I will stop reading"
           "\n numbers when you type in date 01/01/2222"
           "\n Please, press <Enter> after each date. \n\n" ;

   Stack_template<Date>   date_stack ;

   char  date_as_string[ 20 ] ;

   Date  date_to_stack ;
   Date  last_input_date( "01/01/2222" ) ;

   do
   {
      cout << " Give a date in format MM/DD/YYYY:  " ;
      cin  >> date_as_string ;

      date_to_stack  =  Date( date_as_string ) ;
 
      date_stack.push( date_to_stack ) ;
   }  
     while  ( date_to_stack  !=  last_input_date ) ;


   cout  <<  "\n  Here are the dates in reverse order: \n" ;

   while ( date_stack.stack_is_not_empty() )
   {
      Date date_from_stack ;

      date_stack.pop( date_from_stack ) ;
      cout  <<  "\n   "  <<  date_from_stack ;
   }
}



