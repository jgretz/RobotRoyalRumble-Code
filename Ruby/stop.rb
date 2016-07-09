require 'artoo'

connection :arduino, adaptor: :firmata, port: '/dev/cu.usbmodem1421'
device :left_motor, :driver => :motor, :speed_pin => 10, forward_pin: 13, backward_pin: 8
device :right_motor, :driver => :motor, :speed_pin => 9, forward_pin: 13, backward_pin: 7

work do
  left_motor.stop
  right_motor.stop
end
