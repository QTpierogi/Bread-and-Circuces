using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DefaultTooltipTr : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string header;
    public string content;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (MenuManager.chosen == null)
        {
            TooltipSystem.Show(content, header);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();
    }
}
