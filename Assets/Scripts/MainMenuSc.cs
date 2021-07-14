using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSc : MonoBehaviour
{
    public void QuitBtn()
    {
        Application.Quit();
        Debug.Log("Closed.");
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("Platform");
        Debug.Log("Opened scifibg scene.");
    }
}
