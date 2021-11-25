using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoulBehavior : MonoBehaviour
{
    PlayerBehavior player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            player.canCollect = true;
            player.soul = this.gameObject;
            FindObjectOfType<AudioManager>().Play("SoulSound");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            player.canCollect = false;
            player.soul = null;
        }
    }
    
}
