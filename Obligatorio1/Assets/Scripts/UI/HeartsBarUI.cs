using System.Reflection;
using UnityEngine;

public class HeartsBarUI : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool isActive;

    public void ActiveHeart()
    {
        isActive = true;
        animator.SetTrigger("Restore");
    }
    
    public void DeactiveHeart()
    {
        animator.SetTrigger("Damage");
        isActive = false;
    }
    public bool GetIsActive()
    {
        return isActive;
    }
}
