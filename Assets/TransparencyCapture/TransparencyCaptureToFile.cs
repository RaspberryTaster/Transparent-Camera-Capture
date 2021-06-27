using System;
using System.Collections;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class TransparencyCaptureToFile : MonoBehaviour
{
    public Camera[] cameras = new Camera[0];
    public bool CaptureOnPlay;
	private void Awake()
	{
        cameras = GetComponentsInChildren<Camera>(true);
	}

	private void Start()
	{
	    if(CaptureOnPlay)
		{
            IterateThroughCameras();
		}
	}

	public IEnumerator Capture(int index,string pictureName, string pathDirectory)
    {
        yield return new WaitForEndOfFrame();
        SetCameras(index);
        //After Unity4,you have to do this function after WaitForEndOfFrame in Coroutine
        //Or you will get the error:"ReadPixels was called to read pixels from system frame buffer, while not inside drawing frame"
        zzTransparencyCapture.ProcessScreenShots(pictureName, pathDirectory);
    }


    public void IterateThroughCameras()
	{
        int length = cameras.Length;
        string folderPath = Application.dataPath + "/Pictures";
        folderPath = Path.Combine(folderPath, Path.GetRandomFileName());
        Directory.CreateDirectory(folderPath);

        for (int i = 0; i < length; i++)
		{
            StartCoroutine(Capture(i, i.ToString(), folderPath));
        }
	}
    public void SetCameras(int index)
	{
        Camera active = cameras[0];
        active.gameObject.SetActive(true);
        for(int i = 0; i < cameras.Length; i++)
		{
            if(i == index)
			{

                if(index != 0)
				{
                    cameras[i].gameObject.SetActive(true);
                    active.gameObject.SetActive(false);
                    active = cameras[i];
                }

            }
            else
			{
                cameras[i].gameObject.SetActive(false);
            }

        }
	}

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            IterateThroughCameras();
    }
}