namespace Input
{
    public class JoystickInput : IPlayerInput
    {
        private readonly VariableJoystick _joystick;

        public JoystickInput(VariableJoystick joystick)
        {
            _joystick = joystick;
        }

        public float Horizontal => _joystick.Horizontal;
        public float Vertical => _joystick.Vertical;
        public bool IsPressed => _joystick.Direction.magnitude != 0;
    }
}