use strict;

#
# This script takes a file name, opens the file, and prints the
# contents.
#
if($#ARGV != 0) {
    print STDERR "You must specify exactly one argument.\n";
    exit 4;
}

# Open the file.
open(INFILE, $ARGV[0]) or die "Cannot open $ARGV[0]: $!.\n";

while(my $l = <INFILE>) {
    print $l;
}

close INFILE;
