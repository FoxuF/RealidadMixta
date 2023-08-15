using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class FaceExample : MonoBehaviour
{
    public Transform headTransform;
    public Text textDebug;
    public Transform leftEyeTransform;
    public Transform rightEyeTransform;
    public ARFace face;
    public ARFaceManager faceManager;

    private void OnEnable()
    {
        if (faceManager.subsystem.subsystemDescriptor.supportsEyeTracking)
        {
            face.updated += ARFaceUpdated;
        }

        textDebug.text = faceManager.subsystem.subsystemDescriptor.supportsEyeTracking.ToString();
    }

    private void ARFaceUpdated(ARFaceUpdatedEventArgs obj)
    {
        if (face.leftEye!=null)
        {
            leftEyeTransform.gameObject.SetActive(true);
            leftEyeTransform.SetParent(face.leftEye);
        }
        
        if (face.rightEye!=null)
        {
            rightEyeTransform.gameObject.SetActive(true);
            rightEyeTransform.SetParent(face.rightEye);
        }
        
    }

    private void OnDisable()
    {
        face.updated -= ARFaceUpdated;
        leftEyeTransform.gameObject.SetActive(false);
        rightEyeTransform.gameObject.SetActive(false);
    }

    private void Update()
    {
        //if (faceManager.subsystem.subsystemDescriptor.supportsEyeTracking)
            textDebug.text = face.transform.position.ToString();
        headTransform.SetPositionAndRotation(face.transform.position,face.transform.rotation);

        
    }

}
