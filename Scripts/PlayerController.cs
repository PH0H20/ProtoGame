using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI CountText;
    public GameObject WinTextObject;

    private Rigidbody RB;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        WinTextObject.SetActive(false);
    }

    void OnMove(InputValue MovementValue)
    {
        Vector2 MovementVector = MovementValue.Get<Vector2>();
        movementX = MovementVector.x;
        movementY = MovementVector.y;
    }

    void SetCountText()
    {
        CountText.text = "count: " + count.ToString();
        if(count >= 13)
        {
            WinTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        RB.AddForce(movement);
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
       

    }
}
