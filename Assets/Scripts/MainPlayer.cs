using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public static MainPlayer mainPlayer { get; private set; }

    void Awake()
    {
        mainPlayer = this;
    }
}
