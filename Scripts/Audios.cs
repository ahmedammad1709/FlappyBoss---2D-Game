using UnityEngine;

public class Audios : MonoBehaviour
{
    public AudioSource buttonClickAudio;
    public AudioSource playerDead;


    private void Start()
    {
        buttonClickAudio.Stop();
        playerDead.Stop();
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    public void ButtonClickAudio()
    {
        buttonClickAudio.Play();
    }

    public void playerDeadAudio()
    {
        playerDead.Play();
    }
}
