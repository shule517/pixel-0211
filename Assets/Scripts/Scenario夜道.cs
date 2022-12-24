using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenario–é“¹ : MonoBehaviour
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
            SceneManager.LoadScene("‚æ‚¶‚ÜScene");
        }
        else if (maxX < player.transform.position.x || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("‚æ‚¶‚ÜScene");
        }
    }
}
