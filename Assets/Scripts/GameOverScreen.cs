using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour{

    public Text fastestTime;

   public void Setup(string time){
        gameObject.SetActive(true);
        //fastestTime.text = "Your fastest time was: " + time;
   }

    public void RestartButton(){
        SceneManager.LoadScene("BoatScene");
    }
}
