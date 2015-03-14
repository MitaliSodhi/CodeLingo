
//  olympics.cpp  (c) 1999-2002 Kari Laitinen

#include  <iostream.h>

#define  SEARCH_NOT_READY      0
#define  SEARCH_IS_READY       1

struct  Olympics
{
   int   olympic_year  ;
   char  olympic_city[ 20 ] ;
   char  olympic_country[ 20 ] ;
} ;

Olympics  olympics_table[] =
{
  { 1896,   "Athens",          "Greece"        },
  { 1900,   "Paris",           "France"        },
  { 1904,   "St. Louis",       "United States" },
  { 1906,   "Athens",          "Greece"        }, 
  { 1908,   "London",          "Great Britain" },
  { 1912,   "Stockholm",       "Sweden"        },
  { 1920,   "Antwerp",         "Belgium"       },
  { 1924,   "Paris",           "France"        },
  { 1928,   "Amsterdam",       "The Netherlands"},
  { 1932,   "Los Angeles",     "United States" },
  { 1936,   "Berlin",          "Germany"       },
  { 1948,   "London",          "Great Britain" },
  { 1952,   "Helsinki",        "Finland"       },
  { 1956,   "Melbourne",       "Australia"     },
  { 1960,   "Rome",            "Italy"         },
  { 1964,   "Tokyo",           "Japan"         },
  { 1968,   "Mexico City",     "Mexico"        },
  { 1972,   "Munich",          "West Germany"  },
  { 1976,   "Montreal",        "Canada"        },
  { 1980,   "Moscow",          "Soviet Union"  },
  { 1984,   "Los Angeles",     "United States" },
  { 1988,   "Seoul",           "South Korea"   },
  { 1992,   "Barcelona",       "Spain"         },
  { 1996,   "Atlanta",         "United States" },
  { 2000,   "Sydney",          "Australia"     },
  { 2004,   "Athens",          "Greece"        },
  { 2008,   "Beijing",         "China"         },
  { 9999,   "end of table",    "end of table"  }
} ;

int main()
{
   int  given_year ;

   cout << "\n This program can tell you where the modern Olympic "
        << "\n Games were held in a given year. Please, give a year "
        << "\n by using four digits: " ;

   cin  >>  given_year ;

   int  olympics_index       =  0 ;
   int  table_search_status  =  SEARCH_NOT_READY ;

   while ( table_search_status  ==  SEARCH_NOT_READY )
   {
      if ( olympics_table[ olympics_index ].olympic_year  ==  given_year )
      {
         cout << "\n    In "  <<  given_year
              << ", the Olympic Games were held in "
              << olympics_table[ olympics_index ].olympic_city  << ", "
              << olympics_table[ olympics_index ].olympic_country
              << ".\n" ;

         table_search_status  =  SEARCH_IS_READY ;
      }
      else if ( olympics_table[ olympics_index ].olympic_year  ==  9999 )
      {
         cout <<  "\n    Sorry, no Olympic Games were held in "
              <<  given_year  <<  ".\n" ;

         table_search_status  =  SEARCH_IS_READY ;
      }
      else
      {
         olympics_index  ++  ;
      }
   }
}



