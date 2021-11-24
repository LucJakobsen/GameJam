using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    private PlayerBehavior _pb;

    private Vector3 offSet;

    private float sceneSwap = 10f;
    private float sceneTwo = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_pb.transform.position.y);
        if(_pb.transform.position.y >= sceneTwo)
        {
            NextScene();
        }
    }

    private void NextScene()
    {
        //Gives our variable offSet a value that matches the cameras position
        //and then transform.up with our sceneSwap + offSet to make sure that the camera doesn't get transformed to (0, sceneSwap, 0)
        offSet = new Vector3(0, 0, -10);
        this.transform.position = Vector3.up*sceneSwap + offSet;
    }
}
