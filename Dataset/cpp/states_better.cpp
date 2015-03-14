
//  states_better.cpp (c) 1999-2004 Kari Laitinen

//  This program works in the same way as states.cpp
//  but this one includes the file <iostream> instead of
//  <iostream.h> and there is the appropriate using statement.
//  This program can probably be compiled with a wider range of
//  of C++ compilers as this is a more standard C++ program.

#include  <iostream>
#include  <string>    // class string etc.

using namespace std ;

int main()
{
   string  states_in_usa ;

   string  westmost_state  =  "Hawaii" ;
   string  prairie_state   =  "Illinois" ;

   states_in_usa  =  westmost_state + "  " + prairie_state ;

   cout << "\n   "  <<  states_in_usa ;

   string  golden_state    =  "California" ;

   states_in_usa.insert( 6, golden_state ) ;
   states_in_usa.insert( 6, "  " ) ;

   cout << "\n   "  <<  states_in_usa ;

   string  eastmost_state  =  "Maine" ;

   states_in_usa.append( "  Virginia  " ) ;
   states_in_usa.append( eastmost_state ) ;

   cout << "\n   "  <<  states_in_usa ;

   int index_of_last_state  =  states_in_usa.rfind( "  " ) ;

   states_in_usa.erase( index_of_last_state ) ;
   states_in_usa.append( "  Massachusetts" ) ;

   cout << "\n   "  <<  states_in_usa ;

   states_in_usa.replace( states_in_usa.find( "Illinois" ),
                          8, "Michigan" ) ;

   cout << "\n   "  <<  states_in_usa  <<  "\n" ;
}


