using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadSceneScript : MonoBehaviour
{

    public Animator startButton;
    public Animator settingsButton;
    public Animator quitButton;
    public Animator dialog;

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenSettings()
    {
        startButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        quitButton.SetBool("isHidden", true);
        dialog.SetBool("isHidden", false);
    }

    public void CloseSettings()
    {
        startButton.SetBool("isHidden", false);
        settingsButton.SetBool("isHidden", false);
        quitButton.SetBool("isHidden", false);
        dialog.SetBool("isHidden", true);
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
