using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Scriptable Objects/Settings")]
public class Settings : ScriptableObject
{
    
    static public Settings Instance;

    public Settings()
    {
        Instance = this;
    }

    [Tooltip("Defines the speed of the player")]
    public float PlayerSpeed;    
    public int CoinCount;
    public int PlayerLife;
}
