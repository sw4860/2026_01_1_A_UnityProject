using UnityEngine;
//using UnityEngine.InputSystem;

public class MyCharacter : MonoBehaviour
{
    public int Health = 100;
    public float Timer = 1.0f;
    
    void Start()
    {
        Health += 100;
    }

    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            Timer = 1.0f;
            Health -= 20;
        }

        /*if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Health += 2;
        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Health -= 2;
        }

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
