using UnityEngine;

public class showSecrete : MonoBehaviour
{
    public GameObject toHide;
    public GameObject toShow;

    public AudioClip toPlay;
    public GameObject whereToPlay;

    public GameObject player;
    public RuntimeAnimatorController altController;

    void Awake()
    {
        if (toHide)
        {
            toHide.SetActive(!Settings.Instance.umapyoi);
        }
        if (toShow)
        {
            toShow.SetActive(Settings.Instance.umapyoi);
        }

        if (Settings.Instance.umapyoi && toPlay && whereToPlay)
        {
            AudioSource source = whereToPlay.GetComponent<AudioSource>();
            source.clip = toPlay;
            source.loop = true;
            source.Play();
        }

        if (Settings.Instance.umapyoi && player)
        {
            Animator anim = player.GetComponent<Animator>();
            if (anim && altController)
                anim.runtimeAnimatorController = altController;
        }
    }
}
