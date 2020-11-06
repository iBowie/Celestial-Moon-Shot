using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public static MainPlayer mainPlayer { get; private set; }
    public PlayerInventory inventory;

    void Awake()
    {
        mainPlayer = this;
        inventory = GetComponent<PlayerInventory>();
    }
}
