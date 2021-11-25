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
            if (GUI.Button(new Rect(Screen.width / 2 + 50,
                   Screen.height / 2 + 75, 200, 50),
                   "Click to try again!"))
            {
                SceneManager.LoadScene(0);
            } 
        } else if (sceneIndex == 3){
            if (GUI.Button(new Rect(Screen.width / 2 + 50,
                   Screen.height / 2 + 75, 200, 50),
                   "You Won! Click to play again"))
            {
                SceneManager.LoadScene(0);
            } 
        }
    }
}
