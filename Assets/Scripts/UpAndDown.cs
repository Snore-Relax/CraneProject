using UnityEngine;
using UnityEngine.Events;

public class UpAndDown : MonoBehaviour
{
    [SerializeField] Transform targetUp;
    [SerializeField] Transform targetDown;
    [SerializeField] float speed;
    [SerializeField] Transform hook;
    public UnityEvent onPressed, onReleased;
    bool shouldMove = false;
    float moveDir = 0;

    void Update()
    {
        if (shouldMove == false)
        {
            return;
        }

        // Move our position a step closer to the target.
        float step =  speed * Time.deltaTime; // calculate distance to move

        if (moveDir == -1) //going down
        {
            hook.transform.position = Vector3.MoveTowards(hook.transform.position, targetDown.position, step);
            if (Vector3.Distance(hook.transform.position, targetDown.position) < 0.001f)
            {
                hook.transform.position = targetDown.position;
                shouldMove = false;
                moveDir = 1;
            }
        }
        else if (moveDir == 1) //going up
        {
            hook.transform.position = Vector3.MoveTowards(hook.transform.position, targetUp.position, step);
            if (Vector3.Distance(hook.transform.position, targetUp.position) < 0.001f)
            {
                hook.transform.position = targetUp.position;
                shouldMove = false;
                moveDir = -1;
            }
        }
    }

    public void MoveUp()
    {
        Debug.Log("MoveUp");
        shouldMove = true;
        moveDir = 1;
    }
    public void MoveDown()
    {
        Debug.Log("MoveDown");
        shouldMove = true;
        moveDir = -1;
    }
}