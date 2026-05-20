using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audio;

    [SerializeField] private AudioClip obstaclehit;
    [SerializeField] private AudioClip slidingSound;
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get { return instance; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
        audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        obstacle.OnPlayerHit += PlayObstacleSound;
    }

    private void OnDisable()
    {
        obstacle.OnPlayerHit -= PlayObstacleSound;
    }

    private void PlayObstacleSound()
    {
        if (audio != null && obstaclehit != null)
        {
            audio.PlayOneShot(obstaclehit);
        }
    }

    public static void PlaySlidingSound(bool playSound = true)
    {
        if (instance == null || instance.audio == null) return;

        if (playSound)
        {
            if (!instance.audio.isPlaying || instance.audio.clip != instance.slidingSound)
            {
                instance.audio.clip = instance.slidingSound;
                instance.audio.loop = true;
                instance.audio.volume = 0.30f;
                instance.audio.Play();
            }
        }
        else
        {
            if (instance.audio.isPlaying)
                instance.audio.Stop();
        }
    }
    
}




