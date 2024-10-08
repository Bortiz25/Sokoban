using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public List<Transform> spotList;
    public bool isOnSpot = false;

    public RPGController player; 
    private Vector3 boxPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        boxPosition = gameObject.transform.position;
        isOnSpot = CheckAllBox();
    }

    public bool CheckBox(Transform spot){
        if(spot.position.x - 0.05f < gameObject.transform.position.x && spot.position.x + 0.05f > gameObject.transform.position.x &&
        spot.position.y - 0.05f < gameObject.transform.position.y && spot.position.y + 0.05f > gameObject.transform.position.y){
            return true;
        }
        return false;
    }

    bool CheckAllBox(){
        foreach(Transform t in spotList){
            if(CheckBox(t)) return true;
        }
        return false; 
    }


    public bool GetOnSpot(){
        return isOnSpot;
    }
    public Vector3 GetBoxPosition(){
        return boxPosition;
    }

}
