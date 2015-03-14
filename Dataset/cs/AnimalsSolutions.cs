
//  AnimalsSolutions.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-06  File created.
//  2004-11-06  Last modification.

//  Solutions to exercises 10-3 ... 10-6

using System ;

class  Animal
{
   string  species_name ;
   string  animal_name ;  //  Added in exercise 10-3.
   string  stomach_contents ;

   public Animal()  //  default constructor, solution to 10-5
   {
      species_name      =  "default animal" ;
      animal_name       =  "no name" ;
      stomach_contents  =  "" ; 
   }

   public Animal( string  given_species_name,
                  string  given_animal_name )  // Exercise 10-3
   {
      species_name      =  given_species_name ;
      animal_name       =  given_animal_name ;
      stomach_contents  =  "" ; 
   }

   public Animal( Animal  another_animal )
   {
      species_name      =  another_animal.species_name ;
      animal_name       =  another_animal.animal_name ;
      stomach_contents  =  another_animal.stomach_contents ;
   }

   public void feed( string  food_for_this_animal )
   {
      stomach_contents  =  
          stomach_contents  +  food_for_this_animal  +  ", "  ;
   }

   public void make_stomach_empty()  // solution to 10-6
   {
      stomach_contents  =  "" ;
   }

   public void make_speak()
   {
      Console.Write( "\n Hello, I am a " + species_name  
                   + " named "  +  animal_name  +  "."  ) ; // Exercise 10-3.

      //  The following if construct is a solution to Exercise 10-4.

      if ( stomach_contents.Length  ==  0 )
      {
         Console.Write( "\n My stomach is empty. \n" ) ;
      }
      else
      {
         Console.Write( "\n I have eaten: " + stomach_contents + "\n" ) ;
      }
   }
}

class  AnimalsSolutionsTest
{
   static void Main()
   {
      //  Because the constructor has been modified in Exercise 10-3,
      //  two parameters are supplied when Animal objects are created.

      Animal  cat_object  =  new Animal( "cat", "Ludwig" ) ;
      Animal  dog_object  =  new Animal( "vegetarian dog", "Bertha" ) ;

      cat_object.make_speak() ; // Testing the solution to 10-4.

      cat_object.feed( "fish" ) ;
      cat_object.feed( "chicken" ) ;

      dog_object.feed( "salad" ) ;
      dog_object.feed( "potatoes" ) ;

      Animal  another_cat  =  new Animal( cat_object ) ;

      another_cat.feed( "milk" ) ;

      cat_object.make_speak() ;
      dog_object.make_speak() ;
      another_cat.make_speak() ;

      //  The following two lines test the solutions to 10-5.
      Animal strange_animal  =  new Animal() ;
      strange_animal.make_speak() ;

      //  The following two lines test the solution to 10-6.
      cat_object.make_stomach_empty() ;
      cat_object.make_speak() ;
   }
}




