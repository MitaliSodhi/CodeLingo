
//  person_test.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <string.h>

/*  This is a modified version of person.cpp.
    This program prints the contents of those memory 
    areas where the structure variables reside.
*/

#include  "useful_functions.h"

struct  Person
{
   char  person_name[ 30 ] ;
   int   year_of_birth ;
   char  country_of_origin[ 20 ] ;
} ;

void  print_person_data( Person  given_person )
{
   cout << "\n   "         << given_person.person_name  
        << " was born in " << given_person.country_of_origin
        << " in "          << given_person.year_of_birth ;
}

int main()
{
   Person  computing_pioneer ;

   strcpy( computing_pioneer.person_name, "Alan Turing" ) ;
   computing_pioneer.year_of_birth  =  1912 ;
   strcpy( computing_pioneer.country_of_origin, "England" ) ;

   Person  another_computing_pioneer  =
                     { "Konrad Zuse", 1910, "Germany" } ;

   print_person_data( computing_pioneer ) ;
   print_person_data( another_computing_pioneer ) ;

   print_memory_contents( &another_computing_pioneer,
                          54 + 54 ) ;
}


