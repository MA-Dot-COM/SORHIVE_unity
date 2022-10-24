using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class AddManager : MonoBehaviour
{
    //������Ʈ���� �����Ǵ� ���
    public Transform SpawnPos ;

    //ħ�������Ʈ
    public GameObject[] bedItems;
    //���ڿ�����Ʈ
    public GameObject[] chairItems;
    //å�� ������Ʈ
    public GameObject[] DeskItem;
    //�� ���� ������Ʈ
    public GameObject[] WallHangItem;


    public int currButtonNum = 0;

    public void Button0()
    {
        currButtonNum = 0;
    }

    public void Button1()
    {
        currButtonNum = 1;
    }
    public void Button2()
    {
        currButtonNum = 2;
    }
    public void Button3()
    {
        currButtonNum = 3;
    }
    public void Button4()
    {
        currButtonNum = 4;
    }
    public void Button5()
    {
        currButtonNum = 5;
    }

    public void OnAddBed()
    {       
        GameObject bed = Instantiate(bedItems[currButtonNum]);
        bed.transform.position = SpawnPos.transform.position;
    }

    public void OnAddChair()
    {
        GameObject chair = Instantiate(chairItems[currButtonNum]);
        chair.transform.position = SpawnPos.transform.position;
    }
    public void OnAddDesk()
    {
        GameObject desk = Instantiate(DeskItem[currButtonNum]);
        desk.transform.position = SpawnPos.transform.position;
    }
    public void OnAddWallHang()
    {
        GameObject wallhang = Instantiate(WallHangItem[currButtonNum]);
        wallhang.transform.position = SpawnPos.transform.position;
    }
}