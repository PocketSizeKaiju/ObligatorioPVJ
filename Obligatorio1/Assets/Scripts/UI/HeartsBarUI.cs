using System.Reflection;
using UnityEngine;

public class HeartsBarUI : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool isActive;

    public void ActiveHeart()
    {
        animator.SetTrigger("Restore");
        isActive = true;
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
