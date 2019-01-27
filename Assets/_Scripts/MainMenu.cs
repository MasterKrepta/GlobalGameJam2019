using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField]GameObject credits;
    [SerializeField] GameObject playerui;

    private void Start() {
        Cursor.visible = true;
        Time.timeScale = 0;
         //playerui.SetActive(false);
        
    }
    public void BeginGame() {
        main.SetActive(false);
        //Cursor.visible = false;
        Time.timeScale = 1;
        playerui.SetActive(true);
        //SceneManager.LoadScene(1);
    }

    private void Update() {
        Cursor.visible = true;
    }
    public void ShowCredits() {
        credits.SetActive(true);
    }
    public void HideCredits() {
        credits.SetActive(false);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
