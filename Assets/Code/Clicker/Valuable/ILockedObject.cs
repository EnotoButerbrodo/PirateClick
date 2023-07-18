namespace Code.Clicker
{
    public interface ILockedObject
    {
        public int Cost { get; }
        public void Unlock();
    }
}