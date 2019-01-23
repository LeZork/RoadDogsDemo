using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public bool inventoryEnabled;
    public GameObject inventory;
    public GameObject itemDatabase;
    public Transform[] slot;
    public GameObject slotHolder;
    public bool isTriggered;
    public bool isTested;

    private bool pickedUpItem;

    float waitTimer = 0.5f;

	// Use this for initialization
	void Start () {
        GetAllSlots();
	}
	
	// Update is called once per frame
	void Update () {
        //Enabling and disabling the inventory
        if (Input.GetButtonDown("Inventory")){
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            isTriggered = true;
            AddItem(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Item")
        {
            isTriggered = false;
        }
    }

    public void AddItem(GameObject item)
    {
       if(item.GetComponent<ItemPickup>().craftMaterial == false)
        {
            GameObject rootItem;
            rootItem = item.GetComponent<ItemPickup>().rootItem;

            for (int i = 0; i < 30; i++)
            {
                if (slot[i].GetComponent<Slot>().empty == true && item.GetComponent<ItemPickup>().pickedUp == false)
                {
                    isTested = true;
                    slot[i].GetComponent<Slot>().item = rootItem;
                    item.GetComponent<ItemPickup>().pickedUp = true;
                    Destroy(item);
                }
            }
        }
        else
        {
            for (int i = 0; i < 30; i++)
            {
                if (slot[i].GetComponent<Slot>().empty == true && item.GetComponent<ItemPickup>().pickedUp == false)
                {
                    slot[i].GetComponent<Slot>().item = item;
                    item.GetComponent<ItemPickup>().pickedUp = true;
                    item.transform.parent = itemDatabase.transform;

                    item.GetComponent<MeshRenderer>().enabled = false;
                    Destroy(item.GetComponent<Rigidbody>());
                }
            }
        }
    }

    public void GetAllSlots()
    {
        inventoryEnabled = true;
        slot = new Transform[30];
        for(int i = 0; i < 30; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i);
        }
        inventoryEnabled = false;
    }
}
