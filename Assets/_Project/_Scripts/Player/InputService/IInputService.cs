
namespace MiniFarm
{
    public interface IInputService
    {
        public void ActiveState(bool activeState);
        public void SetDirectionInput(Direction direction);
        public void RegistControllable(IInputControllable controllable);
        public void UnregistControllable(IInputControllable inputControllable);
    }

    public interface IInputControllable
    {
        public void InputDirection(Direction direction);
    }
}