using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public AudioSource titleMusic;
    public AudioSource[] bgMusic;
    private int currentTrack;

    private bool isPaused;

    public AudioSource[] sfx;

    private void Start()
    {
        currentTrack = -1;
    }

    private void Update()
    {
        if (isPaused == false)
        {
            if (bgMusic[currentTrack].isPlaying == false)
            {
                playNextBGM(); // 현재 트랙 재생이 끝났다면 다음 트랙 재생
            }
        }
    }

    public void StopMusic()
    {
        foreach(AudioSource track in bgMusic)
        {
            track.Stop();
        }

        titleMusic.Stop();
    }

    public void PlayTitle()
    {
        StopMusic();
        titleMusic.Play();
    }

    public void playNextBGM()
    {
        StopMusic();

        currentTrack++;

        if(currentTrack >= bgMusic.Length)
        {
            currentTrack = 0;
        }

        bgMusic[currentTrack].Play();
    }

    public void PauseMusic()
    {
        isPaused = true;

        bgMusic[currentTrack].Pause();
    }

    public void ResumeMusic()
    {
        isPaused = false;

        bgMusic[currentTrack].Play();
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();
    }

    public void PlaySFXPitchAdjusted(int sfxToPlay)
    {
        sfx[sfxToPlay].pitch = Random.Range(.8f, 1.2f);

        PlaySFX(sfxToPlay);
    }
}
