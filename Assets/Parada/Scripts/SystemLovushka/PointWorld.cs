using UnityEngine;
using UnityEngine.UI;

public class PointWorld : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private ActiveItemSlotInventary activeSlot;
    public RaycastHit hit;
    private Ray ray;
    [SerializeField] private Inventorymanager manager;

    [Header("LightStickDrop")]
    [SerializeField] private Transform _pricelCursor;
    [SerializeField] private GameObject _stickPrefab;
    [SerializeField] private GameObject _lightStickDrop;
    private float forceStick = 100;

    [Header("Смена Курсора")]
    [SerializeField] private Texture2D cursor;
    [SerializeField] private Texture2D cursorActive;

    [Header("Контроль уменьшения энергии")]
    [SerializeField] private int minusPower = 10;
    [SerializeField] private HealthBarValue _healthBarValue;

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (activeSlot.QuickPanel.GetChild(activeSlot.currentQuickSlotID).GetComponent<InventorySlot>().item != null)
            {
                CheckStickInventory();
                CheckLovushkaInventory();
            }
        }
        if (activeSlot.QuickPanel.GetChild(activeSlot.currentQuickSlotID).GetComponent<InventorySlot>().item != null)
        {
            CheckStickInventory();
        }
        if (Physics.Raycast(ray, out hit, 100f))
        {
            gameObject.transform.position = hit.point;
            if (hit.collider.gameObject.GetComponent<Item>() != null || hit.collider.gameObject.GetComponent<PointTriggerLovushka>() != null) ActiveCursor();
            else DefaultCursor();

            if (hit.collider.gameObject.GetComponent<Item>() != null)
            {
                if (Input.GetMouseButton(0)) //Добавления объекта
                {
                    foreach (InventorySlot slot in manager.inventorySlots)
                    {
                        if (slot.isEmpty == true)
                        {
                            manager.AddItem(hit.collider.gameObject.GetComponent<Item>().itemItem, hit.collider.gameObject.GetComponent<Item>().amountItem);
                            Destroy(hit.collider.gameObject);
                            break;
                        }
                    }
                }
            }
        }
    }
    private void CheckStickInventory()
    {
        if (activeSlot.QuickPanel.GetChild(activeSlot.currentQuickSlotID).GetComponent<InventorySlot>().item.ItemType == ItemType.LightPalka && activeSlot.QuickPanel.GetChild(activeSlot.currentQuickSlotID).GetComponent<Image>().sprite == activeSlot.selectedSprite)
        {
            if (forceStick > 1000)
            {
                forceStick = 1000;
            }
            if (Input.GetKey(KeyCode.G))
            {
                forceStick += 5;
            }
            if (Input.GetKeyUp(KeyCode.G))
            {
                var __stickPrefabRig = Instantiate(_stickPrefab, _lightStickDrop.transform.position, _lightStickDrop.transform.rotation);
                __stickPrefabRig.GetComponent<Rigidbody>().AddForce(_lightStickDrop.transform.forward * forceStick);
                forceStick = 100;
                _healthBarValue.healthValue -= minusPower;
                DestroyItemSlot();
            }

        }
    }
    private void CheckLovushkaInventory()
    {
        if (activeSlot.QuickPanel.GetChild(activeSlot.currentQuickSlotID).GetComponent<InventorySlot>().item.ItemType == ItemType.Lovushka && activeSlot.QuickPanel.GetChild(activeSlot.currentQuickSlotID).GetComponent<Image>().sprite == activeSlot.selectedSprite)
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                gameObject.transform.position = hit.point;
                if (hit.collider.gameObject.GetComponent<PointTriggerLovushka>() != null)//Проверка объекта
                {
                    _healthBarValue.healthValue -= minusPower;
                    Debug.Log("Место ловушки");
                    if (hit.collider.gameObject.GetComponent<PointTriggerLovushka>().isEmpty == true)
                    {
                        hit.collider.gameObject.GetComponent<PointTriggerLovushka>().isEmpty = false;
                    }
                }
            }
            if (hit.collider.gameObject.GetComponent<PointTriggerLovushka>() != null) DestroyItemSlot();
        }
    }
    private void DestroyItemSlot()
    {
        if (activeSlot.QuickPanel.GetChild(activeSlot.currentQuickSlotID).GetComponent<InventorySlot>().amountItem <= 1)
        {
            activeSlot.QuickPanel.GetChild(activeSlot.currentQuickSlotID).GetComponentInChildren<OldSlot>().NullifySlotData();
        }
        else
        {
            activeSlot.QuickPanel.GetChild(activeSlot.currentQuickSlotID).GetComponent<InventorySlot>().amountItem--;
            activeSlot.QuickPanel.GetChild(activeSlot.currentQuickSlotID).GetComponent<InventorySlot>().textAmountText.text = activeSlot.QuickPanel.GetChild(activeSlot.currentQuickSlotID).GetComponent<InventorySlot>().amountItem.ToString();
        }
    }
    private void ActiveCursor() => Cursor.SetCursor(cursorActive, Vector2.zero, CursorMode.Auto);
    private void DefaultCursor() => Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
}