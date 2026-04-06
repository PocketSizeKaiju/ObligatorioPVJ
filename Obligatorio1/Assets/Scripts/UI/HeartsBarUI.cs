using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class HeartsBarUI : MonoBehaviour
{
    [SerializeField] private Image heartImage;
    [SerializeField] private bool isActive;

    public void ActiveHeart()
    {
        heartImage.enabled = true;
        isActive = true;
    }
    
    public void DeactiveHeart()
    {
        heartImage.enabled = false;
        isActive = false;
    }
    public bool GetIsActive()
    {
        return isActive;
    }
}
