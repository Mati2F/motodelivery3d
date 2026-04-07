using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    private AudioSource audioSource;

    public AudioClip musicaMenu;
    public AudioClip musicaJuego;

    public AudioClip sonidoVictoria;
    public AudioClip sonidoDerrota;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirMenu()
    {
        if (audioSource.clip == musicaMenu && audioSource.isPlaying) return; 

        audioSource.clip = musicaMenu;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void ReproducirJuego()
    {
        if (audioSource.clip == musicaJuego && audioSource.isPlaying) return;

        audioSource.clip = musicaJuego;
        audioSource.loop = false;
        audioSource.Play();
    }
    public void ReproducirSonido(AudioClip clip)
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Stop();
        audio.loop = false;
        audio.clip = clip;
        audio.Play();
    }

    public void DetenerMusica()
    {
        GetComponent<AudioSource>().Stop();
    }
}