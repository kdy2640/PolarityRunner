using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    int PlayerSpeed = 50;
    [SerializeField]
    int PlayerJumpPower = 50;
    [SerializeField]
    float SprintMultiplier = 1.5f; 
    [SerializeField]
    float FloorDrag = 0.2f;


    [SerializeField]
    bool canJump = false;
    [SerializeField]
    bool IsSprint = false;
    GameManager manager;
    ObjectPolarity polar;
    Vector2 MoveDirection = Vector2.zero; 
    Rigidbody rigid;
    CameraController cameraController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameManager.GetInstance();
        rigid = GetComponent<Rigidbody>(); 
        cameraController = Camera.main.GetComponent<CameraController>();
        polar = GetComponent<ObjectPolarity>();
    }
    void FixedUpdate()
    {
        Vector3 velocity = rigid.linearVelocity;

        if (MoveDirection != Vector2.zero)
        {
            Vector3 camForward = Vector3.ProjectOnPlane(cameraController.transform.forward, Vector3.up).normalized;
            Vector3 camRight = Vector3.ProjectOnPlane(cameraController.transform.right, Vector3.up).normalized;

            Vector3 moveDir = camForward * MoveDirection.y + camRight * MoveDirection.x;
            moveDir.Normalize();

            Quaternion nextRot = Quaternion.LookRotation(moveDir); 

            float speed = IsSprint ? PlayerSpeed * SprintMultiplier : PlayerSpeed; 
            Vector3 targetVelocity = moveDir * speed;
            rigid.linearVelocity = new Vector3(targetVelocity.x, velocity.y, targetVelocity.z);
             
        }
        else
        { 
            Vector3 horizontalVelocity = new Vector3(velocity.x, 0, velocity.z);
            horizontalVelocity = Vector3.Lerp(horizontalVelocity, Vector3.zero, FloorDrag);

            rigid.linearVelocity = new Vector3(horizontalVelocity.x, velocity.y, horizontalVelocity.z);
             
        } 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Ground"))
        {
            canJump = true;  
        }
    }
    public void OnSprint(InputValue val)
    { 
        bool pressSprint = val.isPressed;
        float temp = val.Get<float>(); 
        if (pressSprint)
        {
            IsSprint = true;
        }
        else
        {
            IsSprint = false;
        }
    }

    public void OnMove(InputValue val)
    { 
        Vector2 vec = val.Get<Vector2>();
        if (vec != null)
        {
            MoveDirection = new Vector2(vec.x,vec.y); 
        }
    } 
    

    public void OnJump(InputValue val)
    {
        bool pressJump = val.isPressed; 
        if (canJump && pressJump)
        {
            rigid.AddForce(PlayerJumpPower * Vector3.up, ForceMode.Impulse);
            canJump = false; 
        }
    }

    public void OnChangeMode(InputValue val)
    {
        polar.ChangePolarity();
    }
    public void OnRestart(InputValue val)
    {
        manager.cube.Restart();
    }

    public void OnSkip(InputValue val)
    {
        manager.cube.NextStage();
    }
    public void OnQuit(InputValue val)
    {
        Application.Quit();
    }
}
