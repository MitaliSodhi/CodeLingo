
//  states.cpp (c) 1999-2002 Kari Laitinen

#include  <iostream.h>
#include  <string>

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


