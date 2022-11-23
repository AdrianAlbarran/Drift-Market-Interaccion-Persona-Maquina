using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timeLeft;
    private bool timerOn = false;

    private bool modeGame = false;

    private TextMeshProUGUI timerText;

    public void createTimer(float timeLeft)
    {
        this.timeLeft = timeLeft;
        this.timerText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        this.timerOn = true;
    }

    public void setTime(float time)
    {
        timeLeft = time;
    }

    public void setMode(bool mode)
    {
        modeGame = mode;
    }

    public void setTimer(bool t)
    {
        timerOn = t;
    }

    // Update is called once per frame
    public void Update()
    {
        if (!modeGame)
        {
            if (timerOn)
            {
                if (timeLeft > 0)
                {
                    timeLeft -= Time.deltaTime;
                    updateTimer(timeLeft);
                }
                else
                {
                    timeLeft = 0;
                    timerOn = false;
                }
            }
        }
        else
        {
            if (timerOn)
            {
                timeLeft += Time.deltaTime;
                updateTimer(timeLeft);
            }
        }
    }

    public void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00} ", minutes, seconds);
    }
}