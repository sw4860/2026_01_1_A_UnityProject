using UnityEngine;

public class MyBall : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " 와 충돌함");

        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("땅과 충돌함!");
        }
    }

    //OnTriggerStay

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("트리거 안으로 들어옴");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("트리거 밖으로 나감");
    }
}
