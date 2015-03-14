
//  c_style_collect.cpp (c) 1998-2002 Kari Laitinen

//  This program works in the same way as "collect.cpp".
//  The difference to program "collect.cpp" is that
//  C-style file handling functions "fwrite" and "fread"
//  are used in this version.

#include  <iostream.h>
#include  <iomanip.h>
#include  <stdio.h>  // C-style file handling functions.
#include  <stdlib.h>
#include  <string.h>

#define   COLLECTION_TABLE_SIZE         100
#define   ITEM_NAME_SIZE                 80
#define   HUMAN_NAME_SIZE                30
#define   ITEM_TYPE_SIZE                 20


struct  Collection_item
{
   char  item_name[ ITEM_NAME_SIZE ] ;
   char  item_maker[ HUMAN_NAME_SIZE ] ;
   char  item_type[ ITEM_TYPE_SIZE ] ;
   int   year_of_making ;
} ;

Collection_item  collection_table[ COLLECTION_TABLE_SIZE ] ;

int  number_of_items_in_collection ;

Collection_item  collection_table_for_testing[]  =
{
   { "Les Demoiselles d'Avignon", "Pablo Picasso",
     "painting", 1907 },
   { "The Third of May 1808",     "Francisco de Goya", 
     "painting", 1808 },
   { "Dejeuner sur l'Herbe",      "Eduard Manet",
     "painting", 1863 },
   { "Mona Lisa",      "Leonardo da Vinci", "painting", 1503 },
   { "David",          "Michelangelo",      "statue",   1501 },
   { "The Night Watch","Rembrandt",         "painting", 1642 },
   { "Guernica",       "Pablo Picasso",     "painting", 1937 },
   { "Ulysses",        "James Joyce",       "manuscript",  1922 },
   { "The Egyptian",   "Mika Waltari",      "manuscript",  1946 },
   { "For Whom the Bell Tolls",   "Ernest Hemingway",
     "manuscript", 1941 }
} ;



bool user_confirms( char  text_to_confirm[] )
{
   //  This function returns true if user types in 'Y' or 'y'.

   int  user_gave_positive_answer  =  false ;

   char  user_response[]  =   "?????" ;

   while ( user_response[ 0 ]  !=  'Y'  &&
           user_response[ 0 ]  !=  'y'  &&
           user_response[ 0 ]  !=  'N'  &&
           user_response[ 0 ]  !=  'n'  )
   {
      cout  <<  text_to_confirm ;
      cin.getline( user_response, sizeof( user_response ) ) ;

      if ( user_response[ 0 ]  ==  'Y'  ||
           user_response[ 0 ]  ==  'y'  )
      {
         user_gave_positive_answer  =  true ;
      }
   }

   return  user_gave_positive_answer ;
}


bool
search_collection_item( char              item_name_to_search[],

                        int&              index_of_found_item,
                        Collection_item&  found_collection_item )
{
   //  This function returns true if the item was found.

   int  item_has_been_found  =  false ;
   int  table_index          =  0 ;

   while ( item_has_been_found  ==  false  &&
           table_index  <  number_of_items_in_collection )
   { 
      if ( strstr( collection_table[ table_index ].item_name,
                   item_name_to_search ) )
      {
         item_has_been_found    =  true  ;
         found_collection_item  =  collection_table[ table_index ] ;
         index_of_found_item    =  table_index ;
      }
      else
      {
         table_index  ++  ;
      }
   }

   return  item_has_been_found  ;
}

 
void
print_data_of_one_collection_item( Collection_item&
                                   given_collection_item )
{
   cout <<  "\n  "  <<  setiosflags( ios::left )
        <<  setw( 30 )
        <<  given_collection_item.item_name 
        <<  setw( 20 )
        <<  given_collection_item.item_maker
        <<  setw( 15 )
        <<  given_collection_item.item_type
        <<  setw( 10 )
        <<  given_collection_item.year_of_making ;
}

void
print_collection_table( Collection_item  given_collection_table[],
                        int              number_of_items_to_print )
{
   int  table_index  =  0 ;

   while ( table_index  <  number_of_items_to_print )
   {
      print_data_of_one_collection_item( 
                       given_collection_table[ table_index ] ) ;
      table_index  ++  ;
   }
}

void  write_new_collection_item_to_table(
                      Collection_item   new_collection_item )
{
   if ( number_of_items_in_collection  >=
                                 COLLECTION_TABLE_SIZE )
   {
      cout << "\n Collection table is full!!!! \n" ;
   }
   else if ( strlen( new_collection_item.item_name )  ==  0 )
   {
      cout << "\n Invalid collection item data!!!! \n" ;
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
   Collection_item  new_collection_item ;
   char             year_of_making_as_string[ 10 ] ;

   cout << "\n Give new collection item name: " ;
   cin.getline( new_collection_item.item_name,
                ITEM_NAME_SIZE ) ;

   cout << " Give the artist name: " ;
   cin.getline( new_collection_item.item_maker,
                HUMAN_NAME_SIZE ) ;

   cout << " Give collection item type: " ;
   cin.getline( new_collection_item.item_type,
                ITEM_TYPE_SIZE ) ;

   cout << " Give the year of making: " ;
   cin.getline( year_of_making_as_string,
                sizeof( year_of_making_as_string ) ) ;
   new_collection_item.year_of_making  =
                atoi( year_of_making_as_string ) ;

   cout << " Writing new collection item data to table ... " ;
   write_new_collection_item_to_table( new_collection_item ) ;
} 


void  remove_collection_item() 
{
   char  item_name_from_user[ ITEM_NAME_SIZE ] ;
   int   index_of_item_to_remove ;
   Collection_item   item_to_remove ;

   cout << "\n Give the name of the item to remove: " ;
   cin.getline( item_name_from_user,
                sizeof( item_name_from_user ) ) ;

   if ( search_collection_item( item_name_from_user,

                                index_of_item_to_remove,
                                item_to_remove ) )
   {
      cout << "\n This collection item was found: " ;
      print_data_of_one_collection_item( item_to_remove ) ;

      if ( user_confirms( "\n Remove this item ( Y/N )?" ) )
      {
         //  Item will be removed by moving later items one
         //  position upwards in the table.

         int  table_index  =  index_of_item_to_remove  ;

         while ( table_index  <
                    ( number_of_items_in_collection - 1 ) )
         {
            collection_table[ table_index ]  =
                        collection_table[ table_index + 1 ] ;
            table_index  ++  ;
         }

         number_of_items_in_collection  --  ;
      }
      else
      {
         cout << "\n No items were removed. " ;
      }
   }
   else
   {
      cout << "\n The item being searced was not found!!!!" ;
   }
}


void  print_data_of_collection_items() 
{
   char  user_selection[]  =  "???????" ;
   char  item_type_from_user[ ITEM_TYPE_SIZE ] ;
   char  item_maker_from_user[ HUMAN_NAME_SIZE ] ;
   int   table_index  =  0 ;
   int   printing_table_index  =  0 ;

   Collection_item
        collection_table_for_printing[ COLLECTION_TABLE_SIZE ] ;

   cout <<  "\n Type in a letter according to menu: \n"
        <<  "\n    a    Print all collection items. "
        <<  "\n    t    Print certain types of items. "
        <<  "\n    n    Print items accoding to maker's name."
        <<  "\n\n    " ;

   cin.getline( user_selection, sizeof( user_selection ) ) ;

   if ( user_selection[ 0 ]  ==  'a' )
   {
      print_collection_table( collection_table,
                              number_of_items_in_collection ) ;
   }
   else if ( user_selection[ 0 ]  ==  't' )
   {
      cout <<  "\n Give the type of the items to be printed: " ;
      cin.getline( item_type_from_user,
                   sizeof( item_type_from_user ) ) ;

      while ( table_index  <  number_of_items_in_collection )
      {
         if ( strstr( collection_table[ table_index ].item_type,
                      item_type_from_user ) )
         {
            collection_table_for_printing[ printing_table_index ]
                =  collection_table[ table_index ] ;
            printing_table_index  ++  ;
         }

         table_index  ++  ;
      }

      print_collection_table( collection_table_for_printing,
                              printing_table_index ) ;
   }
   else if ( user_selection[ 0 ]  ==  'n' )
   {
      cout <<  "\n Give the name of the maker of the item: " ;
      cin.getline( item_maker_from_user,
                   sizeof( item_maker_from_user ) ) ;

      while ( table_index  <  number_of_items_in_collection )
      {
         if ( strstr( collection_table[ table_index ].item_maker,
                      item_maker_from_user ) )
         {
            collection_table_for_printing[ printing_table_index ]
                =  collection_table[ table_index ] ;
            printing_table_index  ++  ;
         }

         table_index  ++  ;
      }

      print_collection_table( collection_table_for_printing,
                              printing_table_index ) ;
   }
}


void  initialize_table_with_test_data() 
{
   number_of_items_in_collection  =
              sizeof( collection_table_for_testing ) /
              sizeof( Collection_item ) ;

   int table_index  =  0  ;

   while ( table_index  <  number_of_items_in_collection )
   {
      collection_table[ table_index ]  =
             collection_table_for_testing[ table_index ] ;
      table_index  ++  ;
   }
}


void  load_collection_data_from_file() 
{
   FILE   *collection_file_pointer ;

   collection_file_pointer  =
                   fopen( "collection_items.data", "rb" ) ;

   if  ( collection_file_pointer  ==  0  )
   {
      cout << "\n\n Error in opening file collection_items.data. "
           << "\n Collection table is not loaded.  \n\n" ;
   }
   else
   {
      number_of_items_in_collection  =

         fread( collection_table,
                sizeof( Collection_item ),
                COLLECTION_TABLE_SIZE,
                collection_file_pointer ) ;

      fclose( collection_file_pointer ) ;
      cout << "\n Collection table has been loaded.  \n\n" ;
   }
}


void  store_collection_data_to_file()
{
   FILE   *collection_file_pointer ;

   collection_file_pointer  =
                   fopen(  "collection_items.data", "wb" ) ;

   if ( collection_file_pointer ==  0  )
   {
      cout << "\n\n Error in opening file collection_items.data. "
           << "\n Collection table is not stored.  \n\n"  ;
   }
   else
   {
      fwrite( collection_table,
              sizeof( Collection_item ),
              number_of_items_in_collection,
              collection_file_pointer ) ;

      fclose( collection_file_pointer ) ;
      cout << "\n Collection table has been stored.  \n\n" ;
   }
}


int main()
{
   char  user_selection[]  =  "???????" ;

   cout << "\n\n This program is a system to help a collector"
        << "\n to maintain information about his or her"
        << "\n valuable collection items.\n" ;

   while  (  user_selection[ 0 ]  !=  'q' )
   {
      cout

       << "\n\n There are currently "
       << number_of_items_in_collection
       << " items in the collection. "
       << "\n Choose what to do by typing in a letter "
       << "\n according to the following menu: \n"

       << "\n    a   Add new collection item. "
       << "\n    r   Remove a collection item. "
       << "\n    p   Print data of collection items. "
       << "\n    i   Initialize table with test data. "
       << "\n    l   Load collection data from file. "
       << "\n    s   Store collection data to file. "
       << "\n    q   Quit the system.\n\n    " ;

      cin.getline( user_selection, sizeof( user_selection ) ) ;

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
      else if ( user_selection[ 0 ]  ==  'i' )
      {
         initialize_table_with_test_data() ;
      }
      else if ( user_selection[ 0 ]  ==  'l' )
      {
         load_collection_data_from_file() ;
      }
      else if ( user_selection[ 0 ]  ==  's' )
      {
         store_collection_data_to_file() ;
      }
   } /* endwhile */
}




