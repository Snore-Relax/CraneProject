using UnityEngine;

public class MoveVertically : MonoBehaviour
{
    [SerializeField] GameObject hook;
    UpAndDown hookUpAndDown;

    void Awake()
    {
        hookUpAndDown = hook.GetComponent<UpAndDown>();
    }
    public void MoveDown()
    {
        Debug.Log("Down");
        hookUpAndDown.moveDir = -1;
        hookUpAndDown.shouldMove = true;
    }
    public void MoveUp()
    {
        Debug.Log("Up");
        hookUpAndDown.moveDir = +1;
        hookUpAndDown.shouldMove = true;
    }
}
