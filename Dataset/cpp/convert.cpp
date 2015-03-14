
//  convert.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <string.h>
#include  <stdlib.h>

struct  Conversion
{
   char    first_unit[ 20 ] ;
   char    second_unit[ 20 ] ;
   double  conversion_constant ;
} ;

Conversion  conversion_table[]  =
{
   { "meters",         "yards",        1.093613 },
   { "meters",         "feet",         3.280840 },
   { "miles",          "kilometers",   1.609344  },
   { "inches",         "centimeters",  2.54 },
   { "acres",          "hectares",     0.4046873  },
   { "pounds",         "kilograms",    0.4535924  },
   { "ounces",         "grams",        28.35      },
   { "gallons (U.S.)", "liters",       3.785      },
   { "gallons (Br.)",  "liters",       4.546      },
   { "pints (U.S.)",   "liters",       0.473      },
   { "pints (Br.)",    "liters",       0.568      },
   { "joules",         "calories",     4.187      },
   { "lightyears",     "kilometers",   9.461e12   }
} ;

int main( int    number_of_command_line_arguments,
          char*  command_line_arguments[] )
{
   char unit_from_user[ 20 ] ;
   int  amount_to_convert ;

   int  line_index  =  0  ;
   int  number_of_lines_in_table = sizeof( conversion_table ) /
                                   sizeof( Conversion ) ;

   if ( number_of_command_line_arguments  ==  3 )
   {
      strcpy( unit_from_user, command_line_arguments[ 1 ] ) ;
      amount_to_convert  =  atoi( command_line_arguments[ 2 ] ) ;
   }
   else
   {
      cout  <<  "\n Give the unit to convert from: " ;
      cin   >>  unit_from_user ;
      cout  <<  " Give the amount to convert:   " ;
      cin   >>  amount_to_convert ;
   }

   while ( line_index  <  number_of_lines_in_table  )
   {
      if ( strstr( conversion_table[ line_index ].first_unit,
                   unit_from_user ) )
      {
         cout << "\n  " << amount_to_convert << " "
              << conversion_table[ line_index ].first_unit
              << " is " << amount_to_convert *
                 conversion_table[ line_index ].conversion_constant
              << " "
              << conversion_table[ line_index ].second_unit ;
      }

      if ( strstr( conversion_table[ line_index ].second_unit,
                   unit_from_user ) )
      {
         cout << "\n  " << amount_to_convert << " "
              << conversion_table[ line_index ].second_unit
              << " is " << amount_to_convert /
                 conversion_table[ line_index ].conversion_constant
              << " "
              << conversion_table[ line_index ].first_unit ;
      }

      line_index  ++  ;
   }
}



