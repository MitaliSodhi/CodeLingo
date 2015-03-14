
//  array.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>
#include  <iomanip.h>

int main()
{
   int  array_of_integers[ 50 ] ;
   int  integer_index ;

   array_of_integers[ 0 ]  =  333 ;
   array_of_integers[ 1 ]  =   33 ;
   array_of_integers[ 2 ]  =    3 ;
   array_of_integers[ 3 ]  =  array_of_integers[ 2 ]  +  2 ;

   for ( integer_index  =  4 ;
         integer_index  <  50 ;
         integer_index  ++ )
   {
      array_of_integers[ integer_index ]  =
                array_of_integers[ integer_index - 1 ]  +  2 ;
   }

   cout << "\n The contents of \"array_of_integers\" is:\n" ;

   for ( integer_index  =  0 ;
         integer_index  <  50 ;
         integer_index  ++ )
   {
      if ( ( integer_index  %  10 )  ==  0 )
      {
         cout  <<  "\n" ;
      }

      cout <<  setw( 5 )  <<  array_of_integers[ integer_index ] ;
   }
}


