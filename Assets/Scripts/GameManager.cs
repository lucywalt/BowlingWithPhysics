using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] fallTriggers;

    private GameObject pinObjects;

    //A reference to our ball controller
    [SerializeField] private BallController ball;

    //A reference to our pincollection prefab
    [SerializeField] private GameObject pinCollection;

    //a reference for empty game object to spawn pin collection prefab
    [SerializeField] private Transform pinAnchor;

    //A reference to our input manager
    [SerializeField] private InputManager inputManager;

    void Start()
    {
        //fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        //foreach (FallTrigger pin in fallTriggers)
        //{
        //    pin.OnPinFall.AddListener(IncrementScore);
        //}

        //adding handlerest function as listener to new event
        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();

        
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }

    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }

    private void SetPins()
    {
        //first check that all prev pins have been destroyed so we dont create more on top

        if (pinObjects)
        {
            foreach (Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }

        //then instantiate new set of pins to our pin anchor transform
        pinObjects = Instantiate(pinCollection, pinAnchor.transform.position, Quaternion.identity, transform);

        //we add increment score function as listener to the onpinfall event
        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
