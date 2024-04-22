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
}