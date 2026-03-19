using UnityEngine;
using UnityEngine.UI;

public class MyJump : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float power = 200f;
    public Text TimeUi;
    public float Timer;

    void Update()
    {
        Timer += Time.deltaTime;
        TimeUi.text = Timer.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            power += Random.Range(-100, 200);
            rigidbody.AddForce(transform.up * power);
        }

        if (gameObject.transform.position.y > 5 || gameObject.transform.position.y < -3)
        {
            Destroy(gameObject);
        }
    }
}
