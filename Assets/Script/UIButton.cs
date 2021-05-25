using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    public bool click;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        click = true;
    }
}
