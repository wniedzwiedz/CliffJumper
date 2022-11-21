using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private float timeRemaining = 1;
    public GameObject Cliff;
    public GameObject CliffLong;
    public GameObject CliffShort;
    public GameObject CliffObstacle;
    public GameObject Coin;
    private Vector3 position;
    private Vector3 positionLong;
    private Vector3 positionShort;
    private Vector3 positionCoin;
    private float time;
    private float timeShort;
    private float timeLong;
    private float random;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
        position = new Vector3(0,0,0);
        position.y = -cam.orthographicSize;

        position.x = 10+(Cliff.transform.localScale.x * Cliff.GetComponent<BoxCollider2D>().size.x)/2;
        position.z = 0;
        time = (Cliff.transform.localScale.x * Cliff.GetComponent<BoxCollider2D>().size.x)/Cliff.GetComponent<Cliff>().speed;
        

        positionLong = position;
        positionLong.x = 10+(CliffLong.transform.localScale.x * CliffLong.GetComponent<BoxCollider2D>().size.x)/2;
        timeLong = (CliffLong.transform.localScale.x * CliffLong.GetComponent<BoxCollider2D>().size.x)/Cliff.GetComponent<Cliff>().speed;
        positionLong.y += cam.orthographicSize/10;

        positionShort = position;
        positionShort.x = 10+(CliffShort.transform.localScale.x * CliffShort.GetComponent<BoxCollider2D>().size.x)/2;
        timeShort = (CliffShort.transform.localScale.x * CliffShort.GetComponent<BoxCollider2D>().size.x)/Cliff.GetComponent<Cliff>().speed;
        positionShort.y += cam.orthographicSize/5;

        Instantiate(CliffLong, new Vector3(0, -cam.orthographicSize, 0), transform.rotation);
    }

    void Spawn()
    {
        random = Random.Range(0, 4);
        switch(random) 
        {
            case 0:
                Instantiate(Cliff, position, transform.rotation);
                positionCoin = position;
                timeRemaining=time;
                break;
            case 1:
                Instantiate(CliffLong, positionLong, transform.rotation);
                positionCoin = positionLong;
                timeRemaining=timeLong;
                break;
            case 2:
                Instantiate(CliffShort, positionShort, transform.rotation);
                positionCoin = positionShort;
                timeRemaining=timeShort;
                break;
            case 3:
                Instantiate(CliffObstacle, positionLong, transform.rotation);
                positionCoin = positionLong;
                positionCoin.y+=cam.orthographicSize/5;
                timeRemaining=timeLong;
                break;
        }

        //spawn a coin sometimes
        random = Random.Range(0, 5);
        if (random==1){
            positionCoin.y+=0.5f*(Coin.GetComponent<BoxCollider2D>().size.y+Cliff.transform.localScale.y * Cliff.GetComponent<BoxCollider2D>().size.y);
            Instantiate(Coin, positionCoin, transform.rotation);
        }
        
        
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else {
            Spawn();
            random = Random.Range(1, 3);
            timeRemaining += random/2;
        }
        
    }
}
