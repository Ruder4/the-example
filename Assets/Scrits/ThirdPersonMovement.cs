using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed;
    [SerializeField] float currentStamina = 5f;
    [SerializeField] float burnStamina = 2f;
    [SerializeField] float replenStamina = 20f;
    [SerializeField] float delayStamina = 5f;
    [SerializeField] float maxStamina = 5f;
    public bool running = false;
    private float lastSprintTime;


    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && currentStamina > 0)
            {
                running = true;
            }
            if (running == true && currentStamina > 0)
            {
                speed = 50;
                currentStamina -= (burnStamina * Time.deltaTime);
                lastSprintTime = Time.time;
                if (currentStamina < 0)
                {
                    currentStamina = 0;
                    running = false;
                }
            }
            else
            {
                speed = 25;
                if (Time.time > lastSprintTime + delayStamina)
                {
                    if (currentStamina < maxStamina) currentStamina += (replenStamina * Time.deltaTime);
                }
            }

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }


    }
}