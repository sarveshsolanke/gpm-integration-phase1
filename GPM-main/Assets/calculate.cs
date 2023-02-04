using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class calculate : MonoBehaviour
{
    /*public Sprite btnUp;
    public Sprite btnDown;
    public UnityEvent buttonClick;

    void Awake()
    { if (buttonClick == null) { buttonClick = new UnityEvent(); } }

    void OnMouseDown()
    { GetComponent<SpriteRenderer>().sprite = btnDown; }

    void OnMouseUp() { print("lick"); }*/
    int n=0;
    public float calg;
    public void OnButtonPress()
    {
        n=n+1;
        calg = n;
        Debug.Log("Button clicked " + n + " times.");
        
    }
}
