using UnityEngine;
using UnityEngine.UI;

public class PointWorld : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private ActiveItemSlotInventary activeSlot;
    private RaycastHit hit;
    private Ray ray;
    [SerializeField] private GameObject lovushka;
    [SerializeField] private Inventorymanager manager;

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        /*if (activeSlot.QuickPanel.GetChild(activeSlot.currentQuickSlotID).GetComponent<InventorySlot>().item.ItemType == ItemType.Lovushka && activeSlot.QuickPanel.GetChild(activeSlot.currentQuickSlotID).GetComponent<Image>().sprite == activeSlot.selectedSprite)
        {*/
            if (Physics.Raycast(ray, out hit, 100f))
            {
                gameObject.transform.position = hit.point;
                /*
                if (hit.collider.gameObject.GetComponent<PointTriggerLovushka>() != null)
                {
                    Debug.Log("Место ловушки");
                    if (hit.collider.gameObject.GetComponent<PointTriggerLovushka>().isEmpty == true)
                    {
                        hit.collider.gameObject.GetComponent<PointTriggerLovushka>().isEmpty = false;
                        if (activeSlot.QuickPanel.GetChild(activeSlot.currentQuickSlotID).GetComponent<InventorySlot>().item.lovushkaPrefab != null)
                            Instantiate(activeSlot.QuickPanel.GetChild(activeSlot.currentQuickSlotID).GetComponent<InventorySlot>().item.lovushkaPrefab, hit.transform.position, hit.transform.rotation);
                    }
                }*/
                if (hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    if (Input.GetMouseButton(0))
                    {
                        manager.AddItem(hit.collider.gameObject.GetComponent<Item>().itemItem, hit.collider.gameObject.GetComponent<Item>().amountItem);
                        Destroy(hit.collider.gameObject);
                    }
                }
           // }
            /*
            if (hit.collider.gameObject.GetComponent<PointTriggerLovushka>() != null)
            {
                Debug.Log("Место ловушки");
                if (Input.GetMouseButton(0))
                {
                    if (hit.collider.gameObject.GetComponent<PointTriggerLovushka>().isEmpty == true)
                    {
                        hit.collider.gameObject.GetComponent<PointTriggerLovushka>().isEmpty = false;
                        Instantiate(lovushka, hit.transform.position, hit.transform.rotation);
                    }
                }
            }*/
        }
    }
}