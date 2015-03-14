
//  ConvertObjectOriented.cpp (c) 1998-2006 Kari Laitinen

//  http://www.naturalprogramming.com

//  2006-06-11  File created.
//  2006-06-11  Last modification.

//  This is an object-oriented version of program Convert.cpp.
//  This is not presented in the C++ book. This version corresponds
//  to the programs Convert.java, Convert.cs and Convert.py that
//  are available at http://www.naturalprogramming.com

#include  <iostream.h>
#include  <string.h>
#include  <stdlib.h>

class  Conversion
{
protected:
   char    first_unit[ 20 ] ;
   char    second_unit[ 20 ] ;
   double  conversion_constant ;

public:
   Conversion()  {}  // default constructor

   Conversion( char  given_first_unit[],
               char  given_second_unit[],
               double  given_conversion_constant )
   {
      strcpy( first_unit, given_first_unit ) ;
      strcpy( second_unit, given_second_unit ) ;
      conversion_constant  =  given_conversion_constant ;
   }

   void convert( char   given_unit[],
                 double amount_to_convert )
   {
      if ( strstr( first_unit, given_unit ) )
      {
         cout << "\n  " << amount_to_convert << " " << first_unit
              << " is " << amount_to_convert * conversion_constant
              << " " << second_unit ;
      }

      if ( strstr( second_unit, given_unit ) )
      {
         cout << "\n  " << amount_to_convert << " "  << second_unit
              << " is " << amount_to_convert / conversion_constant
              << " " << first_unit ;
      }
   }
} ;


int main( int    number_of_command_line_arguments,
          char*  command_line_arguments[] )
{
   Conversion conversion_table[ 13 ] ;

   conversion_table[ 0 ] = Conversion("meters", "yards", 1.093613 );
   conversion_table[ 1 ] = Conversion("meters", "feet",  3.280840 );
   conversion_table[ 2 ] = Conversion("miles",  "kilometers",1.609344);
   conversion_table[ 3 ] = Conversion("inches", "centimeters", 2.54 );
   conversion_table[ 4 ] = Conversion("acres",  "hectares", 0.4046873);
   conversion_table[ 5 ] = Conversion("pounds", "kilograms",0.4535924);
   conversion_table[ 6 ] = Conversion("ounces", "grams",    28.35 );
   conversion_table[ 7 ] = Conversion("gallons (U.S.)","liters", 3.785);
   conversion_table[ 8 ] = Conversion("gallons (Br.)", "liters", 4.546);
   conversion_table[ 9 ] = Conversion("pints (U.S.)",  "liters", 0.473);
   conversion_table[ 10 ]= Conversion("pints (Br.)",   "liters", 0.568);
   conversion_table[ 11 ]= Conversion("joules",       "calories",4.187);
   conversion_table[ 12 ]= Conversion("lightyears",   "kilometers",
                                                              9.461e12 ) ;
   char unit_from_user[ 20 ] ;
   int  amount_to_convert ;

   int  number_of_conversions_in_table = sizeof( conversion_table ) /
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

   for ( int conversion_index  =  0 ;
             conversion_index  <  number_of_conversions_in_table ;
             conversion_index  ++ )
   {
      conversion_table[ conversion_index ].convert( unit_from_user,
                                                    amount_to_convert ) ;
   }
}



