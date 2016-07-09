require 'artoo'

connection :arduino, adaptor: :firmata, port: '/dev/cu.usbmodem1421'
device :left_motor, :driver => :motor, :speed_pin => 10, forward_pin: 13, backward_pin: 8
device :right_motor, :driver => :motor, :speed_pin => 9, forward_pin: 13, backward_pin: 7

work do
  fwd = true
  speed = 50

  every(1.seconds) do
    if (fwd)
      left_motor.forward speed
      right_motor.forward speed
    else
      left_motor.backward speed
      right_motor.backward speed
    end

    fwd = !fwd
  end
end
