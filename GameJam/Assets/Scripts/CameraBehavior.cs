using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField]
    private PlayerBehavior _pb;

    private Vector3 offSet;

    
    //private float sceneSwap = 5f;

    private float sceneOne = 0f;
    private float sceneOneSwap = 4.9f;
    

    private float sceneTwo = 10f;
    private float sceneTwoBottom = 5f;
    private float sceneTwoTop = 14.9f;

    private float sceneThree = 20f;
    private float sceneThreeBottom = 15f;
    private float sceneThreeTop = 24.9f;

    private float sceneFour = 30f;
    private float sceneFourBottom = 25f;
    private float sceneFourTop = 34.9f;

    private float sceneFive = 40f;
    private float sceneFiveBottom = 35f;

    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If statements, that checks if player position is between a bottom & top variable that corresponds to the background

        if (_pb.transform.position.y <= sceneOneSwap)
        {
            SceneOne();
        }
        else if (_pb.transform.position.y >= sceneTwoBottom && _pb.transform.position.y <= sceneTwoTop)
        {
            SceneTwo();
        }
        else if (_pb.transform.position.y >= sceneThreeBottom && _pb.transform.position.y <= sceneThreeTop)
        {
            SceneThree();
        }
        else if (_pb.transform.position.y >= sceneFourBottom && _pb.transform.position.y <= sceneFourTop)
        {
            SceneFour();
        }
        else if (_pb.transform.position.y >= sceneFiveBottom)
        {     
            SceneFive();
        }
    }


    // Every method below transform the cameras position on Y axis only, to match the given scene.
    private void SceneOne()
    {
        this.transform.position = new Vector3(transform.position.x, sceneOne, transform.position.z);
    }

    private void SceneTwo()
    {        
        this.transform.position = new Vector3(transform.position.x, sceneTwo, transform.position.z);
    }

    private void SceneThree()
    {
        this.transform.position = new Vector3(transform.position.x, sceneThree, transform.position.z);
    }

    private void SceneFour()
    {
        this.transform.position = new Vector3(transform.position.x, sceneFour, transform.position.z);
    }

    private void SceneFive()
    {
        this.transform.position = new Vector3(transform.position.x, sceneFive, transform.position.z);
    }

}
