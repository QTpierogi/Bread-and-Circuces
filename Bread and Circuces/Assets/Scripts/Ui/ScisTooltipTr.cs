using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScisTooltipTr : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (MenuManager.chosen.CompareTag("Scissor"))
        {
            TooltipSystem.Show("������: � ���� ������ ����� ����������� ����� ��������� ������. ����� ����� �������� + 1 � �����. �� ����� ���������� � ��������� ������", "��������");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();
    }
}
