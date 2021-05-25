using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    private Vector3 touchPos;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Mouse.current.leftButton.isPressed)
        {
            MouseOnClickPosition();
        }
        //MouseOnClickPosition();

    }


    void MouseOnClickPosition()
    {

        //touchPos = Input.mousePosition;//if you not using new input system
        touchPos = Mouse.current.position.ReadValue();//Getting Mouse Position in screen coordinate and we can using New Input systems (you can get it from Package Manager)
        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(touchPos);//convert mouse pos on screen to ray that we can shoot out and convert it to the dir that we click
        RaycastHit rayCastHit;

        if (Physics.Raycast(ray/*ray that we want to shoot*/, 
            out rayCastHit/*information what we hit and where it hit and store it inside our rayCastHit var*/))
            //if our ray hit something not an object then we wont do anything, but if it hit object then
        {

            //Move Our Agent to the mouse point of click Position
            agent.SetDestination(rayCastHit.point);

        }

    }

}
