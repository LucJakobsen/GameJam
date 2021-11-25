using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField]
    private PlayerBehavior _pb;

    private float sceneOne = 0f;
    private float sceneOneSwap = 10f;

    private float sceneTwo = 21f;
    private float sceneTwoBottom = 10f;
    private float sceneTwoTop = 30f;

    private float sceneThree = 41f;
    private float sceneThreeBottom = 30f;
    private float sceneThreeTop = 50f;

    private float sceneFour = 61f;
    private float sceneFourBottom = 50f;
    private float sceneFourTop = 70f;

    private float sceneFive = 81f;
    private float sceneFiveBottom = 70f;

    
    
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
            SceneSwap(new Vector3(transform.position.x, sceneOne, transform.position.z));
        }
        else if (_pb.transform.position.y >= sceneTwoBottom && _pb.transform.position.y <= sceneTwoTop)
        {
            SceneSwap(new Vector3(transform.position.x, sceneTwo, transform.position.z));
        }
        else if (_pb.transform.position.y >= sceneThreeBottom && _pb.transform.position.y <= sceneThreeTop)
        {
            SceneSwap(new Vector3(transform.position.x, sceneThree, transform.position.z));
        }
        else if (_pb.transform.position.y >= sceneFourBottom && _pb.transform.position.y <= sceneFourTop)
        {
            SceneSwap(new Vector3(transform.position.x, sceneFour, transform.position.z));
        }
        else if (_pb.transform.position.y >= sceneFiveBottom)
        {     
            SceneSwap(new Vector3(transform.position.x, sceneFive, transform.position.z));
        }
    }


    // Every method below transform the cameras position on Y axis only, to match the given scene.
    private void SceneSwap(Vector3 vector3)
    {
        this.transform.position = vector3;
    }
}
