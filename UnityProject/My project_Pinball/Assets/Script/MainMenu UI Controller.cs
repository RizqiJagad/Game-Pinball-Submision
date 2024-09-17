using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Tambahkan ini untuk memuat scene

public class MainMenuUIController : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;

    private void Start()
    {
        // Assign listeners untuk tombol
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    public void PlayGame()
    {
        // Memuat scene permainan
        SceneManager.LoadScene("SampleScene");
    }

    private void ExitGame() // Perbaiki metode ini
    {
        // Keluar dari game
        Application.Quit();
    }
}
