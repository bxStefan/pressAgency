namespace pressAgency.Shared.Enums
{
    public class LockStateEnum
    {
        public enum LockState
        {
            Created, // requesting author created lock
            Already_Owned, // requesting author already owns the lock
            Locked // another author owns the lock
        }
    }
}
