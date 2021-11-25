using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public TextMeshProUGUI soulCounter;
    SoulBehavior Soul;
    int _soulsCollected;
    List<GameObject> soulList = new List<GameObject>();
    public int souls
    {
        get { return _soulsCollected; }

        set { _soulsCollected = value;  }
    }
    int _maxSoulsToWin;


    public int maxSoulsToWin
    {
        get { return _maxSoulsToWin; }

    }
       
    
    // Start is called before the first frame update
    void Start()
    {
        soulList.AddRange(GameObject.FindGameObjectsWithTag("Soul"));

        _maxSoulsToWin = (soulList.Count/ 2);
        Debug.Log(_maxSoulsToWin);

        SetSoulsCollected(_soulsCollected);
    }
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }

    public void SetSoulsCollected(int souls){
        soulCounter.SetText("Souls: " + _soulsCollected.ToString());
    }

}
