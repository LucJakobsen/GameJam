using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingBehavior : MonoBehaviour
{
    bool showWinScreen;
    bool showLossScreen;

    int sceneIndex;

    GameBehavior gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameManager.souls > gameManager.maxSoulsToWin)
            {
                showLossScreen = true;
                Debug.Log("You gathered too many souls to win");
            } else
            {
                showWinScreen = true;
                Debug.Log("You Won!");
            }
        }
    }

    private void OnGUI()
    {
        if (showLossScreen == true)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
                   Screen.height / 2 - 50, 200, 100),
                   "You must restart to win!"))
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }

        if (showWinScreen == true)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
                   Screen.height / 2 - 50, 200, 100),
                   "You win!"))
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }
}
