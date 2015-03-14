 
//  AllOlympics.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-14  File created.
//  2004-11-14  Last modification.

//  A solution to Exercise 11-17.

using System ;

class  Olympics
{
   char    olympics_type ;
   int     olympic_year  ;
   string  olympic_city ;
   string  olympic_country ;

   public Olympics( char   given_olympics_type,
                    int    given_olympic_year,
                    string given_olympic_city,
                    string given_olympic_country )
   {
      olympics_type   =  given_olympics_type ;
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

   public bool these_are_summer_games()
   {
      return ( olympics_type  ==  's' ) ;
   }

   public bool these_are_winter_games()
   {
      return ( olympics_type  ==  'w' ) ;
   }

   public void print_olympics_data()
   {
      string  olympics_type_to_print ;

      if ( olympics_type  ==  's' )
      {
         olympics_type_to_print  =  "Summer" ;
      }
      else
      {
         olympics_type_to_print  =  "Winter" ;
      }

      Console.Write( "\n    In "  +  olympic_year  +  ", "
           +  olympics_type_to_print
           +  " Olympic Games were held in " +  olympic_city
           +  ", "  +  olympic_country  ) ;
   }
} 

class  OlympicsDataFinder
{
   static Olympics[]  olympics_table  =  new Olympics[ 200 ] ;


   static void search_olympics_of_certain_year()
   {
      Console.Write("\n Give a year by using four digits: "  ) ;

      int given_year = Convert.ToInt32( Console.ReadLine() ) ;

      int  olympics_index  =  0 ;

      bool olympics_data_was_found  =  false ;

      bool table_search_ready  =  false ;

      while ( table_search_ready  ==  false )
      {
         if ( olympics_table[ olympics_index ]  ==  null )
         {
            table_search_ready  =  true ;
         }
         else if ( olympics_table[ olympics_index ].get_year()
                                                        == given_year )
         {
            olympics_table[ olympics_index ].print_olympics_data() ;

            olympics_data_was_found  =  true ;
         }

         olympics_index  ++  ;
      }

      if ( olympics_data_was_found  ==  false )
      {
         Console.Write( "\n    Sorry, no Olympic Games were held in "
                     +  given_year  + ".\n" ) ;
      }
   }   

   static void search_olympics_held_in_a_certain_country()
   {
      Console.Write("\n Give the name of a country: "  ) ;

      string  given_country  =   Console.ReadLine() ;

      Console.Write( "\n Olympic Games held in \""  +  given_country
                  +  "\" are the following: \n" ) ;

      int  olympics_index  =  0 ;

      bool olympics_data_was_found  =  false ;

      bool table_search_ready  =  false ;

      while ( table_search_ready  ==  false )
      {
         if ( olympics_table[ olympics_index ]  ==  null )
         {
            table_search_ready  =  true ;
         }
         else if (( olympics_table[ olympics_index ].get_olympic_country()
                    .ToLower().IndexOf( given_country.ToLower() ) != -1 ) )
         {
            olympics_table[ olympics_index ].print_olympics_data() ;
            
            olympics_data_was_found  =  true ;
         }

         olympics_index  ++  ;
      }
   
      if ( olympics_data_was_found  ==  false )
      {
         Console.Write( "\n    Sorry, no Olympic Games were held in "
                     +  "a country named \""  +  given_country  + "\".\n" ) ;
      }
   }

   static void search_olympics_held_in_a_certain_city()
   {
      Console.Write("\n Give the name of a city: "  ) ;

      string  given_city  =   Console.ReadLine() ;

      Console.Write( "\n Olympic Games held in \""  +  given_city
                  +  "\" are the following: \n" ) ;

      int  olympics_index  =  0 ;

      bool olympics_data_was_found  =  false ;

      bool table_search_ready  =  false ;

      while ( table_search_ready  ==  false )
      {
         if ( olympics_table[ olympics_index ]  ==  null )
         {
            table_search_ready  =  true ;
         }
         else if (( olympics_table[ olympics_index ].get_olympic_city()
                    .ToLower().IndexOf( given_city.ToLower() ) != -1 ) )
         {
            olympics_table[ olympics_index ].print_olympics_data() ;
            
            olympics_data_was_found  =  true ;
         }

         olympics_index  ++  ;
      }
   
      if ( olympics_data_was_found  ==  false )
      {
         Console.Write( "\n    Sorry, no Olympic Games were held in "
                     +  "a city named \""  +  given_city  + "\".\n" ) ;
      }
   }

   static void list_all_summer_games()
   {
      Console.Write( "\n The Olympic Summer Games are the following: \n" ) ;

      int  olympics_index  =  0 ;

      while ( olympics_table[ olympics_index ]  !=  null )
      {
         if ( olympics_table[ olympics_index ].these_are_summer_games() )
         {
            olympics_table[ olympics_index ].print_olympics_data() ;
         }

         olympics_index  ++  ;
      }
   
   }

   static void list_all_winter_games()
   {
      Console.Write( "\n The Olympic Winter Games are the following: \n" ) ;

      int  olympics_index  =  0 ;

      while ( olympics_table[ olympics_index ]  !=  null )
      {
         if ( olympics_table[ olympics_index ].these_are_winter_games() )
         {
            olympics_table[ olympics_index ].print_olympics_data() ;
         }

         olympics_index  ++  ;
      }
   
   }

   static void Main()
   {
      olympics_table[ 0 ] = new Olympics( 's', 1896, "Athens",   "Greece" ) ;
      olympics_table[ 1 ] = new Olympics( 's', 1900, "Paris",    "France" ) ;
      olympics_table[ 2 ] = new Olympics( 's', 1904, "St. Louis", "U.S.A." );
      olympics_table[ 3 ] = new Olympics( 's', 1906, "Athens",   "Greece"  ) ; 
      olympics_table[ 4 ] = new Olympics( 's', 1908, "London", "Great Britain");
      olympics_table[ 5 ] = new Olympics( 's', 1912, "Stockholm","Sweden" ) ;
      olympics_table[ 6 ] = new Olympics( 's', 1920, "Antwerp",  "Belgium"   ) ;
      olympics_table[ 7 ] = new Olympics( 's', 1924, "Paris",    "France"    ) ;
      olympics_table[ 8 ] = new Olympics( 's', 1928, "Amsterdam","Netherlands");
      olympics_table[ 9 ] = new Olympics( 's', 1932, "Los Angeles", "U.S.A.");
      olympics_table[ 10 ] = new Olympics( 's', 1936, "Berlin",  "Germany"   ) ;
      olympics_table[ 11 ] = new Olympics( 's', 1948, "London","Great Britain");
      olympics_table[ 12 ] = new Olympics( 's', 1952, "Helsinki","Finland"  ) ;
      olympics_table[ 13 ] = new Olympics( 's', 1956, "Melbourne","Australia" ) ;
      olympics_table[ 14 ] = new Olympics( 's', 1960, "Rome",     "Italy"   ) ;
      olympics_table[ 15 ] = new Olympics( 's', 1964, "Tokyo",    "Japan"   ) ;
      olympics_table[ 16 ] = new Olympics( 's', 1968, "Mexico City","Mexico" ) ;
      olympics_table[ 17 ] = new Olympics( 's', 1972, "Munich", "West Germany");
      olympics_table[ 18 ] = new Olympics( 's', 1976, "Montreal", "Canada"  ) ;
      olympics_table[ 19 ] = new Olympics( 's', 1980, "Moscow", "Soviet Union");
      olympics_table[ 20 ] = new Olympics( 's', 1984, "Los Angeles","U.S.A.");
      olympics_table[ 21 ] = new Olympics( 's', 1988, "Seoul",  "South Korea");
      olympics_table[ 22 ] = new Olympics( 's', 1992, "Barcelona","Spain"   ) ;
      olympics_table[ 23 ] = new Olympics( 's', 1996, "Atlanta", "U.S.A." );
      olympics_table[ 24 ] = new Olympics( 's', 2000, "Sydney",  "Australia" ) ;
      olympics_table[ 25 ] = new Olympics( 's', 2004, "Athens",  "Greece"  ) ;
      olympics_table[ 26 ] = new Olympics( 's', 2008, "Beijing", "China"   ) ;

      //  New summer Olympics data should be added to the end of the table.

      olympics_table[ 27 ] = new Olympics( 'w', 1924, "Chamonix",    "France") ;
      olympics_table[ 28 ] = new Olympics( 'w', 1928, "St.Moritz",
                                                               "Switzerland");
      olympics_table[ 29 ] = new Olympics( 'w', 1932, "Lake Placid", "U.S.A.");
      olympics_table[ 30 ] = new Olympics( 'w', 1936, "Garmisch-Partenkirchen",
                                                               "Germany"   ) ;
      olympics_table[ 31 ] = new Olympics( 'w', 1948, "St.Moritz",
                                                               "Switzerland");
      olympics_table[ 32 ] = new Olympics( 'w', 1952, "Oslo",  "Norway"  ) ;
      olympics_table[ 33 ] = new Olympics( 'w',1956, "Cortina d'Ampezzo",
                                                               "Italy" );
      olympics_table[ 34 ] = new Olympics( 'w', 1960, "Squaw Valley","U.S.A." );
      olympics_table[ 35 ] = new Olympics( 'w', 1964, "Innsbruck", "Austria" ) ;
      olympics_table[ 36 ] = new Olympics( 'w', 1968, "Grenoble",    "France" );
      olympics_table[ 37 ] = new Olympics( 'w', 1972, "Sapporo",  "Japan");
      olympics_table[ 38 ] = new Olympics( 'w', 1976, "Innsbruck","Austria"  ) ;
      olympics_table[ 39 ] = new Olympics( 'w', 1980, "Lake Placid","U.S.A.");
      olympics_table[ 40 ] = new Olympics( 'w', 1984, "Sarajevo", "Yugoslavia");
      olympics_table[ 41 ] = new Olympics( 'w', 1988, "Calgary",  "Canada");
      olympics_table[ 42 ] = new Olympics( 'w', 1992, "Albertville","France" );
      olympics_table[ 43 ] = new Olympics( 'w', 1994, "Lillehammer","Norway" );
      olympics_table[ 44 ] = new Olympics( 'w', 1998, "Nagano",   "Japan" ) ;
      olympics_table[ 45 ] = new Olympics( 'w', 2002, "Salt Lake City",
                                                                  "U.S.A." ) ;
      olympics_table[ 46 ] = new Olympics( 'w', 2006, "Turin",    "Italy"   ) ;
      olympics_table[ 47 ] = new Olympics( 'w', 2010, "Vancouver","Canada" ) ;

      //  The "end" of olympics data in olympics_table is here detected
      //  in the same way as in program Planets.cs, i.e., an array element
      //  contains a null when it does not reference an object.


      Console.Write("\n This program can tell where the Winter Olympic "
                  + "\n Games were held in a given year. Give a year"
                  + "\n by using four digits: "  ) ;

      string  user_selection  =  "????" ;

      while ( user_selection[ 0 ]  !=  '6' )
      {
         Console.Write( "\n\n  Select according to the following menu: \n"
                     +  "\n  1  Search Olympics of certain year  "
                     +  "\n  2  Search Olympics held in a certain country "
                     +  "\n  3  Search Olympics held in a certain city "
                     +  "\n  4  List all Summer Games "
                     +  "\n  5  List all Winter Games "
                     +  "\n  6  Exit the program  \n\n    " ) ;

         user_selection  =  Console.ReadLine() ;

         if ( user_selection[ 0 ]  ==  '1' )
         {
            search_olympics_of_certain_year() ;
         }
         else if ( user_selection[ 0 ]  ==  '2' )
         {
            search_olympics_held_in_a_certain_country() ;
         }
         else if ( user_selection[ 0 ]  ==  '3' )
         {
            search_olympics_held_in_a_certain_city() ;
         }
         else if ( user_selection[ 0 ]  ==  '4' )
         {
            list_all_summer_games() ;
         }
         else if ( user_selection[ 0 ]  ==  '5' )
         {
            list_all_winter_games() ;
         }
      }

   }
}



