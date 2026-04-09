using TMPro;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public CubeGenarator[] generateCubes = new CubeGenarator[5];

    public float timer = 0.0f;
    public float interval = 3.0f;

    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= interval)
        {
            RandomizeCubeActivation();
            timer = 0;
        }
    }

    public void RandomizeCubeActivation()
    {
        for (int i = 0; i < generateCubes.Length; i++)
        {
            int randomNum = Random.Range(0, 2);

            if (randomNum == 1)
            {
                generateCubes[i].GenCube();
            }
        }
    }
}
