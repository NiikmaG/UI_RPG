using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private TextMeshProUGUI playerInfoText;

    [Header("Enemy")]
    [SerializeField] private TextMeshProUGUI enemyInfoText;
    [SerializeField] private Image zombieImage;
    [SerializeField] private Image vampireImage;

    [Header("Battle Log")]
    [SerializeField] private TextMeshProUGUI battleLogText;

    [Header("Other")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button attackButton;

    private Enemy _lastEnemy;

    public void UpdateUI(Player player, Enemy enemy)
    {
        if (playerInfoText)
        {
            playerInfoText.text =
                $"Player:\n" +
                $"Current HP: {player.Hp} / {player.MaxHp}\n" +
                $"Current spell: - / {player.Weapon?.Name ?? "Fists"}\n" +
                $"Level: {player.Level}  XP: {player.Exp}/{player.ExpToNextLevel}\n" +
                $"------------\n" +
                $"Current Shield: {player.ShieldHp}\n" +
                $"Is shield on? {(player.ShieldOn ? "Yes" : "No")}";
        }

        if (enemyInfoText)
        {
            enemyInfoText.text =
                $"{enemy.Name}:\n" +
                $"Current HP: {enemy.Hp} / {enemy.MaxHp}\n" +
                $"Current spell: - / Pierce";
        }

        bool isZombie = enemy is Zombie;
        Image activeImage = isZombie ? zombieImage : vampireImage;
        Image hiddenImage = isZombie ? vampireImage : zombieImage;

        if (hiddenImage) hiddenImage.gameObject.SetActive(false);

        if (activeImage)
        {
            bool enemyChanged = enemy != _lastEnemy;
            if (enemyChanged)
            {
                StopAllCoroutines();
                StartCoroutine(FadeIn(activeImage));
            }
        }

        _lastEnemy = enemy;

        if (gameOverPanel) gameOverPanel.SetActive(!player.IsAlive);
        if (attackButton) attackButton.interactable = player.IsAlive;
    }

    private IEnumerator FadeIn(Image image)
    {
        image.gameObject.SetActive(true);

        Color c = image.color;
        c.a = 0f;
        image.color = c;

        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsed / duration);
            image.color = c;
            yield return null;
        }

        c.a = 1f;
        image.color = c;
    }

    public void ShowLog(string message)
    {
        if (battleLogText) battleLogText.text = message;
    }
}
