using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AstronautScript : MonoBehaviour
{
    private Transform _transform;

    [Header("Movement")]
    public float x;
    public float z;
    public CharacterController controller;
    public float airMovement;

    [Header("Camera")]
    public float sensX;
    public float sensY;
    public Camera cam;

    float xRotate;
    float yRotate;

    [Header("Physics")]
    public float gravity;
    public float y;
    public float y2;
    public float control;
    Vector3 velocity;

    [Header("Grounding")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Health")]
    public int maxHealth;
    private int currentHealth;
    public HealthBar healthBar;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
      
        currentHealth = maxHealth;
        healthBar.MaxHealth(maxHealth);

        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        float time = Time.deltaTime;

        float mousex = Input.GetAxis("Mouse X") * time * sensX;
        float mousey = Input.GetAxis("Mouse Y") * time * sensY;
        yRotate += mousex;
        xRotate -= mousey;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);
        transform.rotation = Quaternion.Euler(0, yRotate, 0);

        Vector3 move = new Vector3(x * Input.GetAxis("Horizontal")*time, 0, z * Input.GetAxis("Vertical")*time);
        if (grounded)
        controller.Move(transform.TransformDirection(move));

        else if(!grounded)
        controller.Move(transform.TransformDirection(move) * airMovement);
                
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            velocity.y += Mathf.Sqrt(y * control * y2);
        }

        velocity.y += -gravity * time;
        controller.Move(velocity * time);

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Alien"))
        {
            Damage(1);
        }
    }
    void Damage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
