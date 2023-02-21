using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    public GameObject birdPrefab;
    public Vector3 move;

    public Transform bPositon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
        if(birdPrefab.transform.position.x > bPositon.transform.position.x)
        {
            return;
        }
        move = birdPrefab.transform.position;
        move.x += 1f * Time.deltaTime;
        // 1s -> 60 
        // 1s - 50 
        birdPrefab.transform.position = move;
    }
}
