using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private TextMeshProUGUI playerInfoText;

    [Header("Enemy")]
    [SerializeField] private TextMeshProUGUI enemyInfoText;

    [Header("Battle Log")]
    [SerializeField] private TextMeshProUGUI battleLogText;

    [Header("Other")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button attackButton;

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

        if (gameOverPanel) gameOverPanel.SetActive(!player.IsAlive);
        if (attackButton) attackButton.interactable = player.IsAlive;
    }

    public void ShowLog(string message)
    {
        if (battleLogText) battleLogText.text = message;
    }
}
