
//  stack_in_file.cpp  (c) 1998-2002 Kari Laitinen

//  This program is a somewhat advanced version of program
//  "stack.cpp". This program behaves like "stack.cpp", but
//  two new member functions have been added to class Stack
//  in this version. With these new member functions, it is
//  possible to store the stack contents to a file, and 
//  load stack contents from a file. These member functions
//  are called in function main. These member functions
//  demonstrate, how objects with varying memory requirements
//  can be stored in binary files.


#include <iostream.h>
#include <fstream.h>

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

   void store_to_file(  char  given_file_name[] ) ;
   void load_from_file( char  given_file_name[] ) ;
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

void Stack::store_to_file( char  given_file_name[] )
{
   ofstream  output_file( given_file_name, ios::binary ) ;

   if ( output_file.fail() )
   {
      cout << "\n  ERROR -- could not open file \""
           << given_file_name  << "\"\n" ;
   }
   else
   {
      output_file.write( (char*) &number_of_items_on_stack,
                          sizeof( int ) ) ;

      output_file.write(

             (char*)  stack_memory_space,
             sizeof( int ) * number_of_items_on_stack ) ;
   }
}

void Stack::load_from_file( char  given_file_name[] )
{
   ifstream  input_file( given_file_name, ios::binary ) ;

   if ( input_file.fail() )
   {
      cout << "\n  ERROR -- could not open file \""
           << given_file_name  << "\"\n" ;
   }
   else
   {
      input_file.read( (char*) &number_of_items_on_stack,
                        sizeof( int ) ) ;

      //  We will get rid of the possibly-existing old stack.

      delete [] stack_memory_space ;

      stack_memory_space = new int[ number_of_items_on_stack ] ;

      current_stack_size  =  number_of_items_on_stack ;

      input_file.read(

             (char*)  stack_memory_space,
             sizeof( int ) * number_of_items_on_stack ) ;
   }
}


int main()
{
   int  value_to_the_stack ;
   int  value_popped_from_the_stack ;

   Stack  first_stack ;

   cout << "\n Let's test stacks. Please, type in integers."
           "\n I will push those numbers onto a stack and store"
           "\n the stack to a file. Then I will define another"
           "\n stack object which will take the contents of the"
           "\n first stack object from the file. The numbers"
           "\n will be popped from the second stack. I will stop"
           "\n asking numbers when you type in a zero."
           "\n Please, press <Enter> after each number. \n\n" ;
   do
   {
      cout  <<  " Give a number:  " ;
      cin   >>  value_to_the_stack ;

      first_stack.push( value_to_the_stack ) ;
   }  
     while  ( value_to_the_stack  !=  0  ) ;

   first_stack.store_to_file( "first_stack_contents.data" ) ;

   Stack  second_stack ;

   second_stack.load_from_file( "first_stack_contents.data" ) ;

   cout << "\n The numbers popped from the stack are: \n\n " ;

   while ( second_stack.stack_is_not_empty() )
   {
      second_stack.pop(  value_popped_from_the_stack ) ;

      cout  <<  value_popped_from_the_stack  <<  "   "  ;
   }

   cout << "\n" ;
}



