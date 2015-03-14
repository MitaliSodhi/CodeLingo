
//  stack_template.cpp  (c) 1998-2002 Kari Laitinen

#include <iostream.h>
#include <string.h>

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
   cout << "\n Let's push the characters of a string onto"
           "\n a stack and reverse the string by popping the"
           "\n characters away from the stack." ;

   char  string_from_keyboard[ 80 ] ;

   cout  <<  "\n\n Please, type in a string:  " ;
   cin.getline( string_from_keyboard,
                sizeof( string_from_keyboard ) ) ;

   Stack_template<char>  character_stack ;

   for ( int character_index  =  0 ;
             character_index  <  strlen( string_from_keyboard ) ;
             character_index  ++  )
   {
      character_stack.push( string_from_keyboard[ character_index ] ) ;
   }

   cout  << "\n The string in reverse order: " ;

   char  character_from_stack ;

   while ( character_stack.stack_is_not_empty() )
   {
      character_stack.pop( character_from_stack ) ;
      cout  <<  character_from_stack ;
   }
}


