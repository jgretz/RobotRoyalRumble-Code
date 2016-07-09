const five = require("johnny-five");
const board = new five.Board();

const LED = 13;
const sleep = 1000;

board.on("ready", () => {
  const led = new five.Led(LED);
  led.blink(sleep);
});
