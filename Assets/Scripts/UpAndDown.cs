using UnityEngine;
using UnityEngine.Events;

public class UpAndDown : MonoBehaviour
{
    [SerializeField] Transform targetUp;
    [SerializeField] Transform targetDown;
    [SerializeField] float speed;
    //[SerializeField] Transform hook;
    //public UnityEvent onPressedDown, onPressedDownUp;
    [HideInInspector] public bool shouldMove = false;
    [HideInInspector] public float moveDir = 0; //-1 goes down, +1 goes up
    float step;

    void Update()
    {
        if (shouldMove == false)
        {
            return;
        }
        //Debug.Log("timeDeltaTime " + Time.deltaTime);
        step =  speed * Time.deltaTime; // calculate distance to move

        if (moveDir == -1) //going down
        {
            //Debug.Log("Update Down");
            transform.position = Vector3.MoveTowards(transform.position, targetDown.position, step);
            if (Vector3.Distance(transform.position, targetDown.position) < 0.001f)
            {
                transform.position = targetDown.position;
                shouldMove = false;
            }
        }
        else if (moveDir == 1) //going up
        {
            //Debug.Log("Update Up");
            transform.position = Vector3.MoveTowards(transform.position, targetUp.position, step);
            if (Vector3.Distance(transform.position, targetUp.position) < 0.001f)
            {
                transform.position = targetUp.position;
                shouldMove = false;
            }
        }
    }
}