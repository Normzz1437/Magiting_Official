﻿// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

namespace PixelCrushers.EmeraldAISupport
{

    /// <summary>
    /// Provides a method to freeze and unfreeze the Emerald AI demo player.
    /// </summary>
    public class ControlEmeraldPlayer : MonoBehaviour
    {

        private List<MonoBehaviour> playerBehaviours { get; set; }
        private EmeraldAI.CharacterController.EmeraldAIHideMouse hideMouse { get; set; }
        private Rigidbody playerRigidbody { get; set; }

        private void Awake()
        {
            hideMouse = FindObjectOfType<EmeraldAI.CharacterController.EmeraldAIHideMouse>();
#if EMERALD_AI_3_0_OR_OLDER
            var controller = FindObjectOfType<EmeraldAI.CharacterController.EmeraldAICharacterController>();
            if (controller != null) playerRigidbody = controller.GetComponent<Rigidbody>();
            playerBehaviours = new List<MonoBehaviour>();
            playerBehaviours.Add(hideMouse);
            playerBehaviours.Add(FindObjectOfType<EmeraldAI.CharacterController.EmeraldAIMouseLook>());
            playerBehaviours.Add(controller);
            playerBehaviours.Add(FindObjectOfType<EmeraldAI.CharacterController.PlayerWeapon>());
            playerBehaviours.Add(FindObjectOfType<EmeraldAI.CharacterController.PlayerWeapon3rdPerson>());
            playerBehaviours.RemoveAll(x => x == null);
#endif
        }

        public void SetPlayer(bool active)
        {
#if EMERALD_AI_3_0_OR_OLDER
            foreach (var behaviour in playerBehaviours)
            {
                behaviour.enabled = active;
            }
#endif

            if (hideMouse != null)
            {
                typeof(EmeraldAI.CharacterController.EmeraldAIHideMouse).GetField("MouseToggle", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(hideMouse, active);
                if (!active)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }

#if EMERALD_AI_3_0_OR_OLDER
            if (playerRigidbody != null && !active)
            {
                playerRigidbody.velocity = Vector3.zero;
            }
#endif
        }

    }
}
