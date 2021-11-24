using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{

    public int sceneIndex;
    private void OnGUI()
    {
        if(sceneIndex == 2){
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
                   Screen.height / 2 - 100, 200, 100),
                   "You must restart to win lol!"))
            {
                SceneManager.LoadScene(0);
            } 
        } else if (sceneIndex == 3){
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
                   Screen.height / 2 - 100, 200, 100),
                   "You Have a soul!!"))
            {
                SceneManager.LoadScene(0);
            }     
        }
    }
}
