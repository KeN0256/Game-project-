using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ItemInventory : MonoBehaviour, IDragHandler, IBeginDragHandler,IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    //public Image Swap;
    public bool enable = false;
    //public float speed = 10;
    GameObject swap;
    public GameObject Inventory;
    public Item item;
    /*void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/


    public void OnDrag(PointerEventData eventData)
    {
        //swap.GetComponent<RectTransform>().transform.position = eventData.pointerCurrentRaycast.screenPosition;
        if(swap!=null)
        swap.GetComponent<RectTransform>().transform.position = new Vector2(eventData.pointerCurrentRaycast.screenPosition.x-20, eventData.pointerCurrentRaycast.screenPosition.y-20) ;
    }
    public void OnBeginDrag(PointerEventData data)
    {
        if (!Inventory.GetComponent<Inventory>().IsEmpity(gameObject.name))
        {
            CreateSwapObj();
        }
        
    }
    void CreateSwapObj() 
    {
        swap = new GameObject();
        swap.name = "SwapItem";
        swap.AddComponent<CanvasRenderer>();
        swap.AddComponent<RectTransform>();
        swap.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        swap.GetComponent<RectTransform>().sizeDelta = new Vector2(30, 30);
        Image mImage = swap.AddComponent<Image>();
        mImage.sprite = GetComponent<Image>().sprite;
        swap.transform.position = new Vector3(0, 0, 0);
        swap.transform.SetParent(transform.parent.transform.parent.transform.parent.transform);
        swap.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
        swap.AddComponent<CanvasScaler>();
    }
    public void SetInventory(GameObject inv) 
    {
        Inventory = inv;
    }

    public void OnEndDrag(PointerEventData eventData) //В этом слоте посылаем себя как то что должно быть перемещено в свап обджект
    {
        if (swap != null)
        {
            Destroy(swap);
            Inventory.GetComponent<Inventory>().MoveToCurrentSlot(gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) //Я и есть свап обджект и я не тот что в OnEndDrag
    {
        //Debug.Log("Я:" + name + "Должен свапнуться с: " + EventSystem.current.currentSelectedGameObject);
       
        Inventory.GetComponent<Inventory>().SetSwapObject(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Inventory.GetComponent<Inventory>().SetSwapObject(null);
    }

}
