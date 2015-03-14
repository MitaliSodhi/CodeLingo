
//  Unabbreviator.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;

class Abbreviation
{
   string this_abbreviation ;
   string meaning_of_this_abbreviation ;

   public Abbreviation( string given_abbreviation,
                        string given_meaning_of_abbreviation )
   {
      this_abbreviation  =  given_abbreviation ;
      meaning_of_this_abbreviation  =  given_meaning_of_abbreviation ;
   }

   public string get_abbreviation()
   {
      return  this_abbreviation ;
   }

   public string get_explanation_string()
   {
      return   "\""  +  this_abbreviation  +  "\" means \"" 
               +  meaning_of_this_abbreviation  +  "\"" ;
   }
}


class Unabbreviator
{
   Abbreviation[]  common_abbreviations  =  new  Abbreviation[ 50 ] ;

   public Unabbreviator()
   {
      common_abbreviations[ 0 ]  =  new  Abbreviation(
               "A.D.",  "anno Domini (in the year of the Lord)" ) ;
      common_abbreviations[ 1 ]  =  new  Abbreviation(
               "A.M.",  "ante meridiem (before noon)" ) ;
      common_abbreviations[ 2 ]  =  new  Abbreviation(
               "e.g.",  "exempli gratia (for example)" ) ;
      common_abbreviations[ 3 ]  =  new  Abbreviation(
               "H.R.H.", "His (Her) Royal Highness" ) ;
      common_abbreviations[ 4 ]  =  new  Abbreviation(
               "i.e.",  "id est (that is)" ) ;
      common_abbreviations[ 5 ]  =  new  Abbreviation(
               "I.Q.",  "Intelligence Quotient" ) ;
      common_abbreviations[ 6 ]  =  new  Abbreviation(
               "kg",    "kilogram" ) ;
      common_abbreviations[ 7 ]  =  new  Abbreviation(
               "P.M.",  "post meridiem (afternoon)" ) ;
      common_abbreviations[ 8 ]  =  new  Abbreviation(
               "POW",   "prisoner of war" ) ;
      common_abbreviations[ 9 ]  =  new  Abbreviation(
               "P.S.",  "post scriptum (postscript)" ) ;
      common_abbreviations[ 10 ]  =  new  Abbreviation(
               "R.S.V.P.", "Respondez, s'il vous plait (Please answer)") ;
   }

   public string this[ int given_abbreviation_index ]
   {
      get
      {
         return  common_abbreviations[ given_abbreviation_index ]
                                            .get_explanation_string() ;
      }
   }
            
   public string this[ string given_abbreviation ]
   {
      get
      {
         string  string_to_return  =  "" ;

         int abbreviation_index  =  0 ;

         bool  array_search_ready  =  false ;

         while ( array_search_ready  ==  false )
         {
            if ( common_abbreviations[ abbreviation_index ]
                     .get_abbreviation()  ==  given_abbreviation )
            {
               string_to_return  =
                     common_abbreviations[ abbreviation_index ]
                                         .get_explanation_string() ;

               array_search_ready  =  true ;
            }
            else
            {
               abbreviation_index  ++ ;

               if ( common_abbreviations[ abbreviation_index  ]  ==  null )
               {
                  string_to_return  =  "\""  +  given_abbreviation  +
                                       "\""  +  " cannot be explained. " ;

                  array_search_ready  =  true ;
               }
            }
         }

         return  string_to_return ;
      }
   }
}

class UnabbreviatorTester
{
   static void Main()
   {
      Unabbreviator  test_unabbreviator  =  new  Unabbreviator() ;

      Console.Write( "\n " + test_unabbreviator[ "A.M." ] ) ;
      Console.Write( "\n " + test_unabbreviator[ "R.S.V.P." ] ) ;
      Console.Write( "\n " + test_unabbreviator[ "ASAP" ] ) ;
      Console.Write( "\n " + test_unabbreviator[ 0 ] ) ;
   }
}



