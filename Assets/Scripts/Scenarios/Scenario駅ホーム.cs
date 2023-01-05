using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenario駅ホーム : MonoBehaviour
{
    public GameObject player;
    public float minX;
    public float maxX;

    //public GameObject train;
    public GameObject doorLeft;
    public GameObject doorRight;

    // Start is called before the first frame update
    void Start()
    {
        //train.transform.DOMove(new Vector3(140f, 0.88f, 0f), 10f).SetEase(Ease.OutQuad);
        doorLeft.transform.DOLocalMove(new Vector3(-0.18f, 0f, 0f), 2f).SetDelay(11f).SetEase(Ease.OutQuad);
        doorRight.transform.DOLocalMove(new Vector3(+0.18f, 0f, 0f), 2f).SetDelay(11f).SetEase(Ease.OutQuad);
    }

    // Update is called once per frame
    void Update()
    {
        //if (player.transform.position.x < minX)
        //{
        //    SceneManager.LoadScene("踏切Scene");
        //}
        if (maxX < player.transform.position.x)
        {
            SceneManager.LoadScene("しみじみエンディングScene");
        }
    }
}
