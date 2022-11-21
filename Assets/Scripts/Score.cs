using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float timer = 0.0f;
    public int score = 0;
    public int coins = 0;
    public Text scoreText;
    

    // Start is called before the first frame update
    void Start()
    {
        score=0;
        coins = 0;
        scoreText = this.GetComponent<Text>();
    }

    public void addCoin(){
        coins++;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (score != (int)timer && score%25==0){
            Time.timeScale += 0.1f;
        }
        score = (int)timer;
        scoreText.text = "Score: "+ score.ToString() +"\nCoins: "+coins.ToString();
        
        
    }
}
