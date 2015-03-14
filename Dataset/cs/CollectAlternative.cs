
//  CollectAlternative.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  This program works in the same way as program Collect.cs,
//  but the following modifications have been made:
//
//  The methods store_to_file() and load_from_file() of class
//  Collection are modified in this version.
//  This version stores data to file in a slightly different
//  way. The number of CollectionItem objects is stored before
//  the data of the objects. Because the data file produced
//  by this program is not compatible by the collection_items.data
//  file produced by Collect.cs, the used file name is
//  collection_items_alternative.data.
//
//  This version has a method named Equals() in place of 
//  is_equal_to() in class CollectionItem. That Equals() method
//  overrides the Equals() method that is inherited from class
//  Object.

using System ;
using System.IO ;  // Classes for file handling.

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

   public CollectionItem( BinaryReader file_containing_collection_data )
   {
      item_name   =  file_containing_collection_data.ReadString() ;
      item_maker  =  file_containing_collection_data.ReadString() ;
      item_type   =  file_containing_collection_data.ReadString() ;
      year_of_making  =  file_containing_collection_data.ReadInt32() ;
   }

   public string get_item_name()  { return item_name ; }
   public string get_item_maker() { return item_maker ; }
   public string get_item_type()  { return item_type ; }
   public int    get_year_of_making() { return year_of_making ; }

   public override bool Equals( object another_object )
   {
      bool  objects_are_equal  =  false ;

      if ( another_object  !=  null  &&
           another_object  is  CollectionItem )
      {
         CollectionItem  another_collection_item  =
                                (CollectionItem)  another_object ;

         if ( item_name   ==  another_collection_item.item_name  &&
              item_maker  ==  another_collection_item.item_maker &&
              item_type   ==  another_collection_item.item_type  &&
              year_of_making  ==  another_collection_item.year_of_making )
         {
            objects_are_equal  =  true ;
         }
      }

      return  objects_are_equal ;
   }


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


class  Collection
{
   const int  MAXIMUM_NUMBER_OF_ITEMS  =  100 ;

   CollectionItem[] items_in_this_collection  =  
                        new  CollectionItem[ MAXIMUM_NUMBER_OF_ITEMS ] ;

   int  number_of_items_in_collection  =  0 ;

   public int get_number_of_items()
   {
      return number_of_items_in_collection ;
   }

   public CollectionItem search_item_with_name( string given_item_name )

   {
      bool item_has_been_found  =  false ;
      int  item_index           =  0 ;

      while ( item_has_been_found  ==  false  &&
              item_index  <  number_of_items_in_collection )
      { 
         if ( items_in_this_collection[ item_index ].
                   get_item_name().IndexOf( given_item_name ) !=  -1 )
         {
            item_has_been_found    =  true  ;
         }
         else
         {
            item_index  ++  ;
         }
      }

      if ( item_has_been_found  ==  true )
      {
         return  items_in_this_collection[ item_index ] ;
      }
      else
      {
         return  null  ;
      }
   }

 
   public void print_all_items()
   {
      int  item_index  =  0 ;

      while ( item_index  <  number_of_items_in_collection )
      {
         Console.Write( 
            items_in_this_collection[ item_index ].to_line_of_text() ) ;
         item_index  ++  ;
      }
   }

   public void add_new_item( CollectionItem new_collection_item )
   {
      if ( number_of_items_in_collection  >=  MAXIMUM_NUMBER_OF_ITEMS )
      {
         Console.Write( "\n Cannot add new collection items!!!! \n" ) ;
      }
      else if ( new_collection_item.get_item_name().Length  ==  0 )
      {
         Console.Write( "\n Invalid collection item data!!!! \n" ) ;
      }
      else
      {
         items_in_this_collection[ number_of_items_in_collection ]
                                       =   new_collection_item ;
         number_of_items_in_collection  ++  ;
      }
   }

   public void remove_all_items()
   {
      number_of_items_in_collection  =  0 ;
   }

   public void remove_one_item( CollectionItem  item_to_remove )
   {
      bool item_has_been_found  =  false ;
      int  item_index           =  0 ;

      while ( item_has_been_found  ==  false  &&
              item_index  <  number_of_items_in_collection )
      { 
         if ( items_in_this_collection[ item_index ].
                                           Equals( item_to_remove )  )
         {
            item_has_been_found    =  true  ;
         }
         else
         {
            item_index  ++  ;
         }
      }

      if ( item_has_been_found  ==  true )
      {
         //  Item will be removed by moving later items one
         //  position upwards in the array of items.

         while ( item_index  <
                       ( number_of_items_in_collection - 1 ) )
         {
            items_in_this_collection[ item_index ]  =
                        items_in_this_collection[ item_index + 1 ] ;
            item_index  ++  ;
         }

         number_of_items_in_collection  --  ;
      }
   }

   public  Collection  get_items_of_maker( string given_item_maker )
   {
      Collection  collection_to_return  =  new  Collection() ;

      for ( int item_index  =  0 ;
                item_index  <  number_of_items_in_collection ;
                item_index  ++ )
      {
         if ( items_in_this_collection[ item_index ].
                    get_item_maker().IndexOf( given_item_maker )  !=  -1 )
         {
            collection_to_return.add_new_item(
                             items_in_this_collection[ item_index ] ) ;
         }
      }

      return  collection_to_return ;
   }

   public  Collection  get_items_of_type( string given_item_type )
   {
      Collection  collection_to_return  =  new  Collection() ;

      for ( int item_index  =  0 ;
                item_index  <  number_of_items_in_collection ;
                item_index  ++ )
      {
         if ( items_in_this_collection[ item_index ].
                    get_item_type().IndexOf( given_item_type )  !=  -1 )
         {
            collection_to_return.add_new_item(
                             items_in_this_collection[ item_index ] ) ;
         }
      }

      return  collection_to_return ;
   }

   public void store_to_file()
   {
      try
      {
         FileStream file_stream  =  File.Open(
                            "collection_items_alternative.data",
                                               FileMode.Create,
                                               FileAccess.Write ) ;

         BinaryWriter collection_file  =  new  BinaryWriter( file_stream ) ;

         collection_file.Write( number_of_items_in_collection ) ;

         for ( int item_index  =  0 ;
                   item_index  <  number_of_items_in_collection ;
                   item_index  ++  )
         {
            items_in_this_collection[ item_index ].
                                 store_to_file( collection_file ) ;
         }

         collection_file.Close() ;

         Console.Write( "\n Collection items have been stored.  \n\n" ) ;
      }
      catch ( Exception )
      {
         Console.Write( "\n\n Error in writing file collection_items.data. "
                     +  "\n Collection items are not stored.  \n\n" )  ;
      }
   }


   public void load_from_file() 
   {
      try
      {
         FileStream file_stream  =  File.OpenRead(
                                 "collection_items_alternative.data" ) ;

         BinaryReader  collection_file  =  new  BinaryReader( file_stream ) ;

         int  item_index  =  0 ;

         CollectionItem   item_from_file   ;

         number_of_items_in_collection  =  collection_file.ReadInt32() ;

         while ( item_index  <  number_of_items_in_collection )
         {
            item_from_file  =  new  CollectionItem( collection_file ) ;

            items_in_this_collection[ item_index ]  =  item_from_file ;

            item_index  ++  ;
         }

         collection_file.Close() ;

         Console.Write( "\n Collection items have been loaded.  \n\n" ) ;
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
}


class  CollectionMaintainer
{
   Collection  this_collection  =  new  Collection() ;

   bool user_confirms( string text_to_confirm )
   {
      //  This method returns true if user types in 'Y' or 'y'.

      bool  user_gave_positive_answer  =  false ;

      string  user_response  =   "?????" ;

      while ( user_response[ 0 ] != 'Y'  &&  user_response[ 0 ] != 'y' &&
              user_response[ 0 ] != 'N'  &&  user_response[ 0 ] != 'n' )
      {
         Console.Write( text_to_confirm ) ;
         user_response  =  Console.ReadLine() ;

         if ( user_response.Length  ==  0 )
         {
            user_response  =  "?????" ;
         }
         else if ( user_response[ 0 ] == 'Y'  ||  user_response[ 0 ] == 'y' )
         {
            user_gave_positive_answer  =  true ;
         }
      }

      return  user_gave_positive_answer ;
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

      this_collection.add_new_item( new_collection_item ) ;
      Console.Write( "\n New item has been added to collection. " ) ;
   } 

   void  remove_collection_item() 
   {
      Console.Write( "\n Give the name of the item to remove: " ) ;
      string  item_name_from_user  =  Console.ReadLine() ;

      CollectionItem  item_to_remove  = 
          this_collection.search_item_with_name( item_name_from_user ) ;

      if ( item_to_remove  !=  null )
      {
         //  An item was found in the collection.

         Console.Write( "\n This collection item was found: "
                     +  item_to_remove.to_line_of_text() ) ;

         if ( user_confirms( "\n Remove this item ( Y/N )?" ) )
         {
            this_collection.remove_one_item( item_to_remove ) ;
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
      Collection  items_to_print  =  null ;

      Console.Write(  "\n Type in a letter according to menu: \n"
                   +  "\n    a    Print all collection items. "
                   +  "\n    t    Print certain types of items. "
                   +  "\n    m    Print items according to maker's name."
                   +  "\n\n    " ) ;

      string  user_selection  =  Console.ReadLine() ;

      if ( user_selection[ 0 ]  ==  'a' )
      {
         items_to_print  =  this_collection ;
      }
      else if ( user_selection[ 0 ]  ==  't' )
      {
         Console.Write( "\n Give the type of the items to be printed: " ) ;
         string  item_type_from_user  =  Console.ReadLine() ;

         items_to_print  =  this_collection.
                                 get_items_of_type( item_type_from_user ) ;
      }
      else if ( user_selection[ 0 ]  ==  'm' )
      {
         Console.Write( "\n Give the name of the maker of the item: " ) ;
         string  item_maker_from_user  =  Console.ReadLine() ;

         items_to_print  =  this_collection.
                                 get_items_of_maker( item_maker_from_user ) ;
      }

      if ( items_to_print  !=  null )
      {
         items_to_print.print_all_items() ;
      }
   }


   void  initialize_collection_with_test_data() 
   {
      this_collection.remove_all_items() ;

      this_collection.add_new_item(  new  CollectionItem(
        "Les Demoiselles d'Avignon","Pablo Picasso",  "painting", 1907 ) );
      this_collection.add_new_item(  new  CollectionItem(
        "The Third of May 1808", "Francisco de Goya", "painting", 1808 ) );
      this_collection.add_new_item(  new  CollectionItem(
        "Dejeuner sur l'Herbe",  "Eduard Manet",      "painting", 1863 ) );
      this_collection.add_new_item(  new  CollectionItem(
        "Mona Lisa",             "Leonardo da Vinci", "painting", 1503 ) );
      this_collection.add_new_item(  new  CollectionItem(
        "David",                 "Michelangelo",      "statue",   1501 ) );
      this_collection.add_new_item(  new  CollectionItem(
        "The Night Watch",       "Rembrandt",         "painting", 1642 ) );
      this_collection.add_new_item(  new  CollectionItem(
        "Guernica",              "Pablo Picasso",     "painting", 1937 ) );
      this_collection.add_new_item(  new  CollectionItem(
        "Ulysses",               "James Joyce",       "manuscript", 1922 ));
      this_collection.add_new_item(  new  CollectionItem(
        "The Egyptian",          "Mika Waltari",      "manuscript", 1946 ));
      this_collection.add_new_item(  new  CollectionItem(
        "For Whom the Bell Tolls", "Ernest Hemingway","manuscript", 1941 ));
   }


   public void run()
   {
      string  user_selection  =  "???????" ;

      Console.Write( "\n This program is a system to help a collector"
                  +  "\n to maintain information about his or her"
                  +  "\n valuable collection items.\n" ) ;

      while  (  user_selection[ 0 ]  !=  'q' )
      {
         Console.Write( "\n\n There are currently "
            +  this_collection.get_number_of_items()
            +  " items in the collection. "
            +  "\n Choose what to do by typing in a letter "
            +  "\n according to the following menu: \n"

            +  "\n    a   Add a new collection item. "
            +  "\n    r   Remove a collection item. "
            +  "\n    p   Print data of collection items. "
            +  "\n    s   Store collection data to file. "
            +  "\n    l   Load collection data from file. "
            +  "\n    i   Initialize collection with test data. "
            +  "\n    q   Quit the system.\n\n    " ) ;

         user_selection  =  Console.ReadLine() ;

         if ( user_selection.Length  ==  0 )
         {
            Console.Write( "\n Please type in a letter." ) ;
            user_selection  =  "?" ;
         }
         else if ( user_selection[ 0 ]  ==  'a' )
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
            this_collection.store_to_file() ;
         }
         else if ( user_selection[ 0 ]  ==  'l' )
         {
            this_collection.load_from_file() ;
         }
         else if ( user_selection[ 0 ]  ==  'i' )
         {
            initialize_collection_with_test_data() ;
         }
      }
   }
}

class Collect
{
   static void Main()
   {
      CollectionMaintainer  collection_maintainer  =
                                      new  CollectionMaintainer() ;
      collection_maintainer.run() ;
   }
}






