using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenario���� : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (-95 < player.transform.position.x || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("�w�z�[��Scene");
        }
    }
}
