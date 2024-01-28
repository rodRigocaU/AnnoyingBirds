using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public float timer = 60;

    // public Text textoTimer;
    public TextMeshProUGUI textoTimerPro;
    private bool gameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (!gameIsPaused)
        {
            UpdateTimer();
            if (timer <= 0)
            {
                Debug.Log("Termino el Juego: ");
                SceneManager.LoadScene(1);
                PauseGame();

            }
        }
    }

    void UpdateTimer()
    {
        timer -= Time.deltaTime;
        string formattedTimer = timer.ToString("00");
        // textoTimer.text = "0:" + timer.ToString("f0");
        textoTimerPro.text = "0:" + formattedTimer;
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Establecer el tiempo en 0 pausará el juego
        gameIsPaused = true;
    }

    public float GetTimer()
    {
        return timer;
    }
}