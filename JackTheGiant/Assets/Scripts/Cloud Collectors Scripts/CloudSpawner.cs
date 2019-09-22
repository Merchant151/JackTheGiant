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
        controlX = 0;
        SetMinAndMaxX();
        CreateClouds();
        player = GameObject.Find("Player");
        
    }

    private void Start()
    {
        PositionThePlayer();
    }

    void SetMinAndMaxX()
    {//sets x axis bounds
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 1f;
        minX = -bounds.x + 1f;
        //Debug.Log("maxX = " + maxX + "minX = " + minX);
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
                temp.x = Random.Range(0.0f, maxX);
                controlX = 1;
                //Debug.Log("controlX = " + controlX);
            }
            else if (controlX == 1)
            {
                temp.x = Random.Range(0.0f, minX);
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

    void PositionThePlayer()
    {
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");

        for(int i = 0; i < darkClouds.Length; i++)
        {

            if(darkClouds[i].transform.position.y == 0f)
            {
                Vector3 t = darkClouds[i].transform.position;
                darkClouds[i].transform.position = new Vector3(cloudsInGame[0].transform.position.x,
                                                               cloudsInGame[0].transform.position.y, 
                                                               cloudsInGame[0].transform.position.z);
                cloudsInGame[0].transform.position = t;
            }

            
        }

        Vector3 temp = cloudsInGame[0].transform.position;

        for(int i = 1; i < cloudsInGame.Length; i++)
        {
            if(temp.y < cloudsInGame[i].transform.position.y)
            {
                temp = cloudsInGame[i].transform.position;
            }
        }

        temp.y += 0.8f;

        player.transform.position = temp;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
