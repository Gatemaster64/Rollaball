using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // This will set offset equal to the camera transform position.
        offset = transform.position - player.transform.position;   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // aligning the camera position withe player position.
        transform.position = player.transform.position + offset;  
    }
}
