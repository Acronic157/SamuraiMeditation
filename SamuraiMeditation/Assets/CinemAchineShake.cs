using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineMachineShake : MonoBehaviour
{
    public static CineMachineShake Instance {  get; private set; }
    private CinemachineVirtualCamera virtualCamera;
    private float ShakeTimer;

    private void Awake()
    {
        Instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakaCamera(float intensity,float Time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineperlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineperlin.m_AmplitudeGain = intensity;
        ShakeTimer = Time;
    }

    private void Update()
    {
        if(ShakeTimer > 0)
        {
         ShakeTimer -=Time.deltaTime;
            if(ShakeTimer <= 0f )
            {
                CinemachineBasicMultiChannelPerlin cinemachineperlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineperlin.m_AmplitudeGain = 0f;
            }

        }


    }
}
