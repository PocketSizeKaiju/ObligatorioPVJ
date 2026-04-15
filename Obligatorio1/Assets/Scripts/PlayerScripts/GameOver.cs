using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Time.timeScale = 0.4f;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject self = animator.gameObject;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameOverScene");
        Destroy(self);
    }
}
