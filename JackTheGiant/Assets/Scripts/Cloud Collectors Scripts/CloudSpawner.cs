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
    void Awake()
    {
        SetMinAndMaxX();
        CreateClouds();
    }

    void SetMinAndMaxX()
    {//sets x axis bounds
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 1f;
        minX = -bounds.x + 1.1f;
        Debug.Log("maxX = " + maxX + "minX = " + minX);
    }
    void Shuffle(GameObject[] arrayToShuffle)
    {
        for (int i = 0; i < arrayToShuffle.Length; i++)
        {
            GameObject temp = arrayToShuffle[i];
            int random = Random.Range(i, arrayToShuffle.Length);
            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temp;
        }

    }
    void CreateClouds()
    {
        Shuffle(clouds);

        float positionY = 0f;
        
        for(int i = 0; i < clouds.Length;i++)
        {
            Vector3 temp = clouds[i].transform.position;
            temp.y = positionY;

            //spawns clouds in starcase fassion
            if (controlX == 0)
            {
                temp.x = Random.Range(0.0f, 1f);
                controlX = 1;
                //Debug.Log("controlX = " + controlX);
            }
            else if (controlX == 1)
            {
                temp.x = Random.Range(0.0f, -1f);
                controlX = 2;
                //Debug.Log("controlX = " + controlX);
            }
            else if (controlX == 2)
            {
                temp.x = Random.Range(1.0f, maxX);
                controlX = 3;
                //Debug.Log("controlX = " + controlX);
            }
            else if (controlX == 3)
            {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;
                //Debug.Log("controlX = " + controlX);
            }
            temp.x = Random.Range(minX, maxX);
            lastCloudPostionY = positionY;
            clouds[i].transform.position = temp;
            positionY -= distanceBetween;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
