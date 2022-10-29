using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGround : Map
{
    int select = 0;
    int ox;
    int oz;
    float oy;
    int num;
    float box;
    GameObject currCube;
    GameObject floor;
    Vector3 startPos;
    Quaternion startLocation;

    Ray ray;
    RaycastHit hit;
    void Start()
    {
        for (int i = 0; i <= tileX; i++)
        {
            for (int j = 0; j <= tileX; j++)
            {
                floor = Instantiate(quadFactory);
                Vector3 firstPos = transform.position;
                firstPos.x += j;
                firstPos.z += i;
                floor.transform.position = firstPos;
                floor.transform.rotation = transform.rotation;
            }
        }



    }
    UnityEngine.Transform selectObj;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            int layer = 1 << LayerMask.NameToLayer("Obj");
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
            {
                if (hit.transform.CompareTag("Furniture"))
                {
                    selectObj = hit.transform;
                   // selectObj.gameObject.GetComponent<Furniture>().located = false;
                    
                    selectObj.gameObject.GetComponent<Furniture>().startPos = hit.transform.position;
                    startPos = selectObj.gameObject.GetComponent<Furniture>().startPos;
                    GameManager.instance.name = selectObj.name;

                    //selectObj.GetComponent<BoxCollider>().center = new Vector3(selectObj.GetComponent<BoxCollider>().center.x, 0, selectObj.GetComponent<BoxCollider>().center.z);
                    selectObj.GetComponent<BoxCollider>().center = transform.InverseTransformPoint(new Vector3(0, 27, 0));



                }

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    if (AddManager.instance.AddBed == true)
                    {
                        num = 0;
                        Room(AddManager.instance.bedItems[AddManager.instance.currButtonNum]);
                        AddManager.instance.AddBed = false;
                    }
                    if (AddManager.instance.AddChair == true)
                    {
                        num = 1;
                        Room(AddManager.instance.chairItems[AddManager.instance.currButtonNum]);
                        AddManager.instance.AddChair = false;
                        //currCube = Instantiate(AddManager.instance.chairItems[AddManager.instance.currButtonNum]);
                        //num = 1;
                        //AddManager.instance.AddChair = false;
                        //SaveJson(currCube.gameObject);
                        //currCube.name = "d" + select;
                        //select += 1;
                        //currCube.layer = LayerMask.NameToLayer("Obj");
                        //int x = (int)(hit.point.x);
                        //int z = (int)(hit.point.z);
                        //currCube.transform.position = new Vector3(x, hit.point.y, z);
                        //if (currCube.GetComponent<Furniture>())
                        //{
                        //    currCube.GetComponent<Furniture>().startPos = new Vector3(x, hit.point.y, z);
                        //    startPos = currCube.GetComponent<Furniture>().startPos;
                        //    currCube.GetComponent<Furniture>().startRotation = currCube.transform.rotation;
                        //    startLocation = currCube.GetComponent<Furniture>().startRotation;
                        //}
                    }
                    //startPos = currCube.transform.position;
                    if (AddManager.instance.AddDesk == true)
                    {
                        num = 2;
                        Room(AddManager.instance.DeskItem[AddManager.instance.currButtonNum]);
                        AddManager.instance.AddDesk = false;
                    }
                    if (AddManager.instance.AddCloset == true)
                    {
                        Room(AddManager.instance.closetItems[AddManager.instance.currButtonNum]);
                        AddManager.instance.AddCloset = false;
                    }
                    if (AddManager.instance.AddCoffeeTable == true)
                    {
                        Room(AddManager.instance.coffee_tableItems[AddManager.instance.currButtonNum]);
                        AddManager.instance.AddCoffeeTable = false;
                    }
                    if (AddManager.instance.AddEntertainment == true)
                    {
                        Room(AddManager.instance.entertainmentItems[AddManager.instance.currButtonNum]);
                        AddManager.instance.AddEntertainment = false;
                    }
              
                    if (AddManager.instance.AddElectrionic == true)
                    {
                        Room(AddManager.instance.electrionicsItems[AddManager.instance.currButtonNum]);
                        AddManager.instance.AddElectrionic = false;
                    }
              
                    if (AddManager.instance.AddFlower == true)
                    {
                        Room(AddManager.instance.flowerItems[AddManager.instance.currButtonNum]);
                        AddManager.instance.AddFlower = false;
                    }
                    if (AddManager.instance.AddKitchenChair == true)
                    {
                        Room(AddManager.instance.kitchenChairItems[AddManager.instance.currButtonNum]);
                        AddManager.instance.AddKitchenChair = false;
                    }
                    if (AddManager.instance.AddKitchenTable == true)
                    {
                        Room(AddManager.instance.kitchenTableItems[AddManager.instance.currButtonNum]);
                        AddManager.instance.AddKitchenTable = false;
                    }
                    if (AddManager.instance.AddLamp == true)
                    {
                        Room(AddManager.instance.lamp[AddManager.instance.currButtonNum]);
                        AddManager.instance.AddLamp = false;
                    }
                    if (AddManager.instance.AddLoungeChair == true)
                    {
                        Room(AddManager.instance.loungeChairItems[AddManager.instance.currButtonNum]);
                        AddManager.instance.AddLoungeChair = false;
                    }
                    if (AddManager.instance.AddInstrument == true)
                    {
                        Room(AddManager.instance.musical_instrumentItems[AddManager.instance.currButtonNum]);
                        AddManager.instance.AddInstrument = false;
                    }
                    if (AddManager.instance.AddOfficeChair == true)
                    {
                        Room(AddManager.instance.office_chair[AddManager.instance.currButtonNum]);
                        AddManager.instance.AddOfficeChair = false;
                    }
                    if (AddManager.instance.AddShelf == true)
                    {
                        Room(AddManager.instance.shelf[AddManager.instance.currButtonNum]);
                        AddManager.instance.AddShelf = false;
                    }

                }

            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (selectObj)
            {
                if (selectObj.GetComponent<Furniture>().canLocated == true)
                {
                    selectObj.position = new Vector3(ox, oy, oz);
                    SaveJson(selectObj.gameObject);
                    selectObj.gameObject.GetComponent<Furniture>().located = true;

                    selectObj.GetComponent<BoxCollider>().center = new Vector3(selectObj.GetComponent<BoxCollider>().center.x, box, selectObj.GetComponent<BoxCollider>().center.z);
                    
                    selectObj = null;

                }
                else
                {
                    selectObj.position = startPos;
                    selectObj.rotation = startLocation;
                    SaveJson(selectObj.gameObject);
                    selectObj.GetComponent<Furniture>().canLocated = false;
                    selectObj = null;
                }

            }
        }
        if (selectObj != null)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            int layer = 1 << LayerMask.NameToLayer("Ground");
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    int x = (int)(hit.point.x);
                    ox = (int)(hit.point.x);
                    int z = (int)(hit.point.z);
                    oz = (int)(hit.point.z);
                    oy = hit.point.y;
                    selectObj.position = new Vector3(x, hit.point.y + 5, z);


                }
            }
            if (Input.GetKeyDown("i"))
            {
                selectObj.GetComponent<Furniture>().Delete();
                RemoveJson(selectObj.gameObject);

            }
        }
    }

    void SaveJson(GameObject obj)
    {
        for (int i = 0; i < AddManager.instance.objectInfoList.Count; i++)
        {
            if (AddManager.instance.objectInfoList[i].obj == obj)
            {
                //��������
                AddManager.instance.objectInfoList[i].position = obj.transform.position;
                AddManager.instance.objectInfoList[i].scale = obj.transform.localScale;
                AddManager.instance.objectInfoList[i].angle = obj.transform.eulerAngles;
                return;
            }
        }
        AddManager.instance.objectInfo = new ObjectInfo();
        AddManager.instance.obj = obj;

        AddManager.instance.pos = obj.transform.position;
        AddManager.instance.sca = obj.transform.localScale;
        AddManager.instance.ang = obj.transform.eulerAngles;
        AddManager.instance.objectInfo.objNumber = AddManager.instance.currButtonNum;
        AddManager.instance.objectInfo.folderNumber = num;
        AddManager.instance.objectInfo.obj = AddManager.instance.obj;
        AddManager.instance.objectInfo.position = AddManager.instance.pos;
        AddManager.instance.objectInfo.scale = AddManager.instance.sca;
        AddManager.instance.objectInfo.angle = AddManager.instance.ang;
        AddManager.instance.objectInfoList.Add(AddManager.instance.objectInfo);
    }

    void RemoveJson(GameObject obj)
    {
        ObjectInfo info;
        for (int i = 0; i < AddManager.instance.objectInfoList.Count; i++)
        {
            if (AddManager.instance.objectInfoList[i].obj == obj)
            {
                AddManager.instance.objectInfoList.RemoveAt(i);
                return;
            }
        }

    }

    void Room(GameObject item)
    {
        currCube = Instantiate(item);
        
        SaveJson(currCube.gameObject);
        currCube.name = "d" + select;
        select += 1;
        currCube.layer = LayerMask.NameToLayer("Obj");
        int x = (int)(hit.point.x);
        int z = (int)(hit.point.z);
        currCube.transform.position = new Vector3(x, hit.point.y, z);
        if (currCube.GetComponent<Furniture>())
        {
            currCube.GetComponent<Furniture>().startPos = new Vector3(x, hit.point.y, z);
            startPos = currCube.GetComponent<Furniture>().startPos;
            currCube.GetComponent<Furniture>().startRotation = currCube.transform.rotation;
            startLocation = currCube.GetComponent<Furniture>().startRotation;
        }
        box = currCube.GetComponent<BoxCollider>().center.y;
    }


}