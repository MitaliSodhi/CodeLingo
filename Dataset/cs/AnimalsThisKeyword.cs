
//  AnimalsThisKeyword.cs  (c) 2003 Kari Laitinen

//  This program is Animals.cs enhanced with a
//  new feed() method that allows an Animal object
//  to eat another Animal object.

//  The this keyword is demonstrated in the new feed()
//  method.

using System ;

class  Animal
{
   string  species_name ;
   string  stomach_contents ;

   public Animal( string  given_species_name ) 
   {
      species_name      =  given_species_name ;
      stomach_contents  =  "" ;
   }

   public Animal( Animal  another_animal )
   {
      species_name      =  another_animal.species_name ;
      stomach_contents  =  another_animal.stomach_contents ;
   }

   public void feed( string  food_for_this_animal )
   {
      stomach_contents  =  
          stomach_contents  +  food_for_this_animal  +  ", "  ;
   }

   public void feed( Animal  another_animal )
   {
      if ( this  ==  another_animal )
      {
         Console.Write( "\n I cannot eat "  +  another_animal.species_name
                     +  "\n An animal cannot eat itself. \n" ) ;
      }
      else
      {
         stomach_contents  =  
             stomach_contents  +  another_animal.species_name  +  ", "  ;
      }
   }

   public void make_speak()
   {
      Console.Write( "\n Hello, I am a " + species_name     + "."
                   + "\n I have eaten: " + stomach_contents + "\n" ) ;
   }
}

class  AnimalTest
{
   static void Main()
   {
      Animal  cat_object  =  new Animal( "cat" ) ;
      Animal  dog_object  =  new Animal( "vegetarian dog" ) ;

      cat_object.feed( "fish" ) ;
      cat_object.feed( "chicken" ) ;

      dog_object.feed( "salad" ) ;
      dog_object.feed( "potatoes" ) ;

      Animal  another_cat  =  new Animal( cat_object ) ;

      another_cat.feed( "milk" ) ;

      cat_object.make_speak() ;
      dog_object.make_speak() ;
      another_cat.make_speak() ;

      Animal  animal_eater  =  new Animal( "animal eater" ) ;

      animal_eater.feed( cat_object ) ;
      animal_eater.feed( dog_object ) ;
      animal_eater.feed( animal_eater ) ;
      animal_eater.make_speak() ;
   }
}




