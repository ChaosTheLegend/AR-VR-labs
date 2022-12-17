using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureItemController : MonoBehaviour
{
    private static int ItemCount = 0;
    
    private GameObject furnitureInstance;
    private int id;

    public int Id => id;
    [SerializeField]
    private TextMeshProUGUI furnitureNameText;

    private FurnitureList controller;
    public Action<GameObject> OnItemSelected;

    private GameObject furniturePrefab;
    [SerializeField] private GameObject furnitureParent;
    [SerializeField] private RawImage furnitureImage;
    [SerializeField] private Camera furnitureCamera;

    [SerializeField] private Button selectButton;
    // Start is called before the first frame update
    public void Init(GameObject FurniturePrefab, FurnitureList controller)
    {
        this.controller = controller;
        controller.OnFurnitureSelected += OnSelect;
        id = ItemCount++;
        furniturePrefab = FurniturePrefab;
        furnitureParent.transform.position = new Vector3(1000*(id+1), 1000*(id+1), 1000*(id+1)); 
        
        furnitureInstance = Instantiate(FurniturePrefab, furnitureParent.transform);
        var TempTexture = RenderTexture.GetTemporary(512, 512, 16, RenderTextureFormat.ARGB32);
        furnitureCamera.targetTexture = TempTexture;
        furnitureImage.texture = TempTexture;
        furnitureCamera.Render();
        furnitureNameText.text = FurniturePrefab.name;
    }


    public void Select()
    {
        OnItemSelected?.Invoke(furniturePrefab);
    }

    private void OnSelect(int id)
    {
        selectButton.interactable = id != this.id;
    }
}
