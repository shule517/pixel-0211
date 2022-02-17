using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Item4
{
    // public int id;
    // public string name;
    // public string description = "デフォルト値";
    // public int[] children;

    public Artist artist;
    public Artworks[] artworks;
    public Artworks[] like_artwokrs;
}

[System.Serializable]
public class Artist
{
    public int id;
    public string name;
}

[System.Serializable]
public class Artworks
{
    public Artist artist;
    public Artwork2 artwork;
}

[System.Serializable]
public class Artwork2
{
    public int id;
    public string media_url;
}

public class GameManager : MonoBehaviour
{
    public GameObject artwork;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        // string url = "http://pixel-museum.herokuapp.com/api/v1/artists/pixel_hal/artworks";
        string url = "http://pixel-museum.herokuapp.com/api/v1/artists/yuki77mi/artworks";
        // string url = "http://pixel-museum.herokuapp.com/api/v1/artists/clrfnd/artworks";
        var apiwww = new WWW (url);
        yield return apiwww;
        Debug.Log("apiwww.text " + apiwww.text);

        var itemJson = apiwww.text;
        Item4 item4 = JsonUtility.FromJson<Item4>(itemJson);

        Debug.Log("itemJson: " + itemJson);
        Debug.Log("item4: " + item4);





        var artworkUrls = new string[] {
            "http://pbs.twimg.com/media/FHFaZREaAAIsq8o.png",
            "http://pbs.twimg.com/media/FLKsamJaQAQgHSA.jpg",
            "http://pbs.twimg.com/media/FLgBV1kakAAvdtQ.png",
            "http://pbs.twimg.com/media/EplgCmdVgAcXIau.png",
            "http://pbs.twimg.com/media/E6kcWAgUUAA2L8H.png",
            "http://pbs.twimg.com/media/EsgMaq5VEAE2vb8.png",
            "https://pbs.twimg.com/profile_banners/1334918399739097089/1609562712",
            "http://pbs.twimg.com/media/E6eB2d9VUAMPqAI.png",
            "http://pbs.twimg.com/media/Era42A5VoAEpVVa.png",
            "http://pbs.twimg.com/media/Eqn9ZOmUYAASTo9.png",
            "http://pbs.twimg.com/media/EqqXAsKU0AAHSSO.png",
            "http://pbs.twimg.com/media/EpNDHVkU8AQYp4V.png",
            "http://pbs.twimg.com/media/E3NE-JrVkAkLOMu.png",
            "http://pbs.twimg.com/media/EsLgAVJUwAI1p_5.png",
            "http://pbs.twimg.com/media/Ep7MuISVgAEYmgX.png",
            "http://pbs.twimg.com/media/FGuuYjgXEAMM8Y1.png",
            "http://pbs.twimg.com/media/E3iDO_HVUAYmlIF.png",
            "http://pbs.twimg.com/media/Ez_pVluWEAI8e_O.jpg",
            "http://pbs.twimg.com/media/E1lRCfGUcAEfpGh.png",
            "http://pbs.twimg.com/media/E5SJoIAVUAMGPcf.png",
            "http://pbs.twimg.com/media/FKVgMohaUAEF-4J.png",
            "http://pbs.twimg.com/media/FEy1JAfaMAAGrb_.png",
            "http://pbs.twimg.com/media/EzvcBLLVgAUe2_1.png",
            "http://pbs.twimg.com/media/FC8vz-baAAAY-DM.jpg",
            "http://pbs.twimg.com/media/E884elSVcBwQNlR.jpg",
            
             };


        // for (int i = 0; i < 20; i++)

        var i = -1;
        // foreach (var artworkUrl in artworkUrls)

        var artworks = item4.artworks.Concat(item4.like_artwokrs).ToArray();

        foreach (var artWorkInfo in artworks)
        {
            var clone = Instantiate(artwork, new Vector3(i * 8, 1.71f, 0), Quaternion.identity);
            var obj = clone.GetComponent<Artwork>();
            obj.mediaUrl = artWorkInfo.artwork.media_url;
            Debug.Log("mediaUrl: " + obj.mediaUrl);
            // var clone = Instantiate(artwork, new Vector3(26 + i * 8, 1.71f, 0), Quaternion.identity);
            // clone.LoadImage("http://pbs.twimg.com/media/FHFaZREaAAIsq8o.png");
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
