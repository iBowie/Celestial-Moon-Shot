using UnityEngine;

public static class PauseManager
{
    private static bool _isPaused;
    public static bool IsPaused
    {
        get => _isPaused;
        set
        {
            if (value)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public static void Resume()
    {
        if (!_isPaused)
            return;

        _isPaused = false;
        Time.timeScale = 1f;
    }
    public static void Pause()
    {
        if (_isPaused)
            return;

        _isPaused = true;
        Time.timeScale = 0f;
    }
}
