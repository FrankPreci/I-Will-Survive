using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI statsText;
    private Player player;
    private Health health;

    void Start()
    {
        player = FindObjectOfType<Player>();
        health = player.GetComponent<Health>();
    }

    public void UpdateStatsDisplay()
    {
        if (statsText != null && player != null && health != null)
        {
            statsText.text = 
                $"Level: {player.level}\n" +
                $"Health: {health.currentHealth} / {health.maxHealth}\n" +
                $"Movement Speed: {player.horizontalSpeed * player.movementSpeedMultiplier:F1}\n" +
                $"Attack: {10 + (5 * player.damageMultiplier)}";
        }
    }
}