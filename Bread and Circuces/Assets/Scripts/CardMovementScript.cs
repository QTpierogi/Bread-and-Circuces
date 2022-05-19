using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovementScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    public CardController CC;

    Camera MainCamera;
    Vector3 offset;
    public Transform DefaultParent;
    public bool IsDraggable;
    public bool IsClickable;
    public bool CanBePlayed;
    private bool selected;

    void Awake()
    {
        MainCamera = Camera.allCameras[0];
        IsClickable = false;
        selected = false;
        CanBePlayed = false;
    }

    public void OnBeginDrag(PointerEventData eventData) //��� ������ ������ ������� ������-��������� ��� ��� ������ ������(�� ���� ����� �������� �� ���� ����)
    {
        if (IsClickable)
            return;
        offset = transform.position - MainCamera.WorldToScreenPoint(eventData.position); // ������ � ���� �������� ������� ������ ����� �� ����� ����� �� ������� ������(��� ����� ����� ����� ��������� )
        DefaultParent = transform.parent;

        transform.SetParent(DefaultParent.parent);

        IsDraggable = GameManagerScript.Instance.IsPlayerTurn &&
                     DefaultParent.GetComponent<DropPlaceScript>().Type == FieldType.SelfHand &&
                     CanBePlayed;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        if (!IsDraggable)
            return;
    }

    public void OnDrag(PointerEventData eventData) //����� �������� ��� ����� ���� �� ������� �����
    {
        if (!IsDraggable)
            return;

        Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position);
        newPos.z = 0;
        transform.position = newPos; //����������� ������� ������� �����
    }

    public void OnEndDrag(PointerEventData eventData) //��� ������ �������� ������-��������� ��� ��� ������ ������(�� ���� ����� �������� �� ���� ����)
    {
        if(!IsDraggable)
            return;

        transform.SetParent(DefaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!IsClickable)
            return;
        var discardWindow = FindObjectOfType<DiscardWindow>();
        Debug.Log("Card clicked");
        if (selected)
            discardWindow.DeselectCard(gameObject);
        else discardWindow.SelectCard(gameObject);
    }
}
