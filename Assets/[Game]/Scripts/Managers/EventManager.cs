using UnityEngine.Events;

public static class EventManager
{
    #region Game State Events
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameOver = new UnityEvent();
    #endregion

    #region Level Events
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();
    public static UnityEvent OnLevelChange = new UnityEvent();
    public static UnityEvent OnSceneLoaded = new UnityEvent();

    #endregion

    #region Obstacle Events
    public static UnityEvent OnObstacleOpen = new UnityEvent();
    public static UnityEvent OnObstacleClose = new UnityEvent();

    public static UnityEvent OnPlayerWait = new UnityEvent();

    public static UnityEvent OnPlayerHittarget = new UnityEvent();
    #endregion





}