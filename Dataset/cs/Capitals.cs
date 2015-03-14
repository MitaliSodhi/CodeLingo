
//  Capitals.cs (c) 2003 Kari Laitinen

//  www.naturalprogramming.com

//  30.11.2002  File created.
//  27.06.2004  Last modification.

using  System ;

class Capitals
{
   static void Main()
   {
      string  countries_and_capitals  =

        "Finland Helsinki   Usa Washington   Denmark Copenhagen "
      + "Afghanistan Kabul  Russia Moscow    England London "
      + "Italy Rome         France Paris     Spain Madrid "
      + "Portugal Lisbon    Chile Santiago   Japan Tokyo "
      + "Sweden Stockholm   Norway Oslo      Pakistan Islamabad "
      + "Iceland Reykjavik  Hungary Budapest Holland Amsterdam "
      + "Belgium Brussels   Austria Vienna   Israel Jerusalem "  ; 

      Console.Write( "\n This program may know the capital of a country."
                   + "\n Type in the name of some country: " ) ;

      string  country_name  =  Console.ReadLine().ToLower() ;

      country_name  =  country_name[ 0 ].ToString().ToUpper()
                       +  country_name.Substring( 1 ) ;

      int index_of_country_name  =  countries_and_capitals.
                                            IndexOf( country_name ) ;

      if ( index_of_country_name  !=  -1 )
      {
         // The country name was found in countries_and_capitals

         string  text_after_country_name  =  countries_and_capitals.
             Substring( index_of_country_name + country_name.Length ) ;

         // A space at the end of the string ensures that also
         // the last country-capital pair in the string works.

         text_after_country_name  =  text_after_country_name.Trim() + " " ;

         string  capital_name  =  text_after_country_name.Substring(
                               0, text_after_country_name.IndexOf( " " ) ) ;

         Console.Write( "\n The capital of " + country_name
                      + " is " + capital_name  + ".\n" ) ;
      }
   }
}



