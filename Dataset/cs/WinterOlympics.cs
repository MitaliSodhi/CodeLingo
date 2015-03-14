 
//  WinterOlympics.cs  (c) 2003 Kari Laitinen

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

   public int Year
   {
      get
      {
         return  olympic_year ;
      }
   }

   public void print_olympics_data()
   {
      Console.Write( "\n    In "  +  olympic_year 
           +  ", Winter Olympic Games were held in " +  olympic_city
           +  ", "  +  olympic_country  +  ".\n" ) ;
   }
} 

class  WinterOlympicsDataFinder
{
   static void Main()
   {
      Olympics[]  olympics_table  =  new Olympics[ 40 ] ;

      olympics_table[ 0 ] = new Olympics( 1924, "Chamonix",    "France"    ) ;
      olympics_table[ 1 ] = new Olympics( 1928, "St.Moritz",   "Switzerland");
      olympics_table[ 2 ] = new Olympics( 1932, "Lake Placid", "U.S.A.");
      olympics_table[ 3 ] = new Olympics( 1936, "Garmisch-Partenkirchen",
                                                               "Germany"   ) ;
      olympics_table[ 4 ] = new Olympics( 1948, "St.Moritz",   "Switzerland");
      olympics_table[ 5 ] = new Olympics( 1952, "Oslo",        "Norway"  ) ;
      olympics_table[ 6 ] = new Olympics( 1956, "Cortina d'Ampezzo","Italy" ) ;
      olympics_table[ 7 ] = new Olympics( 1960, "Squaw Valley","U.S.A."   ) ;
      olympics_table[ 8 ] = new Olympics( 1964, "Innsbruck",   "Austria" ) ;
      olympics_table[ 9 ] = new Olympics( 1968, "Grenoble",    "France" ) ;
      olympics_table[ 10 ] = new Olympics( 1972, "Sapporo",    "Japan");
      olympics_table[ 11 ] = new Olympics( 1976, "Innsbruck",  "Austria"  ) ;
      olympics_table[ 12 ] = new Olympics( 1980, "Lake Placid","U.S.A.");
      olympics_table[ 13 ] = new Olympics( 1984, "Sarajevo",   "Yugoslavia");
      olympics_table[ 14 ] = new Olympics( 1988, "Calgary",    "Canada");
      olympics_table[ 15 ] = new Olympics( 1992, "Albertville","France"   ) ;
      olympics_table[ 16 ] = new Olympics( 1994, "Lillehammer","Norway" );
      olympics_table[ 17 ] = new Olympics( 1998, "Nagano",     "Japan" ) ;
      olympics_table[ 18 ] = new Olympics( 2002, "Salt Lake City","U.S.A." ) ;
      olympics_table[ 19 ] = new Olympics( 2006, "Turin",      "Italy"   ) ;
      olympics_table[ 20 ] = new Olympics( 2010, "Vancouver",  "Canada" ) ;
      olympics_table[ 21 ] = new Olympics( 9999, "end of",   "data"  ) ;


      Console.Write("\n This program can tell where the Winter Olympic "
                  + "\n Games were held in a given year. Give a year"
                  + "\n by using four digits: "  ) ;

      int given_year = Convert.ToInt32( Console.ReadLine() ) ;

      int  olympics_index  =  0 ;

      bool table_search_ready  =  false ;

      while ( table_search_ready  ==  false )
      {
         if ( olympics_table[ olympics_index ].Year  ==  given_year )
         {
            olympics_table[ olympics_index ].print_olympics_data() ;

            table_search_ready  =  true ;
         }
         else if ( olympics_table[ olympics_index ].Year  ==  9999 )
         {
            Console.Write( "\n    Sorry, no Winter Olympics were held in "
                           +  given_year  + ".\n" ) ;

            table_search_ready  =  true ;
         }
         else
         {
            olympics_index  ++  ;
         }
      }
   }
}



