using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    GameObject credits;

    public void BeginGame() {
        SceneManager.LoadScene(1);
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
