const five = require("johnny-five");
const board = new five.Board();

const PWM_L = 10;
const PWM_R = 9;
const DIR_L = 8;
const DIR_R = 7;

const speed = 50;
const sleep = 1000;

const motor = (pwm, dir) => {
  return new five.Motor([ pwm, dir ]);
};

let run = true;
const setupRepl = (runtime, left, right) => {
  runtime.repl.inject({
    stop: () => {
      left.stop();
      right.stop();

      run = false;
    },
    start: () => {
      run = true;
    }
  });
};

board.on("ready", function() {
  const left = motor(PWM_L, DIR_L);
  const right = motor(PWM_R, DIR_R);

  setupRepl(this, left, right);

  let fwd = false;
  this.loop(sleep, () => {
    if (!run) {
      return;
    }

    fwd = !fwd;

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
