using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class rotatee : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 _rotation;
    [SerializeField] private float _speed;


    void Update()
    {
        if (Input.GetKey(KeyCode.A)) _rotation = Vector3.up;
        else if (Input.GetKey(KeyCode.D)) _rotation = Vector3.down;
        else _rotation = Vector3.zero;
        transform.Rotate(_rotation * _speed * Time.deltaTime);

    }
}
