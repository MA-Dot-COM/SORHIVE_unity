using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LifeingRoomItem : MonoBehaviour
{
    public RawImage avatarImage;
    public RawImage roomImage;
    public Text memberName;
    public RawImage ProfileImage;

    public string roomImg;
    public string avatarImg;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetTextureR(roomImage, avatarImage));
        ProfileImage.texture = roomImage.texture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetTextureR(RawImage roomImage, RawImage avatarImage)
    {
        //lifeingRoomItem.roomImage = friendList[i].roomImage
        var urlR = roomImg;
        var urlA = avatarImg;


        UnityWebRequest wwwR = UnityWebRequestTexture.GetTexture(urlR);
        yield return wwwR.SendWebRequest();

        UnityWebRequest wwwA = UnityWebRequestTexture.GetTexture(urlA);
        yield return wwwA.SendWebRequest();

        if (wwwR.result != UnityWebRequest.Result.Success)
            Debug.Log(wwwR.error);
        else
            roomImage.texture = ((DownloadHandlerTexture)wwwR.downloadHandler).texture;

        if (wwwA.result != UnityWebRequest.Result.Success)
            Debug.Log(wwwA.error);
        else
            avatarImage.texture = ((DownloadHandlerTexture)wwwA.downloadHandler).texture;
    }
}
