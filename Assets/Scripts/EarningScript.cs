using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EarningScript : MonoBehaviour
{
    //public string LAST_ACCESS_TIME = "";
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        //EarningTime();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateWaitTimeUI();
    }

    public void EarningTime(string LAST_ACCESS_TIME)
    {
        string lastAccessTimeString = PlayerPrefs.GetString(LAST_ACCESS_TIME, string.Empty);

        if(string.IsNullOrEmpty(lastAccessTimeString))
        {
            
            PlayerPrefs.SetString(LAST_ACCESS_TIME, DateTime.Now.ToString());
            PlayerPrefs.Save();
        }
    }

    public void UpdateWaitTimeUI(string LAST_ACCESS_TIME)
    {
        string lastAccessTimeString = PlayerPrefs.GetString(LAST_ACCESS_TIME, string.Empty);

        if (!string.IsNullOrEmpty(lastAccessTimeString))
        {
            DateTime lastAccessTime = DateTime.Parse(lastAccessTimeString);

            TimeSpan timeGap = DateTime.Now - lastAccessTime;

            TimeSpan waitTime = TimeSpan.FromDays(1) - timeGap;

            //if (timeGap.TotalDays >= 1)
            //{
            //    Debug.Log("EARNING");
            //}
            //else
            //{
            //    Debug.Log("TUNGGU");
            //}

            if (waitTime.TotalSeconds > 0)
            {
                timeText.text = string.Format("Waktu tunggu tersisa: {0:D2}:{1:D2}:{2:D2}:{3:D2}",
                    waitTime.Days, waitTime.Hours, waitTime.Minutes, waitTime.Seconds);
            }
            else
            {
                timeText.text = "Waktu tunggu telah terpenuhi!";
                Debug.Log("Waktu tunggu telah terpenuhi. Melanjutkan proses...");
            }
        }
    }
}
