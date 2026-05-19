using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Sound Effects")]
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip enemyDeathSound;
    [SerializeField] private AudioClip healSound;
    [SerializeField] private AudioClip shieldSound;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip levelUpSound;

    private AudioSource _source;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _source = GetComponent<AudioSource>();
    }

    public void PlayHit()       => Play(hitSound);
    public void PlayEnemyDeath() => Play(enemyDeathSound);
    public void PlayHeal()      => Play(healSound);
    public void PlayShield()    => Play(shieldSound);
    public void PlayGameOver()  => Play(gameOverSound);
    public void PlayLevelUp()   => Play(levelUpSound);

    private void Play(AudioClip clip)
    {
        if (clip != null)
            _source.PlayOneShot(clip);
    }
}
