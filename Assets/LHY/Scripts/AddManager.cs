using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ObjectInfo
{
    public GameObject obj;
    public Vector3 position;
    public Vector3 scale;
    public Vector3 angle;
}

public class ArrayJson<T>
{
    public List<T> data;
}


public class AddManager : MonoBehaviour
{
    public static AddManager instance;

    public ObjectInfo objectInfo;
    public List<ObjectInfo> objectInfoList = new List<ObjectInfo>();
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    //오브젝트들이 생성되는 장소
    public Transform SpawnPos ;

    //침대오브젝트
    public GameObject[] bedItems;
    //의자오브젝트
    public GameObject[] chairItems;
    //책상 오브젝트
    public GameObject[] DeskItem;
    //벽 걸이 오브젝트
    public GameObject[] WallHangItem;
    //옷장 오브젝트
    public GameObject[] closetItems;
    //옷걸이 오브젝트
    public GameObject[] clothesItems;
    //커피 테이블 오브젝트
    public GameObject[] coffee_tableItems;
    //전자 제품 오브젝트
    public GameObject[] entertainmentItems;
    //오락 제품 오브젝트
    public GameObject[] electrionicsItems;
    //꽃 오브젝트
    public GameObject[] flowerItems;
    //부엌 의자 오브젝트
    public GameObject[] kitchenChairItems;
    //부엌 용품 오브젝트
    public GameObject[] kitchenTableItems;
    //램프 오브젝트
    public GameObject[] lamp;
    //라운지 의자 오브젝트
    public GameObject[] loungeChairItems;
    //음악 오브젝트
    public GameObject[] musical_instrumentItems;
    //오피스 의자 오브젝트
    public GameObject[] office_chair;
    //선반 오브젝트
    public GameObject[] shelf;

    public GameObject obj;
    public Vector3 pos;
    public Vector3 sca;
    public Vector3 ang;
    public bool AddBed = false;
    public bool AddChair = false;
    public bool AddDesk = false;
    public bool AddWallHang = false;
    public bool AddCloset = false;
    public bool AddClothes = false;
    public bool AddCoffeeTable = false;
    public bool AddEntertainment = false;
    public bool AddElectrionic = false;
    public bool AddFlower = false;
    public bool AddKitchenChair = false;
    public bool AddKitchenTable = false;
    public bool AddLamp = false;
    public bool AddLoungeChair = false;
    public bool AddInstrument = false;
    public bool AddOfficeChair = false;
    public bool AddShelf = false;


    public int currButtonNum = 0;
    void Start()
    {
        bedItems = Resources.LoadAll<GameObject>("bed");
        chairItems = Resources.LoadAll<GameObject>("armchair");
        DeskItem = Resources.LoadAll<GameObject>("office_desk");
        WallHangItem = Resources.LoadAll<GameObject>("window");
        closetItems = Resources.LoadAll<GameObject>("closet");
        clothesItems = Resources.LoadAll<GameObject>("clothes");
        coffee_tableItems = Resources.LoadAll<GameObject>("coffee_table");
        entertainmentItems = Resources.LoadAll<GameObject>("entertainment");
        electrionicsItems = Resources.LoadAll<GameObject>("electronics");
        flowerItems = Resources.LoadAll<GameObject>("flower");
        kitchenChairItems = Resources.LoadAll<GameObject>("kitchen_chair");
        kitchenTableItems = Resources.LoadAll<GameObject>("kitchen_table");
        lamp = Resources.LoadAll<GameObject>("lamp");
        loungeChairItems = Resources.LoadAll<GameObject>("lounge_chair");
        musical_instrumentItems = Resources.LoadAll<GameObject>("musical_instrument");
        office_chair = Resources.LoadAll<GameObject>("office_chair");
        shelf = Resources.LoadAll<GameObject>("shelf");
        //for (int i = 0; i < bedItems.Length; i++)
        //{
        //    bedItems[i].AddComponent<Furniture>();
        //    bedItems[i].AddComponent<DragDrop>();
        //    bedItems[i].AddComponent<Rigidbody>();
        //    bedItems[i].tag = "Furniture";
        //}
     
        //for (int i = 0; i < WallHangItem.Length; i++)
        //{
        //    WallHangItem[i].AddComponent<Furniture>();
        //    WallHangItem[i].AddComponent<DragDrop>();
        //    WallHangItem[i].AddComponent<Rigidbody>();
        //    WallHangItem[i].tag = "Wall";
        //}
    }
    
    public void OnSave()
    {
        objectInfo = new ObjectInfo();
        objectInfo.obj = obj;
        objectInfo.position = pos;
        objectInfo.scale = sca;
        objectInfo.angle = ang;
        string jsonData = JsonUtility.ToJson(objectInfo, true);
        // 저장경로
        string path = Application.dataPath + "/data.txt";
        // 파일로 저장
        File.WriteAllText(path, jsonData);
        print(jsonData);
    }

    public void OnSave2()
    {
        
        ArrayJson<ObjectInfo> arrayJson = new ArrayJson<ObjectInfo>();
        
        arrayJson.data = objectInfoList;
        //objectInfoList.Add(objectInfo);
        
        //ArrayJson -> json
        string jsonData = JsonUtility.ToJson(arrayJson);
        print(jsonData);
        // 저장경로
        string path = Application.dataPath + "/Data";
        
        //만약에 경로가 없다면
        if(Directory.Exists(path)== false)
        {
            //폴더를 만든다.
            Directory.CreateDirectory(path);
        }

        // 파일로 저장
        File.WriteAllText(path + "/data.txt", jsonData);

    }

    public void OnLoad()
    {
        //저장된 정보 불러오고
        string path = Application.dataPath + "/data.txt";
        string jsonData = File.ReadAllText(path);
        //json -> objectInfo 에 셋팅
        objectInfo = JsonUtility.FromJson<ObjectInfo>(jsonData);
        //물체생성
        CreateObject(objectInfo);
    }

    public void OnLoad2()
    {
        //파일로 불러오기
        string path = Application.dataPath + "/Data";
        string jsonData = File.ReadAllText(path + "/data.txt");
        //불러온 파일(jsonData) -> ArrayJson<ObjectInfo>
        ArrayJson<ObjectInfo> arrayJson = JsonUtility.FromJson<ArrayJson<ObjectInfo>>(jsonData);
        //arrayJson를 참고해서 오브젝트 생성
        for(int i =0; i < arrayJson.data.Count; i++)
        {
            CreateObject(arrayJson.data[i]);
        }
    }

    public void CreateObject(ObjectInfo info)
    {
        GameObject createObj = Instantiate(info.obj);
        createObj.transform.position = info.position;
        createObj.transform.localScale = info.scale;
        createObj.transform.eulerAngles = info.angle;
    }
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

    public void Button6()
    {
        currButtonNum = 6;
    }

    public void Button7()
    {
        currButtonNum = 7;
    }

    public void Button8()
    {
        currButtonNum = 8;
    }

    public void Button9()
    {
        currButtonNum = 9;
    }

    public void Button10()
    {
        currButtonNum = 10;
    }

    public void Button11()
    {
        currButtonNum = 11;
    }
    public void Button12()
    {
        currButtonNum = 12;
    }
    public void Button13()
    {
        currButtonNum = 13;
    }

    public void Button14()
    {
        currButtonNum = 14;
    }

    public void Button15()
    {
        currButtonNum = 15;
    }

    public void Button16()
    {
        currButtonNum = 16;
    }

    public void Button17()
    {
        currButtonNum = 17;
    }

    public void Button18()
    {
        currButtonNum = 18;
    }

    public void Button19()
    {
        currButtonNum = 19;
    }

    public void Button20()
    {
        currButtonNum = 20;
    }

    public void Button21()
    {
        currButtonNum = 21;
    }

    public void Button22()
    {
        currButtonNum = 22;
    }

    public void Button23()
    {
        currButtonNum = 23;
    }

    public void Button24()
    {
        currButtonNum = 24;
    }

    public void Button25()
    {
        currButtonNum = 25;
    }

    public void Button26()
    {
        currButtonNum = 26;
    }

    public void Button27()
    {
        currButtonNum = 27;
    }

    public void Button28()
    {
        currButtonNum = 28;
    }

    public void Button29()
    {
        currButtonNum = 29;
    }

    public void Button30()
    {
        currButtonNum = 30;
    }

    public void Button31()
    {
        currButtonNum = 31;
    }

    public void Button32()
    {
        currButtonNum = 32;
    }

    public void Button33()
    {
        currButtonNum = 33;
    }

    public void Button34()
    {
        currButtonNum = 34;
    }

    public void Button35()
    {
        currButtonNum = 35;
    }

    public void Button36()
    {
        currButtonNum = 36;
    }

    public void Button37()
    {
        currButtonNum = 37;
    }

    public void Button38()
    {
        currButtonNum = 38;
    }

    public void Button39()
    {
        currButtonNum = 39;
    }

    public void Button40()
    {
        currButtonNum = 40;
    }

    public void Button41()
    {
        currButtonNum = 41;
    }

    public void Button42()
    {
        currButtonNum = 42;
    }

    public void Button43()
    {
        currButtonNum = 43;
    }

    public void Button44()
    {
        currButtonNum = 44;
    }





    public void OnAddBed()
    {
        AddBed = true;
       // GameObject bed = Instantiate(bedItems[currButtonNum]);
        //bed.transform.position = SpawnPos.transform.position;
    }

    public void OnAddChair()
    {
        AddChair = true;
        //GameObject chair = Instantiate(chairItems[currButtonNum]);
        //chair.transform.position = SpawnPos.transform.position;
    }
    public void OnAddDesk()
    {
        AddDesk = true;
        //GameObject desk = Instantiate(DeskItem[currButtonNum]);
        //desk.transform.position = SpawnPos.transform.position;
    }
    public void OnAddWallHang()
    {
        AddWallHang = true;
        //GameObject wallhang = Instantiate(WallHangItem[currButtonNum]);
        //wallhang.transform.position = SpawnPos.transform.position;
    }
    public void OnAddCloset()
    {
        AddCloset = true;
        //GameObject wallhang = Instantiate(WallHangItem[currButtonNum]);
        //wallhang.transform.position = SpawnPos.transform.position;
    }

    public void OnAddCoffeeTable()
    {
        AddCoffeeTable = true;
        //GameObject wallhang = Instantiate(WallHangItem[currButtonNum]);
        //wallhang.transform.position = SpawnPos.transform.position;
    }

    public void OnAddEntertainment()
    {
        AddEntertainment = true;
        //GameObject wallhang = Instantiate(WallHangItem[currButtonNum]);
        //wallhang.transform.position = SpawnPos.transform.position;
    }
    public void OnAddElectronics()
    {
        AddEntertainment = true;
        //GameObject wallhang = Instantiate(WallHangItem[currButtonNum]);
        //wallhang.transform.position = SpawnPos.transform.position;
    }

    public void OnAddFlower()
    {
        AddFlower = true;
        //GameObject wallhang = Instantiate(WallHangItem[currButtonNum]);
        //wallhang.transform.position = SpawnPos.transform.position;
    }

    public void OnAddKitchenChair()
    {
        AddKitchenChair = true;
        //GameObject wallhang = Instantiate(WallHangItem[currButtonNum]);
        //wallhang.transform.position = SpawnPos.transform.position;
    }
    public void OnAddKitchenTable()
    {
        AddKitchenTable = true;
        //GameObject wallhang = Instantiate(WallHangItem[currButtonNum]);
        //wallhang.transform.position = SpawnPos.transform.position;
    }
    public void OnAddLamp()
    {
        AddLamp = true;
        //GameObject wallhang = Instantiate(WallHangItem[currButtonNum]);
        //wallhang.transform.position = SpawnPos.transform.position;
    }
    public void OnAddLoungeChair()
    {
        AddLoungeChair = true;
        //GameObject wallhang = Instantiate(WallHangItem[currButtonNum]);
        //wallhang.transform.position = SpawnPos.transform.position;
    }

   
    public void OnAddInstrument()
    {
        AddInstrument = true;
        //GameObject wallhang = Instantiate(WallHangItem[currButtonNum]);
        //wallhang.transform.position = SpawnPos.transform.position;
    }

    public void OnAddOfficeChair()
    {
        AddOfficeChair = true;
        //GameObject wallhang = Instantiate(WallHangItem[currButtonNum]);
        //wallhang.transform.position = SpawnPos.transform.position;
    }

    public void OnShelf()
    {
        AddShelf = true;
        //GameObject wallhang = Instantiate(WallHangItem[currButtonNum]);
        //wallhang.transform.position = SpawnPos.transform.position;
    }



}
