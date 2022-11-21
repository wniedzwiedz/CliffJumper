using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
    

{
    public GameObject Score ;

    void Start()
        {
            Score=GameObject.FindWithTag("Score");
            
        }
    void OnCollisionEnter2D(Collision2D col) {
         Destroy(gameObject);
         Score.GetComponent<Score>().addCoin();
    }
}
