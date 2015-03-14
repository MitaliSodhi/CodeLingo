
//  OlympicsObjectOriented.cpp  (c) 1998-2006 Kari Laitinen

//  http://www.naturalprogramming.com

//  2006-06-11  File created.
//  2006-06-11  Last modification.

//  This is an object-oriented version of program Olympics.cpp.
//  This is not presented in the C++ book. This version corresponds
//  to the programs Olympics.java, Olympics.cs and Olympics.py that
//  are available at http://www.naturalprogramming.com

#include  <iostream.h>
#include  <string.h>
#include  "useful_constants.h"

class  Olympics
{
protected:
   int   olympic_year  ;
   char  olympic_city[ 30 ] ;
   char  olympic_country[ 20 ] ;

public:

   Olympics() {}  //  default constructor

   Olympics( int  given_olympic_year,
             char given_olympic_city[],
             char given_olympic_country[] )
   {
      olympic_year  =  given_olympic_year ;
      strcpy( olympic_city, given_olympic_city ) ;
      strcpy( olympic_country, given_olympic_country ) ;
   }

   int   get_year()
   {
      return  olympic_year ;
   }

   void  print_olympics_data()
   {
      cout << "\n    In "  <<  olympic_year
           << ", Olympic Games were held in " << olympic_city
           << ", "  <<  olympic_country  << ".\n" ;
   }
} ;

int main()
{
   Olympics olympics_table[ 40 ] ;

   olympics_table[ 0 ] = Olympics( 1896, "Athens",   "Greece" ) ;
   olympics_table[ 1 ] = Olympics( 1900, "Paris",    "France" ) ;
   olympics_table[ 2 ] = Olympics( 1904, "St. Louis", "U.S.A." );
   olympics_table[ 3 ] = Olympics( 1906, "Athens",   "Greece"  ) ; 
   olympics_table[ 4 ] = Olympics( 1908, "London",   "Great Britain");
   olympics_table[ 5 ] = Olympics( 1912, "Stockholm","Sweden" ) ;
   olympics_table[ 6 ] = Olympics( 1920, "Antwerp",  "Belgium"   ) ;
   olympics_table[ 7 ] = Olympics( 1924, "Paris",    "France"    ) ;
   olympics_table[ 8 ] = Olympics( 1928, "Amsterdam","Netherlands");
   olympics_table[ 9 ] = Olympics( 1932, "Los Angeles", "U.S.A.");
   olympics_table[ 10 ] = Olympics( 1936, "Berlin",  "Germany"   ) ;
   olympics_table[ 11 ] = Olympics( 1948, "London",  "Great Britain");
   olympics_table[ 12 ] = Olympics( 1952, "Helsinki","Finland"  ) ;
   olympics_table[ 13 ] = Olympics( 1956, "Melbourne","Australia" ) ;
   olympics_table[ 14 ] = Olympics( 1960, "Rome",     "Italy"   ) ;
   olympics_table[ 15 ] = Olympics( 1964, "Tokyo",    "Japan"   ) ;
   olympics_table[ 16 ] = Olympics( 1968, "Mexico City","Mexico" ) ;
   olympics_table[ 17 ] = Olympics( 1972, "Munich",   "West Germany");
   olympics_table[ 18 ] = Olympics( 1976, "Montreal", "Canada"  ) ;
   olympics_table[ 19 ] = Olympics( 1980, "Moscow",   "Soviet Union");
   olympics_table[ 20 ] = Olympics( 1984, "Los Angeles","U.S.A.");
   olympics_table[ 21 ] = Olympics( 1988, "Seoul",    "South Korea");
   olympics_table[ 22 ] = Olympics( 1992, "Barcelona","Spain"   ) ;
   olympics_table[ 23 ] = Olympics( 1996, "Atlanta",  "U.S.A." );
   olympics_table[ 24 ] = Olympics( 2000, "Sydney",   "Australia" ) ;
   olympics_table[ 25 ] = Olympics( 2004, "Athens",   "Greece"  ) ;
   olympics_table[ 26 ] = Olympics( 2008, "Beijing",  "China"   ) ;
   olympics_table[ 27 ] = Olympics( 2012, "London",   "Great Britain");
   olympics_table[ 28 ] = Olympics( 9999, "end of",   "data"  ) ;

   int  given_year ;

   cout << "\n This program can tell you where the summer Olympic "
        << "\n Games were held in a given year. Please, give a year "
        << "\n using four digits: " ;

   cin  >>  given_year ;

   int  olympics_index       =  0 ;
   int  table_search_status  =  SEARCH_NOT_READY ;

   while ( table_search_status  ==  SEARCH_NOT_READY )
   {
      if ( olympics_table[ olympics_index ].get_year() == given_year )
      {
         olympics_table[ olympics_index ].print_olympics_data() ;

         table_search_status  =  SEARCH_IS_READY ;
      }
      else if ( olympics_table[ olympics_index ].get_year()  ==  9999 )
      {
         cout <<  "\n\n    Sorry, no Olympic Games were held in "
              <<  given_year  <<  ".\n" ;

         table_search_status  =  SEARCH_IS_READY ;
      }
      else
      {
         olympics_index  ++  ;
      }
   }
}




