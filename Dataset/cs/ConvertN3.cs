
//  ConvertN3.cs (c) 2003 Kari Laitinen

//  In this version the format specifier "N3" is used
//  to reduce digits after the decimal point in the output.

using System ;

class  Conversion
{
   string  first_unit ;
   string  second_unit ;
   double  conversion_constant ;

   public Conversion( string  given_first_unit,
                      string  given_second_unit,
                      double  given_conversion_constant )
   {
      first_unit   =  given_first_unit ;
      second_unit  =  given_second_unit ;
      conversion_constant  =  given_conversion_constant ;
   }

   public void convert( string  given_unit,
                        double  amount_to_convert )
   {
      if ( first_unit.IndexOf( given_unit )  !=  -1 )
      {
         double  conversion_result  =  amount_to_convert  *
                                       conversion_constant ;

         Console.Write(  "\n  "  +  amount_to_convert  +  " "
                      +  first_unit  + " is "
                      +  conversion_result.ToString( "N3" )
                      +  " "  +  second_unit ) ;
      }

      if ( second_unit.IndexOf( given_unit )  !=  -1 )
      {
         double  conversion_result  =  amount_to_convert /
                                       conversion_constant ;

         Console.Write( "\n  "  +  amount_to_convert  +  " "
                      +  second_unit  + " is "
                      +  conversion_result.ToString( "N3" )
                      +  " "  +  first_unit ) ;
      }
   }
}

class  ConversionApplication
{
   static void Main( string[]  command_line_parameters )
   {
      Conversion[]  conversion_table  =  new  Conversion[ 13 ] ;

      conversion_table[ 0 ] = new Conversion("meters", "yards", 1.093613 );
      conversion_table[ 1 ] = new Conversion("meters", "feet",  3.280840 );
      conversion_table[ 2 ] = new Conversion("miles",  "kilometers",1.609344);
      conversion_table[ 3 ] = new Conversion("inches", "centimeters", 2.54 );
      conversion_table[ 4 ] = new Conversion("acres",  "hectares", 0.4046873);
      conversion_table[ 5 ] = new Conversion("pounds", "kilograms",0.4535924);
      conversion_table[ 6 ] = new Conversion("ounces", "grams",    28.35 );
      conversion_table[ 7 ] = new Conversion("gallons (U.S.)","liters", 3.785);
      conversion_table[ 8 ] = new Conversion("gallons (Br.)", "liters", 4.546);
      conversion_table[ 9 ] = new Conversion("pints (U.S.)",  "liters", 0.473);
      conversion_table[ 10 ]= new Conversion("pints (Br.)",   "liters", 0.568);
      conversion_table[ 11 ]= new Conversion("joules",       "calories",4.187);
      conversion_table[ 12 ]= new Conversion("lightyears",   "kilometers",
                                                              9.461e12 ) ;
      string  unit_from_user ;
      int     amount_to_convert ;

      if ( command_line_parameters.Length  ==  2 )
      {
         unit_from_user     =  command_line_parameters[ 0 ]  ;
         amount_to_convert  =  Convert.ToInt32(
                                   command_line_parameters[ 1 ] ) ;
      }
      else
      {
         Console.Write( "\n Give the unit to convert from: " ) ;
         unit_from_user  =  Console.ReadLine() ;
         Console.Write( " Give the amount to convert:   " ) ;
         amount_to_convert  =  Convert.ToInt32( Console.ReadLine() ) ;
      }

      //  Here line_index refers to a line in the conversion_table.

      for ( int line_index  =  0 ;
                line_index  <  conversion_table.Length ;
                line_index  ++ )
      {
         conversion_table[ line_index ].convert( unit_from_user,
                                                 amount_to_convert ) ;
      }
   }
}




