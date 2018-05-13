using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadSceneScript : MonoBehaviour
{
    //declare animators for the buttons, this can be set in unity 
    public Animator startButton;
    public Animator settingsButton;
    public Animator quitButton;
    public Animator dialog;
    public Animator divider;

    public void StartGame()
    {
        //on start button press load character selection
        SceneManager.LoadScene("CharacterSelect");
    }

    public void OpenSettings()
    {
        //open settings and hide all other buttons
        startButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        quitButton.SetBool("isHidden", true);
        divider.SetBool("isHidden", true);
        dialog.SetBool("isHidden", false);
    }

    public void CloseSettings()
    {
        //close settings, and show all other buttons
        startButton.SetBool("isHidden", false);
        settingsButton.SetBool("isHidden", false);
        quitButton.SetBool("isHidden", false);
        divider.SetBool("isHidden", false);
        dialog.SetBool("isHidden", true);
    }

    public void quitGame()
    {
        //quit game on quit press
        Application.Quit();
    }

}
