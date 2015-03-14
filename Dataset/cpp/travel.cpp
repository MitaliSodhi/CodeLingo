
//  travel.cpp (c) 2000-2002 Kari Laitinen

//  07.11.2000  File created.
//  10.12.2002  Last modification.

/* To understand this program, you need to understand the
   basics of Earth's geometry.

   Angles are commonly measured in degrees. The ball surface
   of the Earth is divided horizontally into latitudes and
   vertically into longitudes which have certain angles
   in relation to the central point of the ball (the earth).

   To express angles more exactly, there are subunits
   "minute" and "second" in use. The following rules
   apply:

      - 1 degree is 60 minutes
      - 1 minute is 60 seconds

   Radian is a more mathematical unit of an angle.
   For example, 90 degrees is half of pi radians, and
   the full circle, 360 degrees, is two times pi radians.
   pi is approximately 3.14159

*/

#include  <iostream.h>
#include  <iomanip.h>
#include  <fstream.h>
#include  <math.h>
#include  <string>
#include  <sstream>
#include  <vector>

#include  "useful_functions.h"
#include  "useful_functions_advanced.h"

#include  "class_text.h"
#include  "class_place_on_earth.h"
#include  "class_travel_application.h"


int main( int   number_of_command_line_arguments,
          char* command_line_arguments[] )
{
   Travel_application  this_travel_application ;

   if ( number_of_command_line_arguments  ==  2 )
   {
      this_travel_application.search_place_or_country(
                           string( command_line_arguments[ 1 ] ) );
   }
   else if ( number_of_command_line_arguments  ==  3 )
   {
      this_travel_application.print_data_of_place_in_country(
                           string( command_line_arguments[ 1 ] ),
                           string( command_line_arguments[ 2 ] ) ) ;
   }
   else if ( number_of_command_line_arguments  ==  4 )
   {
      //  The search functions behave so that they indicate
      //  a successful search when they are given an empty string.

      this_travel_application.print_distance_between_places(

                         string( command_line_arguments[ 1 ] ),
                         string( command_line_arguments[ 2 ] ),
                         string( command_line_arguments[ 3 ] ),
                         string( "" ) ) ;
   }
   else if ( number_of_command_line_arguments  ==  5 )
   {
      this_travel_application.print_distance_between_places(

                         string( command_line_arguments[ 1 ] ),
                         string( command_line_arguments[ 2 ] ),
                         string( command_line_arguments[ 3 ] ),
                         string( command_line_arguments[ 4 ] ) ) ;
   }
   else
   {
      this_travel_application.run() ;
   }
}











