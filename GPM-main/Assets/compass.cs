using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

//using static System.Net.Mime.MediaTypeNames;

public class compass : MonoBehaviour
{
    public int comp_num;
    public Text dir;
    /*public Text staus;
    public Text walk;
    public Text ans1;
    public Text s1;
    public Text s2;*/
    // public geolocation latiude;
    public geolocation locmo;
  //  public calculate cal;
  //  public Text loop;
    public Text shake;
    int f = 0;
    //private string[] scores;
    // Start is called before the first frame update
    float sp = 5.0f;
    float accelerometerUpdateInterval = 1.0f / 60.0f;
    // The greater the value of LowPassKernelWidthInSeconds, the slower the
    // filtered value will converge towards current input sample (and vice versa).
    float lowPassKernelWidthInSeconds = 1.0f;
    // This next parameter is initialized to 2.0 per Apple's recommendation,
    // or at least according to Brady! ;)
    float shakeDetectionThreshold = 2.0f;

    private CharacterController controller;

    float lowPassFilterFactor;
    Vector3 lowPassValue;
    void Start()
    {
        Input.compass.enabled = true;
        Input.location.Start();
        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration;
        controller = gameObject.AddComponent<CharacterController>();


        // Debug.Log("Update:mejara"+up);
    }
    public void rot(string value)
    {

    }

    // Update is called once per frame
    private Vector3 _rotation;
    [SerializeField] private float speed;

    int up = 0;
    float locationinitial = 0, temp = 0, newloc = 0;
    float walk1 = 0;
    private string fileName;

    float timer = 0.0f;

    int n;
    public void OnButtonPress()
    {
        n++;
        Debug.Log("Button clicked " + n + " times.");
    }
    //float a[10];
    private float playerSpeed = 2.0f;
   
    void Update()
    {
        // Debug.Log(cal.calg);


        //temp = locmo.regain;
        ///   walk1 = temp;



        up = up + 1;


        // Debug.Log("Update FLAG==" + up);
        transform.rotation = Quaternion.Euler(0, -Input.compass.trueHeading, 0);
        transform.rotation = Quaternion.Euler(0, -Input.compass.magneticHeading, 0);
        string str = transform.rotation.ToString();
        string str11 = Input.compass.trueHeading.ToString();


        comp_num =(int) Input.compass.trueHeading;
    dir.text = comp_num.ToString();
        // if ((str11 == "0")&&(comp_num==0))
        int c = (int)comp_num;
    c = 0;
        Vector3 angles = transform.eulerAngles;
    float y = angles.y + c;

    //  Debug.Log("Text: (RADHA ... on loop)");
      transform.rotation = Quaternion.AngleAxis(y, Vector3.down);

        
       // temp = locmo.ans;
       // loop.text = temp.ToString();
     




        //shake

        
    }

        
}
