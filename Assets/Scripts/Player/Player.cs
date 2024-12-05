using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject swarm;
    public float horizontalSpeed = 2f;
    public float verticalSpeed = 2f;
    private Rigidbody2D rb;                 // Reference to the player's Rigidbody2D component
    private Vector2 movement;              // Stores movement direction
    private Health health;
    private PlayerStats playerStats;
    public int level { get; private set; } = 1;
    public int currentEXP = 0;
    public int maxEXP { get; protected set; } = 100;
    public int damageMultiplier = 0;
    public float movementSpeedMultiplier { get; private set; } = 1.0f;
    public EXPLeveling expLeveling; // Reference to the EXPLeveling script
    public TextMeshProUGUI levelText;
    public GameObject levelUpPanel;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        swarm = GameObject.Find("EnemySpawner");
        health = GetComponent<Health>();
        playerStats = FindObjectOfType<PlayerStats>();
        updateLVLText();
        if (levelUpPanel != null) {
            levelUpPanel.SetActive(false);
        }
    }
    void Update() {
        if (Time.timeScale == 0)
            return;
        // Input detection (WASD or Arrow Keys)
        float moveX = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right Arrow
        float moveY = Input.GetAxisRaw("Vertical");    // W/S or Up/Down Arrow

        Vector2 movement = new Vector2(moveX * horizontalSpeed * movementSpeedMultiplier,
                                       moveY * verticalSpeed * movementSpeedMultiplier);

        rb.velocity = movement;
        if (currentEXP >= maxEXP) {
            LevelUp();
        }
            expLeveling.SetEXP(currentEXP);
        if (!this.gameObject.activeInHierarchy)
        {
            swarm.SetActive(false);
        }
    }
    public void GainExperience(int amount) {
        currentEXP += amount;
    }
    public void LevelUp() {
        currentEXP = currentEXP % maxEXP;
        maxEXP += 50;
        expLeveling.SetMaxEXP(maxEXP);
        level += 1;
        Debug.Log("Level " + level+ "\nNew Max EXP:" + maxEXP);
        updateLVLText();
        if (levelUpPanel != null) {
            levelUpPanel.SetActive(true);
            Time.timeScale = 0;
            if (playerStats != null) {
                playerStats.UpdateStatsDisplay();
            }
        }
    }
    public void updateLVLText() {
        if (levelText != null) {
            levelText.text = "Level: " + level;
        }
    }
    public void DismissLevelUpPanel() {
        if (levelUpPanel != null) {
            levelUpPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void IncreaseDamageMultiplier() {
        damageMultiplier += 1;
        //Debug.Log("Damage Multiplier Increased: " + damageMultiplier);
        DismissLevelUpPanel();
    }
    public void IncreaseMovementSpeed() {
        movementSpeedMultiplier += 0.05f; // Increase movement speed by 5%
        //Debug.Log("Movement Speed Multiplier Increased: " + movementSpeedMultiplier);
        DismissLevelUpPanel();
    }
    public void IncreaseMaxHealth() {
        if (health != null) {
            health.IncreaseMaxHealth(10); // Call the Health script to update max health
        }
        DismissLevelUpPanel();
    }
}