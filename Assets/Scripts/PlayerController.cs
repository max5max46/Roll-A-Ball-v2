using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public bool IsAllBlocksGone = false;
    public bool HasSpeed = false;

    public GameObject Fist;
    private Vector3 currentDirection;
    private Vector3 currentPosition;
    private Vector3 previousPosition;

    public float speed = 10;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
        Fist.SetActive(false);
    }
    void Update()
    {
        previousPosition = currentPosition;
        currentPosition = transform.position;
        if ((currentPosition - previousPosition).normalized != new Vector3 (0.0f, 0.0f, 0.0f)) { currentDirection = (currentPosition - previousPosition).normalized; }
        Fist.transform.position = transform.position + currentDirection;

        if (Input.GetKey("space") && HasSpeed == true) { speed = 20; }
        else{ speed = 10; }
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    public void SetCountText()
    {
        countText.text = "Cubes Collected: " + count.ToString() + "/34";
        if(count >= 34 && IsAllBlocksGone == true) 
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Void"))
        {
            transform.position = new Vector3(-36.07f, 0.5f, 0.0f);
        }
    }
}
