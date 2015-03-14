
//  travel_database.cpp (c) 2000-2002 Kari Laitinen

//  25.11.2000  File created.
//  10.12.2002  Last modification.

//  This program is a "companion" to program "travel.cpp".
//  With this program it is possible to create and update
//  the file "travel_database.data" which "travel.cpp" uses
//  to present travelling information to its users.

#include  <iostream.h>
#include  <iomanip.h>
#include  <fstream.h>
#include  <math.h>
#include  <string>
#include  <sstream>
#include  <vector>

#include  "useful_functions.h"
#include  "useful_functions_advanced.h"

#include  "travel_database_initial_data.h"

#include  "class_text.h"
#include  "class_place_on_earth.h"
#include  "class_travel_database_application.h"


int main()
{
   Travel_database_application  this_travel_database_application ;

   this_travel_database_application.run() ;
}













