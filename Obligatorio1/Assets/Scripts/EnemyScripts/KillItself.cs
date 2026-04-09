using UnityEngine;

public class KillItself : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject self = animator.gameObject;
        Destroy(self);
    }
}
