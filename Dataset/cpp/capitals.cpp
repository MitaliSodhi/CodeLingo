
//  capitals.cpp (c) 1999-2002 Kari Laitinen

#include  <iostream.h>
#include  <string>

#include  <sstream>

int main()
{
   stringstream  countries_and_capitals ;

   countries_and_capitals  << 

   "Finland Helsinki   USA Washington   Denmark Copenhagen "
   "Afghanistan Kabul  Russia Moscow    England London "
   "Italy Rome         France Paris     Spain Madrid "
   "Portugal Lisbon    Chile Santiago   Japan Tokyo "
   "Sweden Stockholm   Norway Oslo      Pakistan Islamabad "
   "Iceland Reykjavik  Hungary Budapest Holland Amsterdam "
   "Belgium Brussels   Austria Vienna   Israel Jerusalem "  ; 

   cout << "\n This program may know the capital of a country."
           "\n Type in a country name: " ;

   string  country_name ;

   getline( cin, country_name ) ;

   string  name_from_list ;

   while ( countries_and_capitals  >>  name_from_list )
   {
      if ( name_from_list  ==  country_name )
      {
         string  capital_name ;

         countries_and_capitals  >>  capital_name ;

         cout << "\n The capital of " << country_name
              << " is " << capital_name  << ".\n" ;
      }
   }
}



/*******************

   The following program can also find the capital of
   a country.

void  main()
{
   string  countries_and_capitals(

   "Finland Helsinki   USA Washington   Denmark Copenhagen "
   "Afghanistan Kabul  Russia Moscow    England London "
   "Italy Rome         France Paris     Spain Madrid "
   "Portugal Lisbon    Chile Santiago   Japan Tokyo "
   "Sweden Stockholm   Norway Oslo      Pakistan Islamabad "
   "Iceland Reykjavik  Hungary Budapest Holland Amsterdam "
   "Belgium Brussels   Austria Vienna   Israel Jerusalem " ) ; 

   cout << "\n\n This program may know the capital of a country."
             "\n Type in a country name: " ;

   string  country_name ;

   getline( cin, country_name ) ;

   int country_name_index  = 
                countries_and_capitals.find( country_name ) ;

   if ( country_name_index  !=  string::npos )
   {
      string  capital_name( countries_and_capitals,
                            country_name_index, 30  ) ;

      while ( capital_name[ 0 ]  !=  ' ' )
      {
         capital_name.erase( 0, 1 ) ;
      }

      while ( capital_name[ 0 ]  ==  ' ' )
      {
         capital_name.erase( 0, 1 ) ;
      }

      int  capital_name_length  =  0 ;

      while ( capital_name[ capital_name_length ]  !=  ' ' )
      {
         capital_name_length  ++  ;
      }

      capital_name.erase( capital_name_length, 30 ) ;

      cout << "\n The capital of " << country_name
           << " is " << capital_name  << ".\n" ;
   }
   else
   {
      cout << "\n Sorry, I do not know the capital of "
           << country_name << ".\n" ;
   }
}


***********************/


/*****************

  The following is another version of a program to find
  the capital of a country.


#include  <vector>

void  main()
{
   vector<string>  countries_and_capitals ;

   countries_and_capitals.push_back( "Finland        Helsinki" ) ;
   countries_and_capitals.push_back( "United States  Washington" ) ;
   countries_and_capitals.push_back( "Denmark        Copenhagen" ) ;
   countries_and_capitals.push_back( "Afghanistan    Kabul"  ) ;
   countries_and_capitals.push_back( "Russia         Moscow" ) ;
   countries_and_capitals.push_back( "England        London" ) ;
   countries_and_capitals.push_back( "Italy          Rome" ) ;

   cout << "\n\n This program may know a capital of a country."
             "\n Type in a country name: " ;

   string  country_name ;

   getline( cin, country_name ) ;

   bool  country_not_found  =  true ;

   vector<string>::iterator  country_and_capital  =  
                                     countries_and_capitals.begin() ;

   while ( country_not_found    ==  true  &&
           country_and_capital  !=  countries_and_capitals.end() )
   {
      if ( country_and_capital -> find( country_name ) != string::npos )
      {
         country_not_found  =  false ;

         string  capital_name( *country_and_capital ) ;

         capital_name.erase( 0, country_name.length() ) ;

         while ( capital_name[ 0 ]  ==  ' ' )
         {
            capital_name.erase( 0, 1 ) ;
         }

         cout << "\n The capital of " << country_name
              << " is " << capital_name  << ".\n" ;
      }
      else
      {
         country_and_capital  ++  ;
      }
   }
}

*************************/



