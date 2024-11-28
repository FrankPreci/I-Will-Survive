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
    public int level { get; private set; } = 1;
    public int currentEXP = 0;
    public int maxEXP { get; protected set; } = 100;
    public EXPLeveling expLeveling; // Reference to the EXPLeveling script
    public TextMeshProUGUI levelText;
    public GameObject levelUpPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        swarm = GameObject.Find("EnemySpawner");
        updateLVLText();
        if (levelUpPanel != null)
        {
            levelUpPanel.SetActive(false);
        }
    }
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        // Input detection (WASD or Arrow Keys)
        float moveX = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right Arrow
        float moveY = Input.GetAxisRaw("Vertical");    // W/S or Up/Down Arrow

        Vector2 movement = new Vector2(moveX * horizontalSpeed, moveY * verticalSpeed);

        rb.velocity = movement;
        if (currentEXP >= maxEXP)
        {
            LevelUp();
        }
            expLeveling.SetEXP(currentEXP);
        if (!this.gameObject.activeInHierarchy)
        {
            swarm.SetActive(false);
        }
    }
    public void GainExperience(int amount)//For testing purposes
    {
        currentEXP += amount;
    }
    public void LevelUp()
    {
        currentEXP = currentEXP % maxEXP;
        maxEXP += 50;
        expLeveling.SetMaxEXP(maxEXP);
        level += 1;
        Debug.Log("Level " + level+ "\nNew Max EXP:" + maxEXP);
        updateLVLText();
        if (levelUpPanel != null)
        {
            levelUpPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void updateLVLText()
    {
        // Ensure levelText is assigned and update its text
        if (levelText != null)
        {
            levelText.text = "Level: " + level;
        }
    }
    public void DismissLevelUpPanel()
    {
        // Hide the level-up UI panel
        if (levelUpPanel != null)
        {
            levelUpPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}