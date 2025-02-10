using UnityEngine;

public class Gutter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter(Collider triggeredBody)
    {
        //First get the rigidbody of the ball and store it in a local variable ballRigidBody
        Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();

        //Then we stire the velocity magnitute before resetting the velocity
        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

        //It is important that we reset the linear AND angular velocity
        //This is because the ball is rotating on the ground when moving

        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        //Now we must add force in the forward direction of the gutter
        //We use the cached velocity magnitude to keep it a little realistic. 
        ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
