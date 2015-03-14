
//  animals.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <string.h>

class  Animal
{
protected:
   char  species_name[ 40 ] ;
   char  stomach_contents[ 80 ] ;

public:
   Animal( char     given_species_name[] ) ;
   Animal( Animal&  another_animal ) ;

   void feed( char  food_for_this_animal[] ) ;
   void make_speak() ;
} ;

Animal::Animal( char  given_species_name[] )
{
   strcpy( species_name, given_species_name ) ;
   strcpy( stomach_contents, "" ) ;
}

Animal::Animal( Animal&  another_animal )
{
   strcpy( species_name, another_animal.species_name ) ;
   strcpy( stomach_contents, another_animal.stomach_contents ) ;
}

void Animal::feed( char  food_for_this_animal[] )
{
   strcat( stomach_contents, food_for_this_animal ) ;
   strcat( stomach_contents, ", " ) ;
}

void Animal::make_speak()
{
   cout << "\n Hello, I am a " << species_name     << "."
        << "\n I have eaten: " << stomach_contents << "\n" ;
}

int main()
{
   Animal  cat_object( "cat" ) ;
   Animal  dog_object( "vegetarian dog" ) ;

   cat_object.feed( "fish" ) ;
   cat_object.feed( "chicken" ) ;

   dog_object.feed( "salad" ) ;
   dog_object.feed( "potatoes" ) ;

   Animal  another_cat( cat_object ) ;

   another_cat.feed( "milk" ) ;

   cat_object.make_speak() ;
   dog_object.make_speak() ;
   another_cat.make_speak() ;
}


