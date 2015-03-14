
//  Collect.cs  (c) 2003 Kari Laitinen

//  www.naturalprogramming.com

using System ;
using System.IO ;  // Classes for file handling.

/****
#define   ITEM_NAME_SIZE                 80
#define   HUMAN_NAME_SIZE                30
#define   ITEM_TYPE_SIZE                 20
*****/


class CollectionItem
{
   string  item_name ;
   string  item_maker ;
   string  item_type ;
   int     year_of_making ;

   public CollectionItem( string given_item_name,
                          string given_item_maker,
                          string given_item_type,
                          int    given_year_of_making )
   {
      item_name   =  given_item_name ;
      item_maker  =  given_item_maker ;
      item_type   =  given_item_type ;
      year_of_making  =  given_year_of_making ;
   }

   public CollectionItem( BinaryReader file_containing_collection_item_data )
   {
      item_name   =  file_containing_collection_item_data.ReadString() ;
      item_maker  =  file_containing_collection_item_data.ReadString() ;
      item_type   =  file_containing_collection_item_data.ReadString() ;
      year_of_making  =  file_containing_collection_item_data.ReadInt32() ;
   }


   public string get_item_name()  { return item_name ; }
   public string get_item_maker() { return item_maker ; }
   public string get_item_type()  { return item_type ; }

   public string to_line_of_text()
   {
      return ( "\n  "  +  item_name.PadRight( 30 )
            +  item_maker.PadRight( 20 )  +  item_type.PadRight( 15 )
            +  year_of_making.ToString().PadRight( 10 ) ) ; 
   }

   public void store_to_file( BinaryWriter  binary_file )
   {
      binary_file.Write( item_name ) ;
      binary_file.Write( item_maker ) ;
      binary_file.Write( item_type ) ;
      binary_file.Write( year_of_making ) ;
   }

}

class  CollectionManager
{
   const int  COLLECTION_TABLE_SIZE  =  100 ;

   CollectionItem[]  collection_table  =  
                        new  CollectionItem[ COLLECTION_TABLE_SIZE ] ;

   int  number_of_items_in_collection ;


   bool user_confirms( string text_to_confirm )
   {
      //  This method returns true if user types in 'Y' or 'y'.

      bool  user_gave_positive_answer  =  false ;

      string  user_response  =   "?????" ;

      while ( user_response[ 0 ]  !=  'Y'  &&
              user_response[ 0 ]  !=  'y'  &&
              user_response[ 0 ]  !=  'N'  &&
              user_response[ 0 ]  !=  'n'  )
      {
         Console.Write( text_to_confirm ) ;
         user_response  =  Console.ReadLine() ;

         if ( user_response[ 0 ]  ==  'Y'  ||
              user_response[ 0 ]  ==  'y'  )
         {
            user_gave_positive_answer  =  true ;
         }
      }

      return  user_gave_positive_answer ;
   }

   bool
   search_collection_item( string              item_name_to_search,

                           out int             index_of_found_item,
                           out CollectionItem  found_collection_item )
   {
      //  This method returns true if the item was found.

      bool item_has_been_found  =  false ;
      int  item_index           =  0 ;

      while ( item_has_been_found  ==  false  &&
              item_index  <  number_of_items_in_collection )
      { 
         if ( collection_table[ item_index ].get_item_name().IndexOf(
                                          item_name_to_search ) !=  -1 )
         {
            item_has_been_found    =  true  ;
         }
         else
         {
            item_index  ++  ;
         }
      }

      found_collection_item  =  collection_table[ item_index ] ;
      index_of_found_item    =  item_index ;

      return  item_has_been_found  ;
   }

 
   void
   print_collection_table( CollectionItem[]  given_collection_table,
                           int               number_of_items_to_print )
   {
      int  item_index  =  0 ;

      while ( item_index  <  number_of_items_to_print )
      {
         Console.Write( 
            given_collection_table[ item_index ].to_line_of_text() ) ;
         item_index  ++  ;
      }
   }

   void  write_new_collection_item_to_table(
                         CollectionItem   new_collection_item )
   {
      if ( number_of_items_in_collection  >=
                                    COLLECTION_TABLE_SIZE )
      {
         Console.Write( "\n Collection table is full!!!! \n" ) ;
      }
      else if ( new_collection_item.get_item_name().Length  ==  0 )
      {
         Console.Write( "\n Invalid collection item data!!!! \n" ) ;
      }
      else
      {
         collection_table[ number_of_items_in_collection ]
                                       =   new_collection_item ;
         number_of_items_in_collection  ++  ;
      }
   }

   void  add_new_collection_item() 
   {
      Console.Write( "\n Give new collection item name: " ) ;
      string  item_name_of_the_new_item   =  Console.ReadLine() ;

      Console.Write( " Give the artist name: " ) ;
      string  item_maker_of_the_new_item  =  Console.ReadLine() ;

      Console.Write( " Give collection item type: " ) ;
      string  item_type_of_the_new_item   =  Console.ReadLine() ;

      Console.Write( " Give the year of making: "  ) ;
      int year_of_making_of_the_new_item  =
                     Convert.ToInt32( Console.ReadLine() ) ;

      CollectionItem  new_collection_item  = 
            new  CollectionItem( item_name_of_the_new_item,
                                 item_maker_of_the_new_item,
                                 item_type_of_the_new_item,
                                 year_of_making_of_the_new_item ) ;

      Console.Write( " Writing new collection item data to table ... " ) ;
      write_new_collection_item_to_table( new_collection_item ) ;
   } 

   void  remove_collection_item() 
   {
      Console.Write( "\n Give the name of the item to remove: " ) ;
      string  item_name_from_user  =  Console.ReadLine() ;

      int   index_of_item_to_remove ;
      CollectionItem   item_to_remove ;

      if ( search_collection_item( item_name_from_user,

                                   out index_of_item_to_remove,
                                   out item_to_remove ) )
      {
         Console.Write( "\n This collection item was found: "
                     +  item_to_remove.to_line_of_text() ) ;

         if ( user_confirms( "\n Remove this item ( Y/N )?" ) )
         {
            //  Item will be removed by moving later items one
            //  position upwards in the table.

            int  item_index  =  index_of_item_to_remove  ;

            while ( item_index  <
                       ( number_of_items_in_collection - 1 ) )
            {
               collection_table[ item_index ]  =
                           collection_table[ item_index + 1 ] ;
               item_index  ++  ;
            }

            number_of_items_in_collection  --  ;
         }
         else
         {
            Console.Write( "\n No item was removed. " ) ;
         }
      }
      else
      {
         Console.Write( "\n The item being searched was not found!!!!" ) ;
      }
   }

   void  print_data_of_collection_items() 
   {
      CollectionItem[] collection_table_for_printing
                        =  new  CollectionItem[ COLLECTION_TABLE_SIZE ] ;

      Console.Write(  "\n Type in a letter according to menu: \n"
           +  "\n    a    Print all collection items. "
           +  "\n    t    Print certain types of items. "
           +  "\n    m    Print items according to maker's name."
           +  "\n\n    " ) ;

      string  user_selection  =  Console.ReadLine() ;

      if ( user_selection[ 0 ]  ==  'a' )
      {
         print_collection_table( collection_table,
                                 number_of_items_in_collection ) ;
      }
      else if ( user_selection[ 0 ]  ==  't' )
      {
         Console.Write( "\n Give the type of the items to be printed: " ) ;
         string  item_type_from_user  =  Console.ReadLine() ;

         int  item_index  =  0 ;
         int  index_of_item_to_print  =  0 ;

         while ( item_index  <  number_of_items_in_collection )
         {
            if ( collection_table[ item_index ].get_item_type().IndexOf(
                                          item_type_from_user )  !=  -1 )
            {
               collection_table_for_printing[ index_of_item_to_print ]
                   =  collection_table[ item_index ] ;
               index_of_item_to_print  ++  ;
            }

            item_index  ++  ;
         }

         print_collection_table( collection_table_for_printing,
                                 index_of_item_to_print ) ;
      }
      else if ( user_selection[ 0 ]  ==  'm' )
      {
         Console.Write( "\n Give the name of the maker of the item: " ) ;
         string  item_maker_from_user  =  Console.ReadLine() ;

         int  item_index  =  0 ;
         int  index_of_item_to_print  =  0 ;

         while ( item_index  <  number_of_items_in_collection )
         {
            if ( collection_table[ item_index ].get_item_maker().IndexOf(
                                          item_maker_from_user )  !=  -1 )
            {
               collection_table_for_printing[ index_of_item_to_print ]
                   =  collection_table[ item_index ] ;
               index_of_item_to_print  ++  ;
            }

            item_index  ++  ;
         }

         print_collection_table( collection_table_for_printing,
                                 index_of_item_to_print ) ;
      }
   }


   void  store_collection_data_to_file()
   {
      try
      {
         FileStream file_stream  =  File.Open( "collection_items.data",
                                               FileMode.Create,
                                               FileAccess.Write ) ;

         BinaryWriter collection_file  =  new  BinaryWriter( file_stream ) ;

         for ( int item_index  =  0 ;
                   item_index  <  number_of_items_in_collection ;
                   item_index  ++  )
         {
            collection_table[ item_index ].store_to_file( collection_file ) ;
         }

         collection_file.Close() ;

         Console.Write( "\n Collection table has been stored.  \n\n" ) ;
      }
      catch ( Exception )
      {
         Console.Write( "\n\n Error in writing file collection_items.data. "
                     +  "\n Collection table is not stored.  \n\n" )  ;
      }
   }


   void  load_collection_data_from_file() 
   {
      try
      {
         FileStream file_stream  =  File.OpenRead( "collection_items.data" ) ;

         BinaryReader  collection_file  =  new  BinaryReader( file_stream ) ;

         int  item_index  =  0 ;

         CollectionItem   item_from_file   ;

         while ( collection_file.PeekChar()  !=  -1 )
         {
            item_from_file  =  new  CollectionItem( collection_file ) ;

            collection_table[ item_index ]  =  item_from_file ;

            item_index  ++  ;
         }

         number_of_items_in_collection  =  item_index  ;

         collection_file.Close() ;

         Console.Write( "\n Collection table has been loaded.  \n\n" ) ;
      }
      catch ( FileNotFoundException )
      {
         Console.Write( "\n File collection_items.data does not exist.\n" ) ;
      }
      catch ( Exception )
      {
         Console.Write( "\n Error in reading collection_items.data.\n" ) ;
      }
   }


   void  initialize_table_with_test_data() 
   {
      number_of_items_in_collection  =  0 ;

      write_new_collection_item_to_table(  new  CollectionItem(
        "Les Demoiselles d'Avignon","Pablo Picasso",  "painting", 1907 ) );
      write_new_collection_item_to_table(  new  CollectionItem(
        "The Third of May 1808", "Francisco de Goya", "painting", 1808 ) );
      write_new_collection_item_to_table(  new  CollectionItem(
        "Dejeuner sur l'Herbe",  "Eduard Manet",      "painting", 1863 ) );
      write_new_collection_item_to_table(  new  CollectionItem(
        "Mona Lisa",             "Leonardo da Vinci", "painting", 1503 ) );
      write_new_collection_item_to_table(  new  CollectionItem(
        "David",                 "Michelangelo",      "statue",   1501 ) );
      write_new_collection_item_to_table(  new  CollectionItem(
        "The Night Watch",       "Rembrandt",         "painting", 1642 ) );
      write_new_collection_item_to_table(  new  CollectionItem(
        "Guernica",              "Pablo Picasso",     "painting", 1937 ) );
      write_new_collection_item_to_table(  new  CollectionItem(
        "Ulysses",               "James Joyce",       "manuscript", 1922 ));
      write_new_collection_item_to_table(  new  CollectionItem(
        "The Egyptian",          "Mika Waltari",      "manuscript", 1946 ));
      write_new_collection_item_to_table(  new  CollectionItem(
        "For Whom the Bell Tolls", "Ernest Hemingway","manuscript", 1941 ));
   }


   public void run()
   {
      string  user_selection  =  "???????" ;

      Console.Write( "\n This program is a system to help a collector"
                  +  "\n to maintain information about his or her"
                  +  "\n valuable collection items.\n" ) ;

      number_of_items_in_collection  =  0 ;

      while  (  user_selection[ 0 ]  !=  'q' )
      {
         Console.Write(

            "\n\n There are currently "
         +  number_of_items_in_collection  + " items in the collection. "
         +  "\n Choose what to do by typing in a letter "
         +  "\n according to the following menu: \n"

         +  "\n    a   Add a new collection item. "
         +  "\n    r   Remove a collection item. "
         +  "\n    p   Print data of collection items. "
         +  "\n    s   Store collection data to file. "
         +  "\n    l   Load collection data from file. "
         +  "\n    i   Initialize table with test data. "
         +  "\n    q   Quit the system.\n\n    " ) ;

         user_selection  =  Console.ReadLine() ;

         if ( user_selection[ 0 ]  ==  'a' )
         {
            add_new_collection_item() ;
         }
         else if ( user_selection[ 0 ]  ==  'r' )
         {
            remove_collection_item() ;
         }
         else if ( user_selection[ 0 ]  ==  'p' ) 
         {
            print_data_of_collection_items() ;
         }
         else if ( user_selection[ 0 ]  ==  's' )
         {
            store_collection_data_to_file() ;
         }
         else if ( user_selection[ 0 ]  ==  'l' )
         {
            load_collection_data_from_file() ;
         }
         else if ( user_selection[ 0 ]  ==  'i' )
         {
            initialize_table_with_test_data() ;
         }
      } /* endwhile */
   }
}

class Collect
{
   static void Main()
   {
      CollectionManager  collection_manager  =  new  CollectionManager() ;

      collection_manager.run() ;
   }
}






