 
//  OlympicsSolutions_10_7.cs  (c) 2004 Kari Laitinen

//  Solution to exercise 10-7.

//  http://www.naturalprogramming.com

//  2004-11-06  File created.
//  2004-11-06  Last modification.

using System ;

class  Olympics
{
   int     olympic_year  ;
   string  olympic_city ;
   string  olympic_country ;

   public Olympics( int    given_olympic_year,
                    string given_olympic_city,
                    string given_olympic_country )
   {
      olympic_year    =  given_olympic_year ;
      olympic_city    =  given_olympic_city ;
      olympic_country =  given_olympic_country ;
   }

   public int get_year()
   {
      return  olympic_year ;
   }

   public void print_olympics_data()
   {
      Console.Write( "\n    In "  +  olympic_year  +
              ", Olympic Games were held in " +  olympic_city  +
              ", "  +  olympic_country  +  ".\n" ) ;
   }
} 

class  OlympicsDataFinder
{
   static void Main()
   {
      Olympics[]  olympics_table  =  new Olympics[ 40 ] ;

      olympics_table[ 0 ] = new Olympics( 1896, "Athens",   "Greece" ) ;
      olympics_table[ 1 ] = new Olympics( 1900, "Paris",    "France" ) ;
      olympics_table[ 2 ] = new Olympics( 1904, "St. Louis", "U.S.A." );
      olympics_table[ 3 ] = new Olympics( 1906, "Athens",   "Greece"  ) ; 
      olympics_table[ 4 ] = new Olympics( 1908, "London",   "Great Britain");
      olympics_table[ 5 ] = new Olympics( 1912, "Stockholm","Sweden" ) ;
      olympics_table[ 6 ] = new Olympics( 1920, "Antwerp",  "Belgium"   ) ;
      olympics_table[ 7 ] = new Olympics( 1924, "Paris",    "France"    ) ;
      olympics_table[ 8 ] = new Olympics( 1928, "Amsterdam","Netherlands");
      olympics_table[ 9 ] = new Olympics( 1932, "Los Angeles", "U.S.A.");
      olympics_table[ 10 ] = new Olympics( 1936, "Berlin",  "Germany"   ) ;
      olympics_table[ 11 ] = new Olympics( 1948, "London",  "Great Britain");
      olympics_table[ 12 ] = new Olympics( 1952, "Helsinki","Finland"  ) ;
      olympics_table[ 13 ] = new Olympics( 1956, "Melbourne","Australia" ) ;
      olympics_table[ 14 ] = new Olympics( 1960, "Rome",     "Italy"   ) ;
      olympics_table[ 15 ] = new Olympics( 1964, "Tokyo",    "Japan"   ) ;
      olympics_table[ 16 ] = new Olympics( 1968, "Mexico City","Mexico" ) ;
      olympics_table[ 17 ] = new Olympics( 1972, "Munich",   "West Germany");
      olympics_table[ 18 ] = new Olympics( 1976, "Montreal", "Canada"  ) ;
      olympics_table[ 19 ] = new Olympics( 1980, "Moscow",   "Soviet Union");
      olympics_table[ 20 ] = new Olympics( 1984, "Los Angeles","U.S.A.");
      olympics_table[ 21 ] = new Olympics( 1988, "Seoul",    "South Korea");
      olympics_table[ 22 ] = new Olympics( 1992, "Barcelona","Spain"   ) ;
      olympics_table[ 23 ] = new Olympics( 1996, "Atlanta",  "U.S.A." );
      olympics_table[ 24 ] = new Olympics( 2000, "Sydney",   "Australia" ) ;
      olympics_table[ 25 ] = new Olympics( 2004, "Athens",   "Greece"  ) ;
      olympics_table[ 26 ] = new Olympics( 2008, "Beijing",  "China"   ) ;


      Console.Write("\n This program can tell where the Olympic "
                  + "\n Games were held in a given year. Give "
                  + "\n a year by using four digits: "  ) ;

      int given_year = Convert.ToInt32( Console.ReadLine() ) ;

      int  olympics_index  =  0 ;

      bool table_search_ready  =  false ;

      while ( table_search_ready  ==  false )
      {
         //  To solve the problem presented in Exercise 10-7, we
         //  have to first test whether the end of table has been
         //  reached. After we are sure that there is an Olympics
         //  object in the table, we can check its olympic year.

         if ( olympics_table[ olympics_index ]  ==  null )
         {
            Console.Write( "\n    Sorry, no Olympic Games were held in "
                           +  given_year  + ".\n" ) ;

            table_search_ready  =  true ;
         }
         else if ( olympics_table[ olympics_index ].get_year() == given_year )
         {
            olympics_table[ olympics_index ].print_olympics_data() ;

            table_search_ready  =  true ;
         }
         else
         {
            olympics_index  ++  ;
         }
      }
   }
}



