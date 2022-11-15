using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopWatch : MonoBehaviour
{
    public float timeStart { get; private set; }
    [SerializeField] private TextMeshProUGUI textBox;

    public bool timerActive { get;  set; } 
    public float timeScore { get; set; }

    void Start()
    {
        textBox.text = timeStart.ToString("F2");
        timerActive = true;
    }

    void Update()
    {
        if (timerActive)
        {
            timeStart += Time.deltaTime;
            textBox.text = timeStart.ToString("F2");
        }
        else
        {
            Debug.Log(timeStart);
        }
    }
    public void StopTimer() 
    {
        timerActive = false;
        timeScore = timeStart;
    }

}

