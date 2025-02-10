using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;

    private Rigidbody rb;
    
    
    private void Start()
    {
        //adding MovePlater as a listener to the OnMove event
        inputManager.OnMove.AddListener(MovePlayer);

        rb = GetComponent<Rigidbody>();
    }

    //listen to left and right inputs

    private void MovePlayer(Vector2 direction)
    {
        Vector3 moveDirection = new(direction.x, 0f, direction.y);
        rb.AddForce(speed * moveDirection);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
