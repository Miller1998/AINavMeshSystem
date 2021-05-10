using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    private Vector3 mousePosition;

    public Camera cam;

    [SerializeField]
    private NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            MouseOnClickPosition();
        }

    }


    void MouseOnClickPosition()
    {
        mousePosition = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //Character will go to the mouse on click position
            agent.SetDestination(hit.point);
        }

    }

}
