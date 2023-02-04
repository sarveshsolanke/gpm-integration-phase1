using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 1;

   // public geolocation geo;
    public compass comp;
    public ShakeDetector step;
    int flag = 1,flag2=1;
    int a=0,b;
    // public Text ans4;
    // public Text ass;
    //public Text bs;
    public compass c;
    public geolocation g;
    void Start()
    {
       
       
    }
    


   void Update()
    {

        if ((c.comp_num > 0 && c.comp_num < 45) || (c.comp_num > 315 && c.comp_num < 359) || (c.comp_num > 135 && c.comp_num < 225))
        {
            if ((g.diffrence != 0)&&(step.step_diff==1))
            {
                var dir = new Vector3(0, 0, 1);
                transform.Translate(dir * _speed * Time.deltaTime);
            }

        }
        else if ((c.comp_num > 45 && c.comp_num < 135) || (c.comp_num > 225 && c.comp_num < 315))
        {
            if ((g.diffrence1 != 0)&&(step.step_diff==1))
            {
                var dir = new Vector3(0, 0, 1);
                transform.Translate(dir * _speed * Time.deltaTime);
            }

        }
        else {
            var dir = new Vector3(0, 0, 0);
            transform.Translate(dir * _speed * Time.deltaTime); }
        





        //   transform.Traslate(dir*_speed)
        /* float f = comp.comp_num;
         int st = step.sh;
         if (flag == 1)
         {
             a = step.sh; 
             flag = flag + 1;
         }
         else if(flag==2)
         {
             b = step.sh;

             int ans = a - b;
             ass.text = a.ToString();
             bs.text = b.ToString();

             if (ans != 0)
             {
                 var dir = new Vector3(0, 0, 1);
                 //   transform.Traslate(dir*_speed)
                 transform.Translate(dir * _speed * Time.deltaTime);
             }
             flag = flag - 1;
         }*/




    }
}

