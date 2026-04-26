using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Scriptable Objects/Settings")]
public class Settings : ScriptableObject
{
    private static Settings _instance;

    public static Settings Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<Settings>("Settings");

                if (_instance == null)
                {
                    Debug.LogError("FATAL: No se encontró el asset 'Settings' en una carpeta Resources. " +
                        "Crea uno (Click derecho > Scriptable Objects > Settings) y muévelo a Assets/Resources/Settings");
                }
            }
            return _instance;
        }
    }

    [Header("Player Settings")]
    public float PlayerSpeed = 10f;
    public float PlayerForce = 10f;
    public float PlayerShootInterval = 1.5f;
    public float PlayerShotSpeed = 12f;

    [Header("Enemy Settings")]
    public int StartingEnemyCount = 5;
    public float EnemySpeed = 8f;
    public float BaseCreateEnemyInterval = 3f;
    public float CreateEnemyIntervalDecreasePerSecond = 0.1f;
    [Tooltip("Defines the minimum of time of which the enemies would be spawn")]
    public float MinCreateEnemyInterval = 0.3f;
    [Tooltip("Fixed interval (seconds) between obstacle spawns")]
    public float ObstacleSpawnInterval = 5f;

    [Header("Difficulty Ramp")]
    [Tooltip("Seconds of survival until difficulty is fully maxed out")]
    public float DifficultyMaxRampTime = 120f;

    [Header("Difficulty Spike Bursts")]
    [Tooltip("A burst of hard enemies fires every this many seconds")]
    public float DifficultyBurstInterval = 30f;
    [Tooltip("How many enemies spawn in the first burst")]
    public int BaseBurstEnemyCount = 3;
    [Tooltip("Burst grows by 1 enemy for every N seconds survived")]
    public float BurstCountIncreaseEverySeconds = 30f;
    [Tooltip("Maximum enemies in a single burst")]
    public int MaxBurstEnemyCount = 10;
    [Tooltip("Seconds between each enemy spawn within a burst")]
    public float BurstSpawnDelay = 0.4f;

    [Header("Player bounds")]
    [Tooltip("Defines players bounds")]
    public float PlayerBoundsYMin = -4.580837f;
    [Tooltip("Defines players bounds")]
    public float PlayerBoundsYMax = -0.580837f;
    [Tooltip("Defines players bounds")]
    public float PlayerBoundsXMin = -8.59049f;
    [Tooltip("Defines players bounds")]
    public float PlayerBoundsXMax = 6.40951f;

    [Header("Economy")]
    public int CoinCount;

    [Header("Enemy bounds")]
    public float EnemyFloorBoundsMax = -0.5f;
    public float EnemyFloorBoundsMin = -5;
    public float EnemySkyBoundsMax = 7.5f;
    public float EnemySkyBoundsMin = 0.4f;

    [Header("Sound modifiers")]
    public float lowPitchRange = .75F;
    public float highPitchRange = 1.5F;
    public float velToVol = .2F;
    public float velocityClipSplit = 10F;
    [Header("")]
    public bool umapyoi = false;
}