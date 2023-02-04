using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(PhysicsController))]
public class ShakeDetector : MonoBehaviour
{

    public float ShakeDetectionThreshold;
    public float MinShakeInterval;
    public geolocation locmo;
    private float sqrShakeDetectionThreshold;
    private float timeSinceLastShake;
   // public Text backstep;
    //public Text backstep1;
    public Text shake;
    public Text newshake; //trail
    public Text newshake1;//trail
    public Text answers;
   public int sh = 0;
    public int step_diff = 0;
    int rat = 0;
    //  public GameObject dishes1, dishes2, dishes3, dishes4;
    // private Text text;

    // variable to hold shaking acceleration value
    Vector3 accelerationDir;
    public Text shakevalue;
    int io = 0;
    IEnumerator Fade()
    {
        step_diff = 0;
        accelerationDir = Input.acceleration;
        shakevalue.text = accelerationDir.sqrMagnitude.ToString("0.00");

       
        int temp = io;
        if (accelerationDir.sqrMagnitude >= 1.5f)
        {
            step_diff = 0;
            temp = sh;
            sh = sh + 1;
            shake.text = sh.ToString();
            //backstep1.text = sh.ToString();
            step_diff = sh - temp;
            temp = 0;
            
            if (sh % 4 == 0)
            {
                rat = rat + 1;
                newshake1.text = sh.ToString();
                newshake.text = rat.ToString();
            }
        }
       
        io = temp;
      
       
        //backstep.text = io.ToString();
        //answers.text = temp2.ToString();



        yield return new WaitForSeconds(1.5f);
        }
    
    // Update is called once per frame
    void Update()
    {
        step_diff = 0;
        StartCoroutine(Fade());
        // Read new acceleration Input from mobile device
      
    }


}