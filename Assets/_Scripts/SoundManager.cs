using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    AudioSource audio;
    public AudioClip enemyGrunt;
    public AudioClip enemyHurt;
    public AudioClip enemyDie;
    public AudioClip playerHurt;
    public AudioClip playerDie;

    public AudioClip shotgun;
    public AudioClip water;


    void Awake() {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

 public  void PlayClip(AudioClip clip) {
        
        audio.clip = clip;
        if (audio.isPlaying) {
            return;
        }
        audio.Play();
    }

    public void StopAudio() {
        audio.Stop();
            }
}
