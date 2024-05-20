using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;//Hareket hızı
    private Rigidbody rbody;
    private Animator animator;

    void Start()
    {
        // Rigidbody ve Animator bileşenlerini al
        rbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Hareket girişlerini al
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Hareket vektörünü oluştur
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Hareketi uygula
        rbody.velocity = movement * speed;

        // Karakterin yönünü değiştir
        if (movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            rbody.rotation = Quaternion.Slerp(rbody.rotation, newRotation, Time.deltaTime * speed);
        }

        // Koşma animasyonunu tetikle
        bool isRunning = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        animator.SetBool("IsRunning", isRunning);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            // Çarpışma durumunda geri itme işlemi
            Vector3 pushBack = collision.contacts[0].normal * 0.1f;
            rbody.position = rbody.position - pushBack;
        }
    }
}
