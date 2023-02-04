using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class geolocation : MonoBehaviour
{
    public static geolocation instance;
    [SerializeField]
    public Text GpsStatus;
    public Text latitudeValue;
    public Text longitudeValue; 
    public Text altitudeValue;
    public Text horizontalAccuracyValue;
    public Text timeStampValue;
    public Text Timer;
    double regain1;
    public double regain;
    public Text walk;
    public Text ans1;
    public Text s1;
    public Text s2;
   // public geolocation latiude;
    public geolocation locmo;
    public Text prev_latitude;
    public Text diff_latitude;
    public Text prev_longitude;
    public Text diff_longitude;
    public float temp1;
    public Text oldloc;
    //public Text loop;

    public Text ans5;

    private void Awake()
    {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        GpsStatus.text = "Started";

        Input.location.Start();
        latitudeValue.text = Input.location.lastData.latitude.ToString();
        StartCoroutine(GPSloc());

    }



    IEnumerator GPSloc()
    {
        Timer.text = "Something";
        if (!Input.location.isEnabledByUser)
            yield break;


        int maxWait = 20;

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            // Timer.text = maxWait.ToString();
            yield return new WaitForSeconds(1);
            maxWait--;
            regain1 = Input.location.lastData.latitude;
        }

        if (maxWait < 1)
        {
            GpsStatus.text = "Time out";
            yield break;

        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            GpsStatus.text = "Unable to connect to device";
            yield break;

        }

        //GpsStatus.text = "Running";
        InvokeRepeating("UpdateGpsData", 0f, 0.03f);
        //access granted
    }

    private Vector3 dir;
    string prev;


    float locationinitial = 0, temp = 0, newloc = 0;
   
    int flag = 0, up = 0;
    // public float regain1 = 0, ans = 0;
    public float ans = 0;
    float[] a = new float[10];
    double r,r1;
    public double diffrence, diffrence1;
    public void UpdateGpsData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            if (regain != Input.location.lastData.latitude)
            {
                double f = regain;
                double f1 = regain1;
                prev_latitude.text = f.ToString();
                prev_longitude.text = f1.ToString();
               

                //ans5.text = r.ToString();
                r = Input.location.lastData.latitude;
                r1 = Input.location.lastData.longitude;
                // latitudeValue.text = Input.location.lastData.latitude.ToString();
                //longitudeValue.text = Input.location.lastData.longitude.ToString();
                latitudeValue.text = r.ToString();
                longitudeValue.text = r1.ToString();
                 diffrence1 = r1 - regain1;
                 diffrence = r - regain;
                //  diffrence = (double)Math.Round(diffrence, 6);
                
                diff_latitude.text = diffrence.ToString("0.000000000");
                diff_longitude.text = diffrence1.ToString("0.000000000");
            }
            GpsStatus.text = "Running";
            
            
            longitudeValue.text = Input.location.lastData.longitude.ToString();
            altitudeValue.text = Input.location.lastData.altitude.ToString();
            horizontalAccuracyValue.text = Input.location.lastData.horizontalAccuracy.ToString();
            //  timeStampValue.text = Input.location.lastData.timestamp.ToString();
            regain = Input.location.lastData.latitude;
            regain1= Input.location.lastData.longitude;
            // ans = regain1 - regain;
            timeStampValue.text = ans.ToString();
          //  ans3.text = regain1.ToString();
           // ans4.text = regain.ToString();
            float amountToMove = Time.deltaTime;
            transform.Translate(dir * amountToMove);
           // dir = Vector3.forward;           //waalking




        }
        else
        {
            GpsStatus.text = "Stop";
        }
    }

}


