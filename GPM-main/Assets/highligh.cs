using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine;
[RequireComponent(typeof(LineRenderer))]

public class highligh : MonoBehaviour
{
    public Camera cam;
    public Text rat;
    public UnityEngine.AI.NavMeshAgent agent;
    public UnityEngine.AI.NavMeshAgent myNavMeshAgent;
    public LineRenderer myLineRenderer;
    // Update is called once per frame

    void start()
    {
        myLineRenderer = GetComponent<LineRenderer>();

        myLineRenderer.startWidth = 0.15f;
        myLineRenderer.endWidth = 0.15f;
        myLineRenderer.positionCount = 0;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        else if (myNavMeshAgent.hasPath)
        {
            DrawPath();
        }

    }

    void DrawPath()
    {
        myLineRenderer.positionCount = myNavMeshAgent.path.corners.Length;
        myLineRenderer.SetPosition(0, transform.position);

        if (myNavMeshAgent.path.corners.Length < 2)
        {
            return;
        }

        for (int i = 1; i < myNavMeshAgent.path.corners.Length; i++)
        {
             Vector3 pointPosition = new Vector3(myNavMeshAgent.path.corners[i].x, myNavMeshAgent.path.corners[i].y, myNavMeshAgent.path.corners[i].z);
            //Vector3 pointPosition = new Vector3(17.8f,0.7f,-10.2f);
            rat.text = pointPosition.ToString();
            myLineRenderer.SetPosition(i, pointPosition);
        }
    }

}
