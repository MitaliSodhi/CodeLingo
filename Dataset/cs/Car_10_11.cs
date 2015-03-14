
//  Car_10_11.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-06  File created.
//  2004-11-06  Last modification.

using System ;

class Car
{
   string  car_maker ;
   string  car_model ;

   int  current_speed ;

   bool  engine_is_on ;

   public Car( string  given_car_maker )
   {
      car_maker  =  given_car_maker ;
      car_model  =  "Basic model" ;
   }

   public Car( string  given_car_maker,
               string  given_car_model )
   {
      car_maker  =  given_car_maker ;
      car_model  =  given_car_model ;
   }

   public void  start_engine()
   {
      engine_is_on  =  true ;
      Console.Write( "\n Engine of "  +  car_maker  +  " "
                  +  car_model  +  " has been started." ) ;
   }

   public void  stop_engine()
   {
      engine_is_on   =  false ;
      current_speed  =  0 ;
      Console.Write( "\n Engine of "  +  car_maker  +  " "
                  +  car_model  +  " has been stopped." ) ;
   }

   public void  increase_speed()
   {
      Console.Write( "\n Increasing the speed of "
                  +  car_maker  +  " "  +  car_model  ) ;

      if ( engine_is_on  ==  true )
      {
         Console.Write( "\n     Old speed is " +  current_speed ) ;

         current_speed  =  current_speed  +  20 ;

         Console.Write( "\n     New speed is " +  current_speed ) ;
      }
      else
      {
         Console.Write(
            "\n   -- Cannot increase speed. Engine is stopped." ) ;
      }
   }

   public void  decrease_speed()
   {
      Console.Write( "\n Decreasing the speed of "
                  +  car_maker  +  " "  +  car_model  ) ;

      if ( current_speed  >  20 )
      {
         Console.Write( "\n     Old speed is " +  current_speed ) ;

         current_speed  =  current_speed  -  20 ;

         Console.Write( "\n     New speed is " +  current_speed ) ;
      }
      else
      {
         Console.Write( "\n     Old speed is " +  current_speed ) ;

         current_speed  =  0 ;

         Console.Write( "\n     New speed is " +  current_speed ) ;
      }
   }

   public void make_speak()
   {
      Console.Write( "\n\n Hello, I am a car made by "  +  car_maker
                  +  ". "  +  car_model  +  " is my model."
                  +  "\n Now I'm moving with speed "  +  current_speed
                  +  "\n It is "  +  engine_is_on 
                  +  " that my engine is on. \n" ) ;
   }
}

class Car_10_11
{
   static void Main()
   {
      Car  my_car  =  new  Car( "Honda", "Accord" ) ;
      my_car.make_speak() ;
      my_car.increase_speed() ;

      Car your_car  =  new  Car( "Cadillac" ) ;
      your_car.start_engine() ;
      your_car.increase_speed() ;
      your_car.make_speak() ;
      your_car.decrease_speed() ;
      your_car.decrease_speed() ;
      your_car.stop_engine() ;
   }
}



