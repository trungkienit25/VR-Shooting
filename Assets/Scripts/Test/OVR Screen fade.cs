//using System;
//using System.Collections;
//using System.Collections.Generic;
//using Unity.XR.PXR;
//using Unity.XR.PXR.Input;
//using UnityEngine;

//public class OVRScreenfade : MonoBehaviour
//{
//    public void DeathHandler()
//    {
//        StartCoroutine(DeathSequence());
//    }

//    private IEnumerator DeathSequence()
//    {
//        //fade cam
//        PXR_ScreenFade.FadeOut();
//        while(PXR_ScreenFade.currentAlpha < 0.9f)
//        {
//            yield return new WaitForEndOfFrame;
//        }
//        //respawn
//        PXR_Controller.gameObject.SetActive(false);
//        yield return new WaitForEndOfFrame();
//        var thistransform = PXR_Controller.transform;
//        thistransform.position = playerRespawnPoint.position;
//        thistransform.rotation = playerRespawnPoint.rotation;
//        DamageableObjectInstance.ResetDamage();
//        DamageableObjectInstance.ReceiveDamage(0f);
//        PXR_Controller.gameObject.SetActive(true);

//        //fade in
//        PXR_ScreenFade.FadeIn();
//        Debug.Log("player dead");

//    }
//}
