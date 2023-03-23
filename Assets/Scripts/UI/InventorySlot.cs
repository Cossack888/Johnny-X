using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public string NPCname1;

    public int drop = 0;

    public void OnDrop(PointerEventData eventData)
    {

        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DragableObject dragableObject = dropped.GetComponent<DragableObject>();
            dragableObject.parentAfterDrag = transform;


        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        NPCname1 = collision.gameObject.name;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        NPCname1 = "You do not know who";
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}