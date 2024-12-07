using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private float elapsedTime;
    private bool playerAlive = true;
    public float ElapsedTime => elapsedTime;
    // Update is called once per frame
    void Update()
    {
        if (playerAlive)
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    public void StopTimer()
    {
        playerAlive = false;
    }
}