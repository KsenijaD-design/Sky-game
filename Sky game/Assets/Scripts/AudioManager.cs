using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audio;

    [SerializeField] private AudioClip obstaclehit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        obstacle.OnPlayerHit += PlayObstacleSound;
    }

    private void PlayObstacleSound()
    {
        audio.PlayOneShot(obstaclehit);
    }
}
