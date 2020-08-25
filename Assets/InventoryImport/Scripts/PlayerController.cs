//using UnityEngine.EventSystems;
using UnityEngine;
//https://www.youtube.com/watch?v=S2mK6KFdv0I&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=2

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;

    public LayerMask movementMask;

    Camera cam;
    //PlayerMotor motor;

    
    void Start()
    {
        cam = Camera.main;
        //motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //if (EventSystem.current.IsPointerOverGameObject())
        //{
            //return;
        //}

        if (Input.GetMouseButtonDown(0)) //Left mouse
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                Debug.Log ("We hit " + hit.collider.name + " " + hit.point);

                //motor.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1)) //Right mouse
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log ("We hit " + hit.collider.name + " " + hit.point);

                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus (Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            //motor.FollowTarget(newFocus);
        }
        
        newFocus.OnFocused(transform);
    }

    void RemoveFocus ()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        //motor.StopfollowingTarget();
    }
}
