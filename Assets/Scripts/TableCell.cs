using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TableCell : MonoBehaviour, IDropHandler
{
    [SerializeField] private Block blockInside;
    public UnityEvent onBlockInsert;

    private Block _currentBlockInside;
    private RectTransform _rectTransform;
    
    public bool IsFilled => _currentBlockInside;

    private void Awake()
    {
        _currentBlockInside = blockInside;
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;
        if (IsFilled) return;

        eventData.pointerDrag.GetComponent<RectTransform>().position = _rectTransform.position;
        
        onBlockInsert.Invoke();
    }
}
