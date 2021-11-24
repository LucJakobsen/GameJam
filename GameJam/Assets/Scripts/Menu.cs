using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Menu : MonoBehaviour
{
    public GameObject MenuButtons;


    private void Start()
    {
        MenuButtons.SetActive(true);

    }
    public void OnStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }


}
