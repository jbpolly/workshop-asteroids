using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    public Text scoreText;

    public static int score = 0;
   

    void Update() {
        scoreText.text = "Score: " + score;
    }



}
