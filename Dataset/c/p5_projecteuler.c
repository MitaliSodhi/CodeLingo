#include <stdio.h>

// Project Euler: Problem 5
// =========================
// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

unsigned long gcd(unsigned long n, unsigned long m);
unsigned long lcm(unsigned long n, unsigned long m);

int main(void) {
  
  unsigned long ans = 1;
  unsigned short int i = 1, MAX = 20;

  // Compute LCM(1,...,20)
  for(i = 1; i <= MAX; i++) {
    ans = lcm(ans, i);
  }
  
  printf("%i", ans);

  return 0;
}

/*
  Algorithm based on 
  http://en.wikipedia.org/wiki/Greatest_common_divisor
  */
unsigned long gcd(unsigned long n, unsigned long m)
{
  int t;    

  while(m!=0) {
    t= m;
    m = n%m; 
    n= t;
  }

  return n;
}

/*
  Algorithm based on
  http://en.wikipedia.org/wiki/Least_common_multiple
  */
unsigned long lcm(unsigned long n, unsigned long m) {
  return ((unsigned long long)n*m/gcd(n,m));
}