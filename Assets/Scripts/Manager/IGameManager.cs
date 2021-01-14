public enum ManagerStatus
{
    SHUTDOWN,
    INITIALIZING,
    STARTED
}

public interface IGameManager
{
    ManagerStatus _Status { get; set; }

    void Startup();
}