using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private int desiredLane=1;//0: left, 1:middle, 2:right
    public float laneDistance;//Şeritler arası mesafe//Yolu genişletmek istenirse burdan değer verilir.
    public float jumpForce;
    public float gravity = -20;
    


    void Start()
    {
     
        controller = GetComponent<CharacterController>();
    }

   
    // Update is called once per frame
    void Update()
    {
        //Playerımıza Z eksenindeki hareketine hız veriyoruz.
         direction.z = forwardSpeed;
         

        //Playerin başlangıç konumunu belirliyoruz.
        //Player ın y ve z konumunu sabitliyoruz.
        //Burada da Playerın X konumunu sabitliyoruz.--> "private int splitRoadLine=1;//0: left, 1:middle, 2:right"

         Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

          if (desiredLane == 0)
          {
              targetPosition += Vector3.left * laneDistance;

          }
          else if (desiredLane == 2)
          {
              targetPosition += Vector3.right * laneDistance;
          }

          transform.position = targetPosition;
        //Hareketleri biraz daha yumuşatmak için
        // transform.position = Vector3.Lerp(transform.position, targetPosition, 50 * Time.deltaTime);
        //       serit_0  serit_1  serit_3
        //      |       |        |        |
        //      |       |        |        |
        //      |       |        |        |
        // -1       0       1        2       3

        //Klavye yön tuşları ile hareket ediyoruz
        if (controller.isGrounded)
        {
            direction.y = -1;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerJump();
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }
       
          if (Input.GetKeyDown(KeyCode.RightArrow))
          {
              Debug.Log("Sağ");
              desiredLane++;
              if (desiredLane == 3)
                  desiredLane = 2;

          }
          if (Input.GetKeyDown(KeyCode.LeftArrow))
          {
              Debug.Log("Sol");
              desiredLane--;
              if (desiredLane == -1)
                  desiredLane = 0;

          }
}
    private void FixedUpdate()
    {
        //Oyuncumuzun  zamana bağlı hareketini sağlıyor.
       controller.Move(direction * Time.fixedDeltaTime);
    }
    private void playerJump()
    {
        direction.y = jumpForce;
    }
}
