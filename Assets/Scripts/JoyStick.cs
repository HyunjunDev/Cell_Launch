using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Image outline;
    private Image handle;
    [HideInInspector]
    public Vector3 inputDir;
    [HideInInspector]
    public bool shoot;
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(outline.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out position))
        {
            position.x = (position.x / outline.rectTransform.sizeDelta.x);
            position.y = (position.y / outline.rectTransform.sizeDelta.y);

            float x = (outline.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
            float y = (outline.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

            inputDir= new Vector3(x, y, 0);
            inputDir = (inputDir.magnitude > 1) ? inputDir.normalized : inputDir;

            handle.rectTransform.anchoredPosition = new Vector3(inputDir.x * (outline.rectTransform.sizeDelta.x / 2.5f),
                inputDir.y * (outline.rectTransform.sizeDelta.y / 2.5f));
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        inputDir = Vector3.zero;
        handle.rectTransform.anchoredPosition = Vector3.zero;
    }
    void Start()
    {
        outline = GetComponent<Image>();
        handle = transform.GetChild(0).GetComponent<Image>();
        inputDir = Vector3.zero;
    }
}
