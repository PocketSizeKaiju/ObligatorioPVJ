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
                // Busca el archivo "Settings" dentro de cualquier carpeta "Resources"
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
    public float MinCreateEnemyInterval = 0.3f;

    [Header("Economy")]
    public int CoinCount; 
}
