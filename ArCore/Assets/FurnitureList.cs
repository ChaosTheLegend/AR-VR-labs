using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureList : MonoBehaviour
{
    [SerializeField] private List<GameObject> furnitureList;
    [SerializeField] private GameObject itemParent;
    [SerializeField] private FurnitureItemController itemPrefab;

    public GameObject selectedObject;
    public Action<int> OnFurnitureSelected;

    private void Start()
    {
        foreach (var item in furnitureList)
        {
            var itemController = Instantiate(itemPrefab, itemParent.transform);
            itemController.Init(item, this);
            itemController.OnItemSelected += (gm =>
            {
                selectedObject = gm;
                OnFurnitureSelected?.Invoke(itemController.Id);
            });
        }
        
        LayoutRebuilder.ForceRebuildLayoutImmediate(itemParent.GetComponent<RectTransform>());
    }
}
