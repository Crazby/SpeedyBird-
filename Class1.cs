using System;
using System.Collections.Generic;
using HarmonyLib;
using BepInEx;
using UnityEngine;
using System.Reflection;
using UnityEngine.XR;

namespace YOURMOD
{
    [BepInPlugin("org.crazbyy.BirbGame.SpeedyBird", "SpeedyBird!", "1.0.0")]

    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            new Harmony("com.SpeedyBird!.BirbGame.SpeedyBird!").PatchAll(Assembly.GetExecutingAssembly());
        }

        [HarmonyPatch(typeof(GorillaLocomotion.Player))]
        [HarmonyPatch("Update", MethodType.Normal)]
        private class YOURMOD

        {
            static float? maxJumpSpeed = null;
            static bool triggerButton;
            private static void Postfix(GorillaLocomotion.Player __instance) //Postfix is better than prefix.
            {
                List<InputDevice> list = new List<InputDevice>();//This gets the inputs of your controller you can change "UnityEngine.XR.InputDeviceCharacteristics.Left" To Right to change the hand
                InputDevices.GetDevicesWithCharacteristics(UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Left | UnityEngine.XR.InputDeviceCharacteristics.Controller, list);
                list[0].TryGetFeatureValue(CommonUsages.triggerButton, out triggerButton); //change this to the button you want to use

                if (triggerButton)
                {

                    __instance.maxJumpSpeed = 50f;
                    __instance.jumpMultiplier = 70f;
                }
                else
                {
                    __instance.maxJumpSpeed = (float)maxJumpSpeed;
                    __instance.jumpMultiplier = 1.5f;
                }
            }
            }
        }
    }
