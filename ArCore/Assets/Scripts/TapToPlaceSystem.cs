using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TapToPlaceSystem : MonoBehaviour
{
    
    [SerializeField]
    private ARRaycastManager arRaycastManager;
    [SerializeField]
    private GameObject placementIndicator;
    [SerializeField]
    private GameObject objectToPlace;

    [SerializeField] private Camera mainCamera;

    [SerializeField] private FurnitureList furnitureList;
    
    private bool IsPlacementValid = false;
    private Pose placementPose;

    #if UNITY_EDITOR
    [Button]
    private void EditorInit()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        placementIndicator = GameObject.Find("PlacementIndicator");  
        mainCamera = Camera.main;
    }
    #endif

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();
        //update placement pose on tap
        if(IsPlacementValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject();
        }
    }

    private void UpdatePlacementIndicator()
    {
        if(IsPlacementValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void PlaceObject()
    {
        //check if the cursor is over UI
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }   
        if (furnitureList.selectedObject == null) return;
        Instantiate(furnitureList.selectedObject, placementPose.position, placementPose.rotation);
    }


    private void UpdatePlacementPose()
    {
        var center = mainCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        
        arRaycastManager.Raycast(center, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);
        IsPlacementValid = hits.Count > 0;
       
        print(IsPlacementValid);
        
        if(!IsPlacementValid) return;

        placementPose = hits[0].pose;
        var cameraForward = mainCamera.transform.forward;
        var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
        placementPose.rotation = Quaternion.LookRotation(cameraBearing);
    }
    
    
    
}
