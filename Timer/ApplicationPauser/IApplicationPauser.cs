namespace Components.Timer
{
    public interface IApplicationPauser : IPausable
    {
        void SubscribePausable(IPausable iPausable);
        void UnSubscribePausable(IPausable iPausable);
    }
}

