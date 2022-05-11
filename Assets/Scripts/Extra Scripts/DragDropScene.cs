using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropScene : MonoBehaviour
{

    //This script has two modes: centered and accurate.
    //Centered mode will snap whateveryou are dragging to be centered on the cursor
    //accurate will drag without cetering, keeping the objects position identical to when you clicked on it

    //the script is currently in accurate mode, to switch to centered remove the lines regarding to startPosX/Y


    /*
     * How To Switch Modes
     * 
     * remove theese entirly
     *      startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

     * 
     * remove the subtractions from this line
     *  this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
     * 
     * and  remove variables if no longer needed
     * */


    private float startPosX;
    private float startPosY;
    private bool IsHeld = false;
  
   
    
    
    // Update is called once per frame
    
    
    void Update()
    {

        if (IsHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }
       
        

    }

    void OnMouseDown()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            IsHeld = true;

        }
           

    }


    void OnMouseUp()
    {
        IsHeld = false;
    }

   

}
