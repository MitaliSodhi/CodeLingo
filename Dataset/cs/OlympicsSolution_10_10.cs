 
//  OlympicsSolution_10_10.cs  (c) 2004 Kari Laitinen

//  A solution to exercise 10-10. Also the solution to
//  Exercise 10-7 is included in this program.

//  The specification of Exercise 10-10 is somewhat
//  inadequate in the first version of the book. Thus,
//  if this exercise turned out to be difficult, it is
//  not necessarily your fault but mine.

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

   public string get_olympic_city()
   {
      return  olympic_city ;
   }

   public string get_olympic_country()
   {
      return  olympic_country ;
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
   static  Olympics[]  olympics_table  =  new Olympics[ 40 ] ;


   static void search_year_in_olympics_table( int year_to_search )
   {
      int  olympics_index  =  0 ;

      bool table_search_ready  =  false ;

      while ( table_search_ready  ==  false )
      {
         if ( olympics_table[ olympics_index ]  ==  null )
         {
            Console.Write( "\n    Sorry, no Olympic Games were held in "
                           +  year_to_search  + ".\n" ) ;

            table_search_ready  =  true ;
         }
         else if ( olympics_table[ olympics_index ].get_year()
                                                     == year_to_search )
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
   
   static void search_string_in_olympics_table( string string_to_search )
   {
      int  olympics_index  =  0 ;

      bool table_search_ready  =  false ;

      while ( table_search_ready  ==  false )
      {
         if ( olympics_table[ olympics_index ]  ==  null )
         {
            table_search_ready  =  true ;
         }
         else if (( olympics_table[ olympics_index ].get_olympic_city()
                    .ToLower().IndexOf( string_to_search.ToLower() ) != -1 ) ||
                  ( olympics_table[ olympics_index ].get_olympic_country()
                    .ToLower().IndexOf( string_to_search.ToLower() ) != -1 ) )
         {
            olympics_table[ olympics_index ].print_olympics_data() ;
            
            olympics_index  ++  ;
         }
         else
         {
            olympics_index  ++  ;
         }
      }
   
   }

   static void Main()
   {
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


      Console.Write("\n This program can show information about Olympic "
                  + "\n Games. Please, give a year by using four digits "
                  + "\n or give a city or country name:   "  ) ;

      string  string_from_user  =   Console.ReadLine() ;

      if ( string_from_user[ 0 ] >= '0' &&
           string_from_user[ 0 ] <= '9' )
      {
         // The user typed in a number.
         int given_year  =  Convert.ToInt32( string_from_user ) ;
         search_year_in_olympics_table( given_year ) ;
      }
      else
      {
         search_string_in_olympics_table( string_from_user ) ;
      }
      
   }
}



