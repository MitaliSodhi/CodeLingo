
//  winter_olympics.cpp  (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  "useful_constants.h"

class  Olympics
{
protected:
   int   olympic_year  ;
   char  olympic_city[ 30 ] ;
   char  olympic_country[ 20 ] ;

public:

   int   get_year()
   {
      return  olympic_year ;
   }

   void  print_olympics_data()
   {
      cout << "\n    In "  <<  olympic_year
           << ", Winter Olympics were held in " << olympic_city
           << ", "  <<  olympic_country  << ".\n" ;
   }
} ;

Olympics   olympics_table[] =
{
   { 1924,   "Chamonix",               "France"        },
   { 1928,   "St. Moritz",             "Switzerland"   },
   { 1932,   "Lake Placid",            "United States" },
   { 1936,   "Garmisch-Partenkirchen", "Germany"       },
   { 1948,   "St. Moritz",             "Switzerland"   },
   { 1952,   "Oslo",                   "Norway"        },
   { 1956,   "Cortina d'Ampezzo",      "Italy"         },
   { 1960,   "Squaw Valley",           "United States" },
   { 1964,   "Innsbruck",              "Austria"       },
   { 1968,   "Grenoble",               "France"        },
   { 1972,   "Sapporo",                "Japan"         },
   { 1976,   "Innsbruck",              "Austria"       },
   { 1980,   "Lake Placid",            "United States" },
   { 1984,   "Sarajevo",               "Yugoslavia"    },
   { 1988,   "Calgary",                "Canada"        },
   { 1992,   "Albertville",            "France"        },
   { 1994,   "Lillehammer",            "Norway"        },
   { 1998,   "Nagano",                 "Japan"         },
   { 2002,   "Salt Lake City",         "United States" },
   { 2006,   "Turin",                  "Italy"         },
   { 9999,   "end of table",           "end of table"  }
} ;

int main()
{
   int  given_year ;

   cout << "\n This program can tell you where the Winter Olympic "
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




