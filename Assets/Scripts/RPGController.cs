using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class RPGController : MonoBehaviour
{
    public float speed;
    private Vector2 movement;
    public Tilemap map; 
    public Transform targetPosition;
    public LayerMask Unwalkable;
    public List<Sprite> sprites; 

    public LayerMask Walkable;

    private int spriteNumber = 0;

    private void Awake() {
        targetPosition.position = transform.position;
    }

    void Update()
    {
        gameObject.GetComponent<Animator>().SetInteger("AnimationController", spriteNumber);
        
        if (Vector3.Distance(transform.position, targetPosition.position) < .005f &&
         !Physics2D.OverlapCircle(targetPosition.position + new Vector3(movement.x * 0.16f , movement.y * 0.16f, 0f), .01f, Unwalkable)) 
        {
            Collider2D otherObject = Physics2D.OverlapCircle(targetPosition.position + new Vector3(movement.x *0.16f, movement.y*0.16f , 0f), .01f, Walkable);
            // should take care of collision
            if (Physics2D.OverlapCircle(targetPosition.position + new Vector3(movement.x *0.16f, movement.y*0.16f , 0f), .01f, Walkable)
            && movement != Vector2.zero) {
                if(otherObject){
                    if(!Physics2D.OverlapCircle(targetPosition.position + new Vector3(2*movement.x*0.16f, 2*movement.y*0.16f, 0f), .01f, Unwalkable) && 
                    !Physics2D.OverlapCircle(targetPosition.position + new Vector3(2*movement.x*0.16f, 2*movement.y*0.16f, 0f), .01f, Walkable)) {
                        targetPosition.position = new Vector3(targetPosition.position.x + movement.x * 0.16f, targetPosition.position.y + movement.y *0.16f, 0f);
                        otherObject.gameObject.transform.position = new Vector3(targetPosition.position.x + movement.x * 0.16f, targetPosition.position.y +movement.y * 0.16f, 0f);
                    }
                }
            } else {
                targetPosition.position = new Vector3(targetPosition.position.x + movement.x * 0.16f, targetPosition.position.y + movement.y * 0.16f, 0f);
            }

        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
        movement = Vector2.zero;
    }

    void OnMove(InputValue val){
        movement = val.Get<Vector2>();
        //changing sprite
        if(movement.x > 0) spriteNumber = 2;
        else if(movement.x < 0)spriteNumber = 1;
        else if(movement.y >0) spriteNumber = 3;
        else if(movement.y < 0) spriteNumber = 0;

        if(movement.x != 0 && movement.y != 0){
            movement = Vector2.zero;
        };
    }
}
