var temporal = require("temporal");
var five = require("johnny-five");
var board = new five.Board();

var PWM_L = 10;
var PWM_R = 9;
var DIR_L = 8;
var DIR_R = 7;

board.on("ready", function() {
  var left = new five.Motor({ pins: {
      pwm: PWM_L,
      dir: DIR_L
    }
  });

  var right = new five.Motor([ PWM_R, DIR_R ]);

  var run = true;

  this.repl.inject({
    stop: function() {
      left.stop();
      right.stop();

      run = false;
    },
    start: function() {
      run = true;
    }
  });

  var fwd = false;
  this.loop(500, function() {
    if (!run) {
      return;
    }

    fwd = !fwd;

    var speed = 50;
    if (fwd) {
      left.forward(speed);
      right.forward(speed);
    }
    else {
      left.reverse(speed);
      right.reverse(speed);
    }
  });
});
