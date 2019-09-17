using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] clouds;

    private float distanceBetween = 3f;

    private float minX, maxX;

    private float controlX;

    private float lastCloudPostionY;

    private GameObject player;

    [SerializeField]
    private GameObject[] collectables;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
