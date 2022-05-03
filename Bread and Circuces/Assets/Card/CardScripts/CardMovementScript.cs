using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovementScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public CardController CC;

    Camera MainCamera;
    Vector3 offset;
    public Transform DefaultParent;

    void Awake()
    {
        MainCamera = Camera.allCameras[0];
    }
    public void OnBeginDrag(PointerEventData eventData) //��� ������ ������ ������� ������-��������� ��� ��� ������ ������(�� ���� ����� �������� �� ���� ����)
    {
        offset = transform.position - MainCamera.WorldToScreenPoint(eventData.position); // ������ � ���� �������� ������� ������ ����� �� ����� ����� �� ������� ������(��� ����� ����� ����� ��������� )
        DefaultParent = transform.parent;
        transform.SetParent(DefaultParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) //����� �������� ��� ����� ���� �� ������� �����
    {
        Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position);
        newPos.z = 0;
        transform.position = newPos; //����������� ������� ������� �����
    }

    public void OnEndDrag(PointerEventData eventData) //��� ������ �������� ������-��������� ��� ��� ������ ������(�� ���� ����� �������� �� ���� ����)
    {
        transform.SetParent(DefaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
