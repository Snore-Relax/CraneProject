using UnityEngine;
using UnityEngine.Events;

// https://www.youtube.com/watch?v=lPPa9y_czlE

// https://www.youtube.com/watch?v=Ei8OupB7ZoU

// https://www.youtube.com/watch?v=Rntchol6SFM

// https://www.youtube.com/watch?v=fhvIvlNfBRA


public class RotateArm : MonoBehaviour
{
   [SerializeField] float speed; //10
   //[SerializeField] private GameObject craneBody;
   [SerializeField] private Transform clockwiseTarget;
   [SerializeField] private Transform counterClockwiseTarget;
   public UnityEvent onPressed, onReleased;

   float rotate = 0;

   private void Update()
   {
      if (rotate == 1)
      {
         Debug.Log("Pressed 1");
         Rotate(counterClockwiseTarget);
      }
      else if (rotate == -1)
      {
         Debug.Log("Pressed -1");
         Rotate(clockwiseTarget);
      }
      //onPressed.Invoke();
   }

   void Rotate(Transform target)
   {
      // Determine which direction to rotate towards
         Vector3 targetDirection = target.position - transform.position;

         // The step size is equal to speed times frame time.
         float singleStep = speed * Time.deltaTime;

         // Rotate the forward vector towards the target direction by one step
         Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

         // Draw a ray pointing at our target in
         Debug.DrawRay(transform.position, newDirection, Color.red);

         // Calculate a rotation a step closer to the target and applies rotation to this object
         transform.rotation = Quaternion.LookRotation(newDirection);
   }

   public void RotateClockwise()
   {
      rotate = 1;
   }
   public void RotateCounterClockwise()
   {
      rotate = -1;
   }
}