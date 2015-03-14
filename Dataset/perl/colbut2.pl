#
# Uses the canned pop-up dialog windows.

use Tk;
use Tk::Dialog;
use strict;

my $main = new MainWindow;

# See if button was pressed
my $waspressed = 0;

# The action for the exit button.
sub exit_action {
    # See if we have managed to change the color.
    if ($waspressed) { 
	# Yes.  Confirm exit.  Display dialog box and capture the response.
	my $conf = $main->Dialog
	    (-title => "Confirm",
	     -bitmap => 'question', 
	     -text => "Do you really want to quit?",
	     -buttons => [ "Yes", "No" ] );
	my $response = $conf->Show;
	if($response eq "Yes") { exit 0; }
    } else {
	# No.  Whine.  Display dialog box and discard the response.
	$main->Dialog
	    (-title => "Error",
	     -bitmap => 'error', 
	     -text => "Fool!  You must change the exit " .
	     "button color before you may exit!",
	     -buttons => [ "OK" ] )->Show;
    }
}

# The all important exit button.
my $alldone = $main->Button
    (-text => "Exit", -background => "#888888",
     -command => \&exit_action);

# Three color bottons together.
my $buts = $main->Frame;
my $red = $buts->Button(-text => "Red", -background => "#ffaaaa",
		     -command => sub { 
			 $alldone->configure( -background => "Red");
			 $waspressed = 1; } );
my $green = $buts->Button(-text => "Green", -background => "#aaffaa",
		     -command => sub { 
			 $alldone->configure( -background => "Green");
			 $waspressed = 1; } );
my $blue = $buts->Button(-text => "Blue", -background => "#aaaaff",
		     -command => sub { 
			 $alldone->configure( -background => "Blue");
			 $waspressed = 1; } );

# Set top level window yellow.
$main->configure( -background => "Yellow");

# Instructions.
my $lab = $main->Label(-text => "Choose the color\nof the exit button",
		      -background => "Yellow");

# Pack it all together.  In Perl, you can only pack one at a time.
$red->pack(-side => "left");
$green->pack(-side => "left");
$blue->pack(-side => "left");
$lab->pack(-side => "top");
$buts->pack(-side => "top");
$alldone->pack(-side => "top");

MainLoop;
