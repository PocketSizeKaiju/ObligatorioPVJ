using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Scriptable Objects/Settings")]
public class Settings : ScriptableObject
{
    
    static public Settings Instance;



    public void OnEnable()
    {
        Instance = this;
    }

    [Tooltip("Defines the speed of the player")]
    public float PlayerSpeed;
    [Tooltip("Defines the amount of enemies to spawn")]
    public int StartingEnemyCount;
    [Tooltip("Defines the speed of the enemy")]
    public float EnemySpeed = 8;
    [Tooltip("Defines the how long it takes for each shot of the player")]
    public float PlayerShootInterval = 1.5f;
    [Tooltip("Defines the fast the players bullet will move")]
    public float PlayerShotSpeed = 12;
    [Tooltip("Defines how long it takes for a new enemy to spawn")]
    public float BaseCreateEnemyInterval = 3;
    [Tooltip("Defines fast the enemy spawning would increase")]
    public float CreateEnemyIntervalDecreasePerSecond = 0.1f;
    [Tooltip("Defines the minimum of time of which the enemies would be spawn")]
    public float MinCreateEnemyInterval = 0.3f;


    [Tooltip("Defines players bounds")]
    public float PlayerBoundsYMin = -4.580837f;
    [Tooltip("Defines players bounds")]
    public float PlayerBoundsYMax = -0.580837f;
    [Tooltip("Defines players bounds")]
    public float PlayerBoundsXMin = -8.59049f;
    [Tooltip("Defines players bounds")]
    public float PlayerBoundsXMax = 6.40951f;
}
