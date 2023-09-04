using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropV2 : MonoBehaviour
{

    public GameObject Canvas;
    public GameObject Zone;

    private bool isDragging = false;
    private bool isWithinZone = false;

    private GameObject startParent;
    private Vector2 startPosition;

    private List<float> siblingPositions = new List<float>(); //Holds the X positions of each DropZone object, so new objects are placed in the correct position
    private float currentX;
    private int counter=0;

    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        Zone = GameObject.Find("DropZone");
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //Debug.Log("Touch");
        isWithinZone=true;
        Zone=collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision){
        //Debug.Log("Untouch");
        isWithinZone=false;
        Zone=null;
    }


    public void StartDrag(){
        if(transform.parent.name!="DropZone"){ //Do NOT allow dragging from the dropzone
            //Debug.Log("Drag Started");
            isDragging=true;
            startParent = transform.parent.gameObject;
            startPosition = transform.position;
        }
    }

    public void EndDrag(){
        //Debug.Log("Drag Ended");
        isDragging=false;
        if(isWithinZone){

            foreach (Transform child in Zone.transform){
                siblingPositions.Add(child.position.x);
            }
            currentX=this.transform.position.x;

            foreach(var childX in siblingPositions){
                if(currentX>childX){
                    counter+=1;
                }
            }

            transform.SetParent(Zone.transform, false);
            transform.SetSiblingIndex(counter);
            
            counter=0;
            siblingPositions.Clear();
        }

        else{
            transform.SetParent(startParent.transform, false);
            transform.position=startPosition;;
        }

        if(this.gameObject.transform.parent.name=="DropZone"){
            this.gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }
    }


    void Update()
    {
        if(isDragging){
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }
}
