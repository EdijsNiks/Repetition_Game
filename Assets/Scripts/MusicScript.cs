using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource normalMusic; // Reference to the AudioSource for normal music
    public AudioSource attackMusic; // Reference to the AudioSource for attack music

    [SerializeField] private GameObject enemyObject; // Reference to the enemy GameObject

    void Start()
    {
        // Start with normal music
        PlayNormalMusic();
    }

    void Update()
    {
        // Check if the enemy object is active
        bool isEnemyActive = IsEnemyActive();

        // Manage music based on the state of the enemy object
        if (isEnemyActive)
        {
            // If the enemy is active, play attack music
            PlayAttackMusic();
        }
        else
        {
            // If the enemy is not active, play normal music
            PlayNormalMusic();
        }
    }

    bool IsEnemyActive()
    {
        // Check if the enemy object is active
        return enemyObject != null && enemyObject.activeSelf;
    }

    void PlayNormalMusic()
    {
        // Stop attack music if playing
        if (attackMusic.isPlaying)
        {
            attackMusic.Stop();
        }

        // Play normal music if not already playing
        if (!normalMusic.isPlaying)
        {
            normalMusic.Play();
        }
    }

    void PlayAttackMusic()
    {
        // Stop normal music if playing
        if (normalMusic.isPlaying)
        {
            normalMusic.Stop();
        }

        // Play attack music if not already playing
        if (!attackMusic.isPlaying)
        {
            attackMusic.Play();
        }
    }
}

