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
                SceneManager.LoadScene(2);
                
            } else
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
