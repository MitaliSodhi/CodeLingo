use v6;

# idea: the last 9 digits can be permuted in 9! = 362880 ways.
# so there are 9! numbers that start with a 0, 9! numbers that start with a 
# 1 etc. 
# So to get the first digit, divide our target by 9!, and the rounded
# result is the first digit.
#
# then we remove the first digit from the pool of available digits, 
# divide the rest by 8!, round, store result in $n. Then the $n'th
# lowest available digit is the second digit that we search.

my $target = 1e6;
my $t = $target;

sub f(Int $x){
    [*] 1..$x;
}

my @f = map &f, 0..9;
my @available = 0 .. 9;

say gather {
    for reverse(0..9) -> $marker {
        my $n = ceiling($t / @f[$marker])- 1;
        $t -= $n * @f[$marker];
        take @available[$n];
        @available.splice($n, 1);
    }
}

# vim: ft=perl6
