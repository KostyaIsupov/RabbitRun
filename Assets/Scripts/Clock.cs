using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    private int seconds;
    private int minutes;
    public Text clockText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Timer");
        seconds = 0;
        minutes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Timer()
    {
        while (true)
        {
            seconds++;
            if (seconds >= 60)
            {
                seconds = 0;
                minutes++;
            }
            clockText.text = minutes.ToString() + ":" + seconds.ToString();
            yield return new WaitForSeconds(1);
        }
    }    
}
