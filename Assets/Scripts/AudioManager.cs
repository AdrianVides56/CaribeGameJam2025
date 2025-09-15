using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField]
    private float delay;
    [SerializeField]
    private AudioSource loopAudio;

    void Awake()
    {
        Instance = this;

    }

    void Start()
    {
        //Debug.Log("Start AudioManager");
        if (!loopAudio.isPlaying)
        {
            StartCoroutine(PlayAudioLoop());
        }
    }



    public IEnumerator PlayAudioLoop()
    {
        //Debug.Log("StartPlayAudioLoop");
        yield return new WaitForSeconds(delay);
        loopAudio.Play();
        loopAudio.pitch = 1;
        loopAudio.volume = 1;

        //Debug.Log("EndPlayAudioLoop");
    }
}
