using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float startTime;
    public Text winText;
    private bool isZero = false;
    public Text countText;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (isZero)
            return;

        float t = Time.time - startTime; // time elapsed since timer started in seconds
        float time = 30;
        t = time - t;
        float colorTime = 30 - (t % 60);
        string seconds = (t % 60).ToString("f1");
        string count = countText.text;
        float squareCount = float.Parse(count.Remove(0, 7));
        Color redScale = new Color(0,0,0);
        
        if ((squareCount * 1.875) > t)
        {
            redScale.r = 0;
            redScale.g = 0;
            redScale.b = colorTime * (float)0.03;
        }
        else
        {
            redScale.r = colorTime * (float)0.03;
            redScale.g = 0;
            redScale.b = 0;
        }
        timerText.text = seconds;
        timerText.color = redScale;
        if (t <= 0 || winText.text != "")
        {
            if (winText.text == "")
            {
                winText.text = "You Lose!";
                timerText.color = Color.red;
            }
            else if (winText.text == "You Win!")
                timerText.color = Color.blue;
            isZero = true;
            
        }
	}

}
