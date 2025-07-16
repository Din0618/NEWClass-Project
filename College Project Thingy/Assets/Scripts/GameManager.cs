using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro; 
public class GameManager : MonoBehaviour
{
    [Header("Game Variables")]
    public PlayerController player;
    public float time; 
    public bool timeaCTIVE;

    [Header("Game UI")]
    public TMP_Text gameUI_score;
    public TMP_Text gameUI_health;
    public TMP_Text gameUI_time;

    [Header("Screens")]
    public GameObject countdownUI;
    public GameObject gameUI;
    public GameObject endUI;
   

    [Header("End Screen UI")]
    public TMP_Text endUI_score;
    public TMP_Text endUI_time;


    [Header("CountDownUI")]
    public TMP_Text CountDownText;
    public int CountDown;


    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("lil dude").GetComponent<PlayerController>();
   
      //make sure the timer is set to zero
      time = 0;

      //disable player movement initally
      player.enabled = false;
      SetScreen(countdownUI);

      

      // start coroutine 
      StartCoroutine(CountDownRoutine());

      startGame();
    }
    public void OneRestartButton()
    {
        //restart the game scene to play the game again
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        // keep track of the time that goes by 
        if(timeaCTIVE)
        {
            time = time + Time.deltaTime;
        }
            //set the UI to display stats
            gameUI_score.text = "Coins: " + player.coinCount; 
            gameUI_health.text = "Health: " + player.health;
            gameUI_time.text = "Time: " + (time * 10). ToString("F2");
    }  


    
    void startGame() {
        // set the screem to see your stats
        SetScreen(gameUI);

        //start the timer 
        timeaCTIVE = true;
    }

    public void endGame() {
        //start the timer 
        timeaCTIVE = false;

        //disbale player movement    
        player.enabled = false;
      
        //set the UI to display your stats
       endUI_score.text = "Score: " + player.coinCount;
       endUI_time.text = "Time: " + (time * 10).ToString("F2");
       SetScreen(endUI); 
    }   

    IEnumerator CountDownRoutine()
    {   CountDownText.gameObject.SetActive(true);
        CountDown = 3;
        while (CountDown > 0)
        {   
            CountDownText.text = CountDown.ToString();
            yield return new WaitForSeconds(1f);
            CountDown--;
        }

        CountDownText.text = "GO!";
        yield return new WaitForSeconds(1f);

        //emable player movement
        player.enabled = true;
        
        //start the Game
        startGame();
    }   
     
    public void SetScreen(GameObject screen)
    {  countdownUI.SetActive(false);
       endUI.SetActive(false);
       gameUI.SetActive(false);
       
       //actovate the request screen
       screen.SetActive(true);
    }
}
     
   


    
  
