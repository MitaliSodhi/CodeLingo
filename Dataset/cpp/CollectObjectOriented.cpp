
//  CollectObjectOriented.cpp (c) 1998-2006 Kari Laitinen

//  http://www.naturalprogramming.com

//  2006-06-10  File created.
//  2006-06-11  Last modification.

//  This is an object-oriented version of program collect.cpp.
//  This is not presented in the C++ book. This version corresponds
//  to the programs Collect.java, Collect.cs and Collect.py that
//  are available at http://www.naturalprogramming.com

//  This program uses C-style strings. A standard string object
//  is used only in the function that overloads operator << for
//  CollectionItem objects.

//  I'll rewrite this program so that it uses string objects
//  if somebody asks me to do so.

#include  <iostream.h>
#include  <iomanip.h>
#include  <fstream.h>
#include  <string.h>
#include  <stdlib.h>
#include  <sstream>    // Class stringstream
#include  <string>     // Class string

#define   COLLECTION_TABLE_SIZE         100
#define   ITEM_NAME_SIZE                 80
#define   HUMAN_NAME_SIZE                30
#define   ITEM_TYPE_SIZE                 20

class  CollectionItem
{
protected:
   char  item_name[ ITEM_NAME_SIZE ] ;
   char  item_maker[ HUMAN_NAME_SIZE ] ;
   char  item_type[ ITEM_TYPE_SIZE ] ;
   int   year_of_making ;

public:
   CollectionItem()  {}
   CollectionItem( char given_item_name[],
                   char given_item_maker[],
                   char given_item_type[],
                   int  given_year_of_making ) ;
   CollectionItem( ifstream& file_containing_collection_data ) ;

   char* get_item_name()  { return item_name ; }
   char* get_item_maker() { return item_maker ; }
   char* get_item_type()  { return item_type ; }
   int   get_year_of_making() { return year_of_making ; }

   bool is_equal_to( CollectionItem another_collection_item ) ;
   void store_to_file( ofstream&  binary_file ) ;
   friend ostream& operator<<( ostream&        output_stream,
                                CollectionItem&  collection_item_to_output ) ;
} ;


CollectionItem::CollectionItem( char given_item_name[],
                                char given_item_maker[],
                                char given_item_type[],
                                int  given_year_of_making )
{
   strcpy( item_name,  given_item_name ) ;
   strcpy( item_maker, given_item_maker ) ;
   strcpy( item_type,  given_item_type ) ;
   year_of_making  =  given_year_of_making ;
}

CollectionItem::CollectionItem( ifstream& file_containing_collection_data )
{
   //  This constructor is neither used nor tested.

   file_containing_collection_data.read( (char*) this,
                                          sizeof( CollectionItem ) ) ;
}

bool CollectionItem::is_equal_to( CollectionItem another_collection_item )
{
   return ( strcmp( item_name, another_collection_item.item_name ) ==  0 &&
            strcmp( item_maker, another_collection_item.item_maker ) == 0 &&
            strcmp( item_type, another_collection_item.item_type  ) == 0  &&
            year_of_making  ==  another_collection_item.year_of_making ) ;
}


void CollectionItem::store_to_file( ofstream&  binary_file )
{
   //  This member function is not used and it has not been tested.

   binary_file.write( (char*) this,
                      sizeof( CollectionItem ) ) ;
}

ostream&  operator<<( ostream&         output_stream,
                       CollectionItem&  collection_item_to_output )
{
   //  We output the text temporarily to a stringstream so that we
   //  do not disturb the used stream with the manipulator 'left'

   stringstream  text_as_stream ;

   text_as_stream <<  "  "  <<  left 
                  <<  setw( 30 )  <<  collection_item_to_output.item_name 
                  <<  setw( 20 )  <<  collection_item_to_output.item_maker
                  <<  setw( 15 )  <<  collection_item_to_output.item_type
                  <<  setw( 10 )  <<  collection_item_to_output.year_of_making;

   string  string_to_return ;

   getline( text_as_stream, string_to_return ) ;

   output_stream << string_to_return.c_str() ;

   return  output_stream ;
}


class  Collection
{
protected:
   static const int  MAXIMUM_NUMBER_OF_ITEMS  =  100 ;

   CollectionItem items_in_this_collection[ MAXIMUM_NUMBER_OF_ITEMS ] ;

   int  number_of_items_in_collection ;

public:
   Collection()
   {
      number_of_items_in_collection  =  0 ;
   }

   int get_number_of_items()
   {
      return number_of_items_in_collection ;
   }

   bool search_collection_item( char              item_name_to_search[],
   
                                int&              index_of_found_item,
                                CollectionItem&   found_collection_item ) ;

   void print_all_items() ;
   void add_new_item( CollectionItem&  new_collection_item ) ;

   void remove_all_items()
   {
      number_of_items_in_collection  =  0 ;
   }

   void remove_one_item( CollectionItem  item_to_remove ) ;
   Collection get_items_of_maker( char given_item_maker[] ) ;
   Collection get_items_of_type( char given_item_type[] ) ;
   void store_to_file() ;
   void load_from_file() ;

} ;


bool
Collection::search_collection_item( char              item_name_to_search[],

                                    int&              index_of_found_item,
                                    CollectionItem&   found_collection_item )
{
   //  This function returns true if the item was found.

   bool item_has_been_found  =  false ;
   int  item_index          =  0 ;

   while ( item_has_been_found  ==  false  &&
           item_index  <  number_of_items_in_collection )
   { 
      if ( strstr( items_in_this_collection[ item_index ].get_item_name(),
                   item_name_to_search ) )
      {
         item_has_been_found    =  true  ;
         found_collection_item  =  items_in_this_collection[ item_index ] ;
         index_of_found_item    =  item_index ;
      }
      else
      {
         item_index  ++  ;
      }
   }

   return  item_has_been_found  ;
}

void Collection::print_all_items()
{
   int  item_index  =  0 ;

   while ( item_index  <  number_of_items_in_collection )
   {
      cout << "\n" << items_in_this_collection[ item_index ] ;

      item_index  ++  ;
   }
}

void  Collection::add_new_item( CollectionItem& new_collection_item )
{
   if ( number_of_items_in_collection  >=  COLLECTION_TABLE_SIZE )
   {
      cout << "\n Collection table is full!!!! \n" ;
   }
   else if ( strlen( new_collection_item.get_item_name() )  ==  0 )
   {
      cout << "\n Invalid collection item data!!!! \n" ;
   }
   else
   {
      items_in_this_collection[ number_of_items_in_collection ]
                                       =   new_collection_item ;
      number_of_items_in_collection  ++  ;
   }
}

void Collection::remove_one_item( CollectionItem  item_to_remove )
{
   bool item_has_been_found  =  false ;
   int  item_index           =  0 ;

   while ( item_has_been_found  ==  false  &&
           item_index  <  number_of_items_in_collection )
   { 
      if ( items_in_this_collection[ item_index ].
                           is_equal_to( item_to_remove )  )
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

Collection  Collection::get_items_of_maker( char given_item_maker[] )
{
   Collection  collection_to_return ;

   for ( int item_index  =  0 ;
             item_index  <  number_of_items_in_collection ;
             item_index  ++ )
   {
      if ( strstr( items_in_this_collection[ item_index ].get_item_maker(),
                   given_item_maker )  !=  0 )
      {
         collection_to_return.add_new_item(
                          items_in_this_collection[ item_index ] ) ;
      }
   }

   return  collection_to_return ;
}

Collection  Collection::get_items_of_type( char given_item_type[] )
{
   Collection  collection_to_return  ;

   for ( int item_index  =  0 ;
             item_index  <  number_of_items_in_collection ;
             item_index  ++ )
   {
      if ( strstr( items_in_this_collection[ item_index ].get_item_type(),
                   given_item_type )  !=  0 )
      {
         collection_to_return.add_new_item(
                             items_in_this_collection[ item_index ] ) ;
      }
   }

   return  collection_to_return ;
}

void  Collection::store_to_file()
{
   ofstream  collection_file ;

   collection_file.open( "collection_items.data", ios::binary ) ;

   if ( collection_file.fail() )
   {
      cout << "\n\n Error in opening file collection_items.data. "
           << "\n Collection items not stored.  \n\n"  ;
   }
   else
   {
      for ( int item_index  =  0 ;
                item_index  <  number_of_items_in_collection ;
                item_index  ++  )
      {
         collection_file.write(

                        (char*) &items_in_this_collection[ item_index ],
                                 sizeof( CollectionItem ) ) ;
      }

      cout << "\n Collection items have been stored.  \n\n" ;
   }
}


void  Collection::load_from_file() 
{
   ifstream  collection_file ;

   collection_file.open( "collection_items.data", ios::binary ) ;

   if  ( collection_file.fail() )
   {
      cout << "\n\n Error in opening file collection_items.data. "
           << "\n Collection items are not loaded.  \n\n" ;
   }
   else
   {
      int  item_index  =  0 ;

      CollectionItem   item_from_file  ;

      while ( ! collection_file.eof() )
      {
         collection_file.read( (char*) &item_from_file,
                                        sizeof( CollectionItem ) ) ;

         if ( collection_file.gcount() == sizeof( CollectionItem ))
         {
            items_in_this_collection[ item_index ]  =  item_from_file ;

            item_index  ++  ;
         }
      }

      number_of_items_in_collection  =  item_index  ;

      cout << "\n Collection items have been loaded.  \n\n" ;
   }
}


class  CollectionMaintainer
{
protected:
   Collection  this_collection  ;


public:
   bool user_confirms( char text_to_confirm[] ) ;
   void add_new_collection_item() ;
   void remove_collection_item() ;
   void print_data_of_collection_items() ;
   void initialize_collection_with_test_data() ;
   void run() ;
} ;


bool CollectionMaintainer::user_confirms( char  text_to_confirm[] )
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

void  CollectionMaintainer::add_new_collection_item() 
{
   char  new_item_name[ ITEM_NAME_SIZE ] ;
   char  new_item_maker[ HUMAN_NAME_SIZE ] ;
   char  new_item_type[ ITEM_TYPE_SIZE ] ;
   char  year_of_making_as_string[ 10 ] ;

   cout << "\n Give new collection item name: " ;
   cin.getline( new_item_name, sizeof( new_item_name ) ) ;

   cout << " Give the artist name: " ;
   cin.getline( new_item_maker, sizeof( new_item_maker ) ) ;

   cout << " Give collection item type: " ;
   cin.getline( new_item_type, sizeof( new_item_type ) ) ;

   cout << " Give the year of making: " ;
   cin.getline( year_of_making_as_string,
                sizeof( year_of_making_as_string ) ) ;
   int new_year_of_making  = atoi( year_of_making_as_string ) ;

   CollectionItem  new_collection_item( new_item_name,
                                        new_item_maker,
                                        new_item_type,
                                        new_year_of_making ) ;

   this_collection.add_new_item( new_collection_item ) ;
   cout << "\n New item has been added to collection. "  ;
} 

void  CollectionMaintainer::remove_collection_item() 
{
   char  item_name_from_user[ ITEM_NAME_SIZE ] ;
   int   index_of_item_to_remove ;
   CollectionItem   item_to_remove ;

   cout << "\n Give the name of the item to remove: " ;
   cin.getline( item_name_from_user,
                sizeof( item_name_from_user ) ) ;

   if ( this_collection.search_collection_item( item_name_from_user,

                                                index_of_item_to_remove,
                                                item_to_remove ) )
   {
      cout << "\n This collection item was found: \n"  << item_to_remove ;

      if ( user_confirms( "\n Remove this item ( Y/N )?" ) )
      {
         this_collection.remove_one_item( item_to_remove ) ;
      }
      else
      {
         cout << "\n No items were removed. " ;
      }
   }
   else
   {
      cout << "\n The item being searched was not found!!!!" ;
   }
}

void  CollectionMaintainer::print_data_of_collection_items() 
{
   Collection items_to_print ;

   char  user_selection[]   =  "??????" ;

   cout <<  "\n Type in a letter according to menu: \n"
        <<  "\n    a    Print all collection items. "
        <<  "\n    t    Print certain types of items. "
        <<  "\n    m    Print items according to maker's name."
        <<  "\n\n    " ;

   cin.getline( user_selection, sizeof( user_selection ) ) ;

   if ( user_selection[ 0 ]  ==  'a' )
   {
      items_to_print  =  this_collection ;
   }
   else if ( user_selection[ 0 ]  ==  't' )
   {
      char  item_type_from_user[ ITEM_TYPE_SIZE ] ;

      cout <<  "\n Give the type of the items to be printed: " ;
      cin.getline( item_type_from_user,
                   sizeof( item_type_from_user ) ) ;

      items_to_print  =  this_collection.get_items_of_type( 
                                                item_type_from_user ) ;

   }
   else if ( user_selection[ 0 ]  ==  'm' )
   {
      char  item_maker_from_user[ HUMAN_NAME_SIZE ] ;

      cout <<  "\n Give the name of the maker of the item: " ;
      cin.getline( item_maker_from_user,
                   sizeof( item_maker_from_user ) ) ;

      items_to_print  =  this_collection.get_items_of_maker(
                                                item_maker_from_user ) ;
   }

   items_to_print.print_all_items() ;
}

void  CollectionMaintainer::initialize_collection_with_test_data() 
{
   this_collection.remove_all_items() ;

   this_collection.add_new_item(  CollectionItem(
        "Les Demoiselles d'Avignon","Pablo Picasso",  "painting", 1907 ) );
   this_collection.add_new_item(  CollectionItem(
        "The Third of May 1808", "Francisco de Goya", "painting", 1808 ) );
   this_collection.add_new_item(  CollectionItem(
        "Dejeuner sur l'Herbe",  "Eduard Manet",      "painting", 1863 ) );
   this_collection.add_new_item(  CollectionItem(
        "Mona Lisa",             "Leonardo da Vinci", "painting", 1503 ) );
   this_collection.add_new_item(  CollectionItem(
        "David",                 "Michelangelo",      "statue",   1501 ) );
   this_collection.add_new_item(  CollectionItem(
        "The Night Watch",       "Rembrandt",         "painting", 1642 ) );
   this_collection.add_new_item(  CollectionItem(
        "Guernica",              "Pablo Picasso",     "painting", 1937 ) );
   this_collection.add_new_item(  CollectionItem(
        "Ulysses",               "James Joyce",       "manuscript", 1922 ));
   this_collection.add_new_item(  CollectionItem(
        "The Egyptian",          "Mika Waltari",      "manuscript", 1946 ));
   this_collection.add_new_item(  CollectionItem(
        "For Whom the Bell Tolls", "Ernest Hemingway","manuscript", 1941 ));
}


void CollectionMaintainer::run()
{
   char  user_selection[]  =  "???????" ;

   cout << "\n This program is a system to help a collector"
        << "\n to maintain information about his or her"
        << "\n valuable collection items.\n" ;

   while  (  user_selection[ 0 ]  !=  'q' )
   {
      cout

      << "\n\n There are currently "
      << this_collection.get_number_of_items()  << " items in the collection. "
      << "\n Choose what to do by typing in a letter "
      << "\n according to the following menu: \n"

      << "\n    a   Add a new collection item. "
      << "\n    r   Remove a collection item. "
      << "\n    p   Print data of collection items. "
      << "\n    s   Store collection data to file. "
      << "\n    l   Load collection data from file. "
      << "\n    i   Initialize table with test data. "
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
   } /* endwhile */
}

int main()
{
   CollectionMaintainer  this_collection_maintainer ;
   this_collection_maintainer.run() ;
}




