
//  virtualism.cpp (c) 2000-2002 Kari Laitinen

/*  10.12.2002  Last modification.

    This program was used to study the virtual function table
    and objects derived from classes that have virtual
    member functions.

    It seems that Borland C++ 5.5.1 puts the pointer to
    the virtual function table into the beginning of every
    object.

---------------------------------------------------------------*/

#include  <iostream.h>

#include  "useful_functions.h"

void  print_hexadecimal( int  given_integer  )
{
   //  Here we suppose that the least significant byte of
   //  an int variable has the smallest memory address.

   char*  a_byte_in_given_integer  =  (char*) &given_integer ;

   int  number_of_bytes_to_print  =  sizeof( int ) ;

   while (  number_of_bytes_to_print  >  0  )
   {
      number_of_bytes_to_print  --  ;
      print_hexadecimal(  *( a_byte_in_given_integer +
                                number_of_bytes_to_print ) ) ;
   }
}


void  print_hexadecimal( int  array_of_integers[],
                         int  number_of_numbers_to_print  )
{
   for ( int integer_index  =  0 ;
             integer_index  <  number_of_numbers_to_print ;
             integer_index  ++ )
   {
      cout << "\n" ;
      print_hexadecimal( array_of_integers[ integer_index ] ) ;
   }
}

void  print_hexadecimal_with_address( int  array_of_integers[],
                                      int  number_of_numbers_to_print  )
{
   for ( int integer_index  =  0 ;
             integer_index  <  number_of_numbers_to_print ;
             integer_index  ++ )
   {
      cout << "\n" ;
      print_hexadecimal( (int) &array_of_integers[ integer_index ] ) ;
      cout << "  " ;
      print_hexadecimal( array_of_integers[ integer_index ] ) ;
   }
}

class  Base_class
{
protected:
   int  base_member_a, base_member_b ;

public:
   Base_class()
   {
      base_member_a  =  0x8888 ;
      base_member_b  =  0x8899 ;
   }

   virtual void some_function()
   {
      cout << "\n some_function of Base_class was called." ;
   }

   virtual void another_function()
   {
      cout << "\n another_function of Base_class was called." ;
   }

   virtual void show_object()
   {
      print_hexadecimal_with_address( (int*) this,  4 ) ;

      cout << " that was data area of Base_class object " ;

      print_hexadecimal_with_address( (int*) (* ( (int*) this )), 3 ) ;

      cout << " that was virtual function table of Base_class " ;
   }
} ;


class  Derived_class  :  public  Base_class
{
protected:
   int derived_member ;
public:
   Derived_class()
   {
      base_member_a  =  0xAAAA ;
      base_member_b  =  0xAABB ;
      derived_member =  0xBBBB ;
   }

   void some_function()
   {
      cout << "\n some_function of Derived_class was called." ;
   }

   void another_function()
   {
      cout << "\n another_function of Derived_class was called." ;
   }

   void show_object()
   {
      print_hexadecimal_with_address( (int*) this,  4 ) ;

      cout << " that was data area of Derived_class object " ;

      print_hexadecimal_with_address( (int*) (* ( (int*) this )), 3 ) ;

      cout << " that was virtual function table of Derived_class " ;
   }
} ;


int main()
{

   Base_class     first_object ;
   Derived_class  second_object ;

   Base_class*  third_object  = new Derived_class() ;

   first_object.show_object() ;
   second_object.show_object() ;

   third_object -> show_object() ;

   cout << "\n The size is "  <<  sizeof( Derived_class ) ;

}




