using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip hitboard;
    public AudioClip hitground;
    public AudioClip hitnet;
    public AudioClip kicksound;
    public AudioClip backgroundMusic;
    public AudioClip City;
    public AudioClip Grass;
    public AudioClip ButtonClick;
    public AudioClip RunCity;
    public AudioClip RunGrass;

    private AudioSource backgroundMusicSource;
    private AudioSource soundEffectsSource;
    private static AudioManager instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        soundEffectsSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicSource.volume = 0.1f;
        soundEffectsSource.volume = 0.1f;

        PlayBackgroundMusic();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "City")
        {
            StopBackgroundMusic();
            ChangeCity();
        }
        if (scene.name == "Court")
        {
            StopBackgroundMusic();
            ChangeGrass();
        }
    }

    void PlayBackgroundMusic()
    {
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    void StopBackgroundMusic()
    {
        backgroundMusicSource.Stop();
    }
    void ChangeCity()
    {
        backgroundMusicSource.clip = City;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }
    void ChangeGrass()
    {
        backgroundMusicSource.clip = Grass;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void PlayHitBoard()
    {
        soundEffectsSource.clip = hitboard;
        soundEffectsSource.Play();
    }

    public void PlayHitGround()
    {
        soundEffectsSource.clip = hitground;
        soundEffectsSource.Play();
    }

    public void PlayHitNet()
    {
        soundEffectsSource.clip = hitnet;
        soundEffectsSource.Play();
    }

    public void PlayKickSound()
    {
        soundEffectsSource.clip = kicksound;
        soundEffectsSource.Play();
    }
    public void PlayButtonClick()
    {
        soundEffectsSource.clip = ButtonClick;
        soundEffectsSource.Play();
    }
    public void PlayRunning(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "City")
        {
            soundEffectsSource.clip = RunCity;
            soundEffectsSource.Play();
        }
        else if(scene.name == "Court")
        {
            soundEffectsSource.clip = RunGrass;
            soundEffectsSource.Play();
        }
    }
}