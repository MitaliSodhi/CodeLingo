
//  pointer_arithmetics.cpp  (c) 1998-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   int    array_of_integers[ ]  =  { 111, 222, 333, 444, 555 } ;

   int*   an_integer_in_array ;

   cout << "\n This program uses a pointer to print an initialized"
        << "\n array. The following is the array in normal order:"
        << "\n\n    " ;

   an_integer_in_array   =   &array_of_integers[ 0 ] ;

   cout <<  *an_integer_in_array          << "   "
        <<  *( an_integer_in_array + 1 )  << "   "
        <<  *( an_integer_in_array + 2 )  << "   "
        <<  *( an_integer_in_array + 3 )  << "   "
        <<  *( an_integer_in_array + 4 )  << "\n\n" ;

   cout << " And the following is the array in reverse order: \n\n ";

   for (  an_integer_in_array   =  &array_of_integers[ 4 ]  ;
          an_integer_in_array  >=  &array_of_integers[ 0 ]  ;
          an_integer_in_array  --  )
   {
      cout  << "   " <<  *an_integer_in_array  ;
   }
}



