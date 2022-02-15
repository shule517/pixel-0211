using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("BallSet");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BallSet()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(1.0f);
            Instantiate(ball, new Vector3(26 + i * 8, 1.71f, 0), Quaternion.identity);
        }
    }
}
