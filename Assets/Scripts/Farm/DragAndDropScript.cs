using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropScript : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler 
{
    [SerializeField] private Canvas canvas;

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    Vector3 startTransform;
    public static string nameOfObject;
    public static GameObject g;
    public static DragAndDropScript ds { get; set; }
    void Start()
    {
        ds = this;
        string nameTemp = gameObject.name;
        gameObject.transform.GetChild(0).GetComponent<Text>().text = $":{SeedInvent.seedInventItemsCountDict[nameTemp]}";

        startTransform = GetComponent<RectTransform>().anchoredPosition;
    }

    public void Awake ()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        string nameTemp = gameObject.name;
        gameObject.transform.GetChild(0).GetComponent<Text>().text = $":{SeedInvent.seedInventItemsCountDict[nameTemp]}";
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        g = gameObject;
        nameOfObject = canvasGroup.gameObject.name;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }
    public static void UpdateFarm()
    {
        g.transform.GetChild(0).GetComponent<Text>().text = $":{SeedInvent.seedInventItemsCountDict[g.name]}";
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor ;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = startTransform;
    }

    public void OnPointerDown (PointerEventData eventData)
    {

    }

}
