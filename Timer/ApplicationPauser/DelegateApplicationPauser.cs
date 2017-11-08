namespace Components.Timer
{
    public class DelegateApplicationPauser : IApplicationPauser
    {
        public static DelegateApplicationPauser Instance = new DelegateApplicationPauser();

        private event TimerAction OnPauseAction;
        private event TimerAction OnUnPauseAction;

        public void Pause()
        {
            if (OnPauseAction != null)
            {
                OnPauseAction.Invoke();
            }
        }

        public void SubscribePausable(IPausable iPausable)
        {
            OnPauseAction += iPausable.Pause;
            OnUnPauseAction += iPausable.UnPause;
        }

        public void UnPause()
        {
            if (OnUnPauseAction != null)
            {
                OnUnPauseAction.Invoke();
            }
        }

        public void UnSubscribePausable(IPausable iPausable)
        {
            OnPauseAction -= iPausable.Pause;
            OnUnPauseAction -= iPausable.UnPause;
        }
    }
}

