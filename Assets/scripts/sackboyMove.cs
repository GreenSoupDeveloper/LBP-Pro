using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class characterControler : MonoBehaviour
{
    CharacterController characterController;

    public float walkSpeed = 6.0f;
    public float runSpeed = 10.0f;
    public float jumSpeed = 8.0f;
    public float gravity = 20.0f;
    public int layer = 0;
    public int layerMulti = 0;
    public float layerDetail = 0;
    public Camera cam;
    public GameObject SackBoy;
    float h_mouse, v_mouse;
    public Vector3 move = Vector3.zero;
    private Vector3 zLayers;
    private Quaternion SackRotation;

    public BoxCollider layerNorthStatus;
    public BoxCollider layerSouthStatus;
    public AudioSource audio;
    public AudioClip pluh;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
     
        zLayers = new Vector3(this.transform.position.x, this.transform.position.y, layerMulti);
        this.transform.position = zLayers;
    }
    void Update()
    {

      
        if (characterController.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f);
            if (Input.GetKey(KeyCode.LeftShift))
                move = transform.TransformDirection(move) * runSpeed;
            else
                move = transform.TransformDirection(move) * walkSpeed;
            if (Input.GetKey(KeyCode.Space))
                move.y = jumSpeed;

            if (Input.GetKeyDown(KeyCode.W) && layer < 2)
            {
                layerDetail = 0.125f;
                layer += 1;
                move.y = 5.5f;
            }
          
            if (Input.GetKeyDown(KeyCode.S) && layer > -2)
            {
                layerDetail = -0.125f;
                layer -= 1;
                move.y = 5.5f;

            }
        }
        move.y -= gravity * Time.deltaTime;
        characterController.Move(move * Time.deltaTime);

      
            if (this.transform.position.z != layerMulti)
            {
                zLayers = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + layerDetail);
                this.transform.position = zLayers;
            }
     

        //SackBoy.transform.Rotate(SackBoy.transform.rotation.x, 10, SackBoy.transform.rotation.z, 0);


        layerMulti = layer + layer;
      
    }
    public void mobileJump()
    {
        if (characterController.isGrounded)
        {
            move.y = jumSpeed;
            move.y -= gravity * Time.deltaTime;
            characterController.Move(move * Time.deltaTime);
        }
    }
    public void w()
    {
        if (characterController.isGrounded)
        {
            if (layer < 2)
            {


                layerDetail = 0.125f;
                layer += 1;
                move.y = 5.5f;
                move.y -= gravity * Time.deltaTime;
                characterController.Move(move * Time.deltaTime);
            }
        }

    }
    public void s()
    {
        if (characterController.isGrounded)
        {
            if (layer > -2)
            {


                layerDetail = -0.125f;
                layer -= 1;
                move.y = 5.5f;
                move.y -= gravity * Time.deltaTime;
                characterController.Move(move * Time.deltaTime);
            }
        }

    }
    public void left()
    {
        if (characterController.isGrounded)
        {
            move = new Vector3(-6, 0.0f);
            move.y -= gravity * Time.deltaTime;
            characterController.Move(move * Time.deltaTime);

        }

    }
    public void right()
    {
        if (characterController.isGrounded)
        {
            move = new Vector3(6, 0.0f);
            move.y -= gravity * Time.deltaTime;
            characterController.Move(move * Time.deltaTime);
        }

    }
    void OnTriggerEnter(Collider collision)
    {
        if (layerNorthStatus.tag == "Wall")
        {
            audio.PlayOneShot(pluh);
        }
    }
}