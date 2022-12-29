using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenario駅ホーム : MonoBehaviour
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
        if (player.transform.position.x < minX)
        {
            SceneManager.LoadScene("踏切Scene");
        }
        else if (maxX < player.transform.position.x)
        {
            SceneManager.LoadScene("美浜Scene");
        }
    }
}
