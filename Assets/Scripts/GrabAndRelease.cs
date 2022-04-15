using UnityEngine;

public class GrabAndRelease : MonoBehaviour
{
    [SerializeField] GameObject package;
    public GameObject hook;
    UpAndDown hookUpAndDown;
    bool connected;

    void Awake()
    {
        hookUpAndDown = package.GetComponent<UpAndDown>();
    }

    void Update()
    {
        if(connected == true)
        {
            package.transform.parent = hook.transform;
            package.GetComponent<Rigidbody>().isKinematic = true;
        }

        else
        {
            package.transform.parent = null;
            package.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public void Grab()
    {
        Debug.Log("Connected");
        connected = true;
        
    }
   void Release()
   {
        Debug.Log("Un-Connected");
        
   }


}
