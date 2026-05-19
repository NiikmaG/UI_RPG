using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Player player;
    [SerializeField] private Zombie zombieEnemy;
    [SerializeField] private Vampire vampireEnemy;
    [SerializeField] private UIManager uiManager;

    private Enemy _currentEnemy;
    private int _enemyCount = 0;
    private bool _gameOver = false;

    public Player Player => player;
    public Enemy CurrentEnemy => _currentEnemy;
    public bool GameOver => _gameOver;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        player.ResetStats();
        _enemyCount = 0;
        _gameOver = false;

        zombieEnemy.gameObject.SetActive(false);
        vampireEnemy.gameObject.SetActive(false);

        SpawnEnemy();
        uiManager.UpdateUI(player, _currentEnemy);
        uiManager.ShowLog("Game started! Attack the enemy!");
    }

    private void SpawnEnemy()
    {
        if (_currentEnemy != null)
            _currentEnemy.gameObject.SetActive(false);

        _enemyCount++;
        _currentEnemy = (_enemyCount % 2 == 1) ? (Enemy)zombieEnemy : vampireEnemy;

        _currentEnemy.ResetHp();
        _currentEnemy.gameObject.SetActive(true);
    }

    public void PlayerAttack()
    {
        if (_gameOver) return;

        string log = "";

        int dmg = player.Attack(_currentEnemy);
        string weapon = player.Weapon?.Name ?? "Fists";
        log += $"{player.Name} attacks with {weapon} for {dmg} damage!\n";

        if (!_currentEnemy.IsAlive)
        {
            AudioManager.Instance?.PlayEnemyDeath();
            log += $"{_currentEnemy.Name} is defeated!\n";
            int exp = _currentEnemy.ExpReward;
            int oldLevel = player.Level;
            player.GainExp(exp);
            log += $"Gained {exp} XP!\n";

            if (player.Level > oldLevel)
            {
                AudioManager.Instance?.PlayLevelUp();
                log += $"Level up! Now level {player.Level}!\n";
            }

            SpawnEnemy();
            log += $"A new enemy appears: {_currentEnemy.Name}!";
        }
        else
        {
            AudioManager.Instance?.PlayHit();
            int enemyDmg = _currentEnemy.Attack(player);
            log += $"{_currentEnemy.Name} uses {_currentEnemy.AttackName} for {enemyDmg} damage!";

            if (!player.IsAlive)
            {
                _gameOver = true;
                AudioManager.Instance?.PlayGameOver();
                log += "\nYou died! Game over!";
            }
        }

        uiManager.UpdateUI(player, _currentEnemy);
        uiManager.ShowLog(log);
    }

    public void EquipWeapon(int index)
    {
        switch (index)
        {
            case 0: player.EquipSword(); break;
            case 1: player.EquipStaff(); break;
            case 2: player.EquipBow();   break;
        }
        uiManager.UpdateUI(player, _currentEnemy);
        uiManager.ShowLog($"Equipped: {player.Weapon?.GetDescription(true)}");
    }

    public void CastSpell(int index)
    {
        if (_gameOver) return;
        AudioManager.Instance?.PlayHeal();
        string result = player.CastSpell(index, _currentEnemy);
        uiManager.UpdateUI(player, _currentEnemy);
        uiManager.ShowLog(result);
    }

    public void ToggleShield()
    {
        if (_gameOver) return;
        AudioManager.Instance?.PlayShield();
        player.ToggleShield();
        uiManager.UpdateUI(player, _currentEnemy);
        uiManager.ShowLog(player.ShieldOn ? "Shield activated!" : "Shield deactivated!");
    }

    public void RepairShield()
    {
        if (_gameOver) return;
        AudioManager.Instance?.PlayShield();
        player.RepairShield();
        uiManager.UpdateUI(player, _currentEnemy);
        uiManager.ShowLog("Shield repaired!");
    }

    public void RestartGame()
    {
        InitializeGame();
    }
}
