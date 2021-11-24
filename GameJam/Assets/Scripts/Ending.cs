using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    private void OnGUI()
    {
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
                   Screen.height / 2 - 100, 200, 100),
                   "You must restart to win lol!"))
            {
                SceneManager.LoadScene(0);
            }
    }
}
