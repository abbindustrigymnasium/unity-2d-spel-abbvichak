using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopWatch : MonoBehaviour
{
    public float timeStart;
    [SerializeField] private TextMeshProUGUI textBox;

    bool timerActive = false;

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
    }
    public void timerButton()
    {
        timerActive = !timerActive;
    }
}

