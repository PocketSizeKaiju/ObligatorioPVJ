using UnityEngine;

public class QuitManager : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
