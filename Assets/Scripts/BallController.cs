using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;

    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;

    private Rigidbody ballRB;
    private bool isBallLaunched;
    
    void Start()
    {
        //Grabbing a reference to RigidBody
        ballRB = GetComponent<Rigidbody>();

        //Add a listenr to the OnSpacePressed event
        // When the key is pressed, the LaunchBall method will be called
        //inputManager.OnSpacePressed.AddListener(LaunchBall);
        //transform.parent = ballAnchor;
        //transform.localPosition = Vector3.zero;
        //ballRB.isKinematic = true;

        Cursor.lockState = CursorLockMode.Locked;
        inputManager.OnSpacePressed.AddListener(LaunchBall);

        ResetBall();
    }

    public void ResetBall()
    {
        isBallLaunched = false;

        ballRB.isKinematic = true;
        launchIndicator.gameObject.SetActive(true);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
    }

    private void LaunchBall()
    {
        if (isBallLaunched)
            return;
        isBallLaunched = true;

        transform.parent = null;
        //this sets the object to the outermost layer of the hierarchy
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
        ballRB.isKinematic = false;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
