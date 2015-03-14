#include <stdio.h>

// Project Euler: Problem 6
// =========================
// Find the difference between the sum of the squares of the first one hundred natural
// numbers and the square of the sum.

int main(void) {
  
  unsigned long sum_square = 0, square_sum = 0, ans;
  unsigned short int MAX = 100, i;
  
  for(i = 1; i <= MAX; i++) {
    sum_square += (i*i);
    square_sum += i;
  }
  
  square_sum *= square_sum;

  printf("Sum of squares ( <= 10): %i\n", sum_square);
  printf("Square of sums ( <= 10): %i\n", square_sum);

  ans = square_sum - sum_square;

  printf("\nThe difference bewteen the square of sums and sum of squares is: %i", ans);  

  return 0;
}