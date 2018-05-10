using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;


    void Awake()
    {
       // GameObject[] objct = GameObject.FindGameObjectsWithTag("Character");
      //  if (objct.Length > 1) Destroy(this.gameObject);
      //  DontDestroyOnLoad(this.gameObject);
    }

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
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("GameScene");
    }

}
