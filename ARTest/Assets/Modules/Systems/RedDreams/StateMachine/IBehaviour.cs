namespace StateMachine
{
    public interface IBehaviour
    {
        public void Enter();
        public void Exit();
        public void Update();
    }
}