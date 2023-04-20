using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour{

    [SerializeField] public Text fastestTime = null;
    [SerializeField] public Button restartButton = null;

   public void Setup(string time){
        gameObject.SetActive(true);
        
        if(fastestTime != null)
            fastestTime.text = "Your fastest time was: " + time;
   }

   public void RestartGame(){
        Debug.Log("Clicked");
        SceneManager.LoadScene("BoatScene");
    }

}
