using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Create private variable of type rigidbody and call it rb. This will hold a reference to the rigidbody.
    private Rigidbody rb;
    private int count;
    // Creates two variables for input directions on the X & Y Axis.
    private float movementX;
    private float movementY;


    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    // Start is called before the first frame update


    void Start()
    {
        //  Sets the value of the Var rb 
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

      // Space inside the lines is called the FunctionBody.Here you add instructions for the computer to complete. Each function has its own set of ().
    void OnMove(InputValue movementValue)
    {
        // Gets Vector 2 data from movement value and stores it in a Vector2 Variable, in this case movementVector
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);  
    }
     
     // OnTriggerEnter will be called when the player first touches a triggercollider.
     // It will give a reference to the trigger collider that has been touched.

    // Code will disable gameobjects correctly.
     private void OnTriggerEnter(Collider other)

    {
        if(other.gameObject.CompareTag("Pickup"))
        {
          other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
        
    }

}
