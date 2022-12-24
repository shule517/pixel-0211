using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenario”ü•l : MonoBehaviour
{
    public GameObject player;
    public float minX;
    public float maxX;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x  < minX)
        {
            SceneManager.LoadScene("‰wƒz[ƒ€Scene");
        }
        else if (maxX < player.transform.position.x || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("–é“¹Scene");
        }
    }
}
