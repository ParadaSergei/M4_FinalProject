using UnityEngine;
using UnityEngine.UI;

public class ActiveItemSlotInventary : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public CameraRayCast cameraRayCast;
    public PointWorld pointWorld;
    public Transform QuickPanel;
    public Inventorymanager InventoryManager;
    public int currentQuickSlotID = 0;
    public Sprite selectedSprite;
    public Sprite notSelectedSprite;
    private RaycastHit hit;
    private Ray ray;
    void Update()
    {


        ScrollSystem();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (QuickPanel.GetChild(currentQuickSlotID).GetComponent<InventorySlot>().item != null)
            {
                if (QuickPanel.GetChild(currentQuickSlotID).GetComponent<InventorySlot>().item.ItemType == ItemType.Lovushka && QuickPanel.GetChild(currentQuickSlotID).GetComponent<Image>().sprite == selectedSprite)
                {
                    ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit, 100f))
                    {
                        gameObject.transform.position = hit.point;
                        if (hit.collider.gameObject.GetComponent<PointTriggerLovushka>() != null)
                        {
                            Debug.Log("Место ловушки");
                            if (hit.collider.gameObject.GetComponent<PointTriggerLovushka>().isEmpty == true)
                            {
                                hit.collider.gameObject.GetComponent<PointTriggerLovushka>().isEmpty = false;
                                if (QuickPanel.GetChild(currentQuickSlotID).GetComponent<InventorySlot>().item.lovushkaPrefab != null)
                                    Instantiate(QuickPanel.GetChild(currentQuickSlotID).GetComponent<InventorySlot>().item.lovushkaPrefab, hit.transform.position, hit.transform.rotation);
                            }
                        }
                    }
                    if (hit.collider.gameObject.GetComponent<PointTriggerLovushka>() != null)
                    {

                        if (QuickPanel.GetChild(currentQuickSlotID).GetComponent<InventorySlot>().amountItem <= 1)
                        {
                            QuickPanel.GetChild(currentQuickSlotID).GetComponentInChildren<OldSlot>().NullifySlotData();
                        }
                        else
                        {
                            QuickPanel.GetChild(currentQuickSlotID).GetComponent<InventorySlot>().amountItem--;
                            QuickPanel.GetChild(currentQuickSlotID).GetComponent<InventorySlot>().textAmountText.text = QuickPanel.GetChild(currentQuickSlotID).GetComponent<InventorySlot>().amountItem.ToString();
                        }
                    }
                }
            }
        }
    }
    private void ScrollSystem()
    {
        float MouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if (MouseWheel > 0.1)
        {
            QuickPanel.GetChild(currentQuickSlotID).GetComponent<Image>().sprite = notSelectedSprite;
            if (currentQuickSlotID >= QuickPanel.childCount - 1)
            {
                currentQuickSlotID = 0;
            }
            else
            {
                currentQuickSlotID++;
            }
            QuickPanel.GetChild(currentQuickSlotID).GetComponent<Image>().sprite = selectedSprite;
        }
        if (MouseWheel < -0.1)
        {
            QuickPanel.GetChild(currentQuickSlotID).GetComponent<Image>().sprite = notSelectedSprite;
            if (currentQuickSlotID <= 0)
            {
                currentQuickSlotID = QuickPanel.childCount - 1;
            }
            else
            {
                currentQuickSlotID--;
            }
            QuickPanel.GetChild(currentQuickSlotID).GetComponent<Image>().sprite = selectedSprite;
        }
        for (int i = 0; i < QuickPanel.childCount; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                if (currentQuickSlotID == i)
                {
                    if (QuickPanel.GetChild(currentQuickSlotID).GetComponent<Image>().sprite = notSelectedSprite)
                    {
                        QuickPanel.GetChild(currentQuickSlotID).GetComponent<Image>().sprite = selectedSprite;
                    }
                    else
                    {
                        QuickPanel.GetChild(currentQuickSlotID).GetComponent<Image>().sprite = notSelectedSprite;
                    }
                }
                else
                {
                    QuickPanel.GetChild(currentQuickSlotID).GetComponent<Image>().sprite = notSelectedSprite;
                    currentQuickSlotID = i;
                    QuickPanel.GetChild(currentQuickSlotID).GetComponent<Image>().sprite = selectedSprite;
                }
            }
        }
    }
    /*    public void ChangeHeals()
        {
            if (rassudok.rasudokAmount + QuickPanel.GetChild(currentQuickSlotID).GetComponent<InventorySlot>().item.changedHealth <= 100)
            {
                float newHealse = rassudok.rasudokAmount + QuickPanel.GetChild(currentQuickSlotID).GetComponent<InventorySlot>().item.changedHealth;
                rassudok.rasudokAmount = newHealse;
            }
            else
            {
                rassudok.rasudokAmount = 100f;
            }
        }*/
}
