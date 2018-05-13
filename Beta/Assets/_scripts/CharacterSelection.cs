using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;

    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        characterList = new GameObject[3];

        //Fill the aray with our models
        for (int i = 0; i < 3; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        // we toggle off their renderer
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }

        //we toggle on the selected character
        if (characterList[index])
        {
            characterList[index].SetActive(true);
        }

    }

    public void ToggleLeft()
    {
        // Toggle off the current model
        characterList[index].SetActive(false);

        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }

        // Toggle on the new model
        characterList[index].SetActive(true);


    }

    public void ToggleRight()
    {
        // Toggle off the current model
        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }

        // Toggle on the new model
        characterList[index].SetActive(true);


    }

    public void SelectButton()
    {
        //select player and set into something called PlayerPrefs
        //this will store the player so for next selection it is the character chosen
        PlayerPrefs.SetInt("CharacterSelected", index);
        //load the scene now
        SceneManager.LoadScene("GameScene");
    }

}
