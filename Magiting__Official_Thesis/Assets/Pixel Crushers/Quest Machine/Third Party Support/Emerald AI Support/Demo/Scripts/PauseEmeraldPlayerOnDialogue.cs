// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;
using EmeraldAI.CharacterController;

namespace PixelCrushers.QuestMachine.EmeraldAISupport
{
	/// <summary>
	/// Demo script that pauses the demo player during Quest Machine dialogue.
	/// </summary>
	public class PauseEmeraldPlayerOnDialogue : MonoBehaviour, IMessageHandler
	{

#if EMERALD_AI_3_0_OR_OLDER
		private void Awake()
		{
			MessageSystem.AddListener(this, "Pause Player", string.Empty);
			MessageSystem.AddListener(this, "Unpause Player", string.Empty);
		}

		public void OnMessage(MessageArgs messageArgs)
		{
			if (messageArgs.message == "Pause Player")
			{
				GetComponent<EmeraldAICharacterControllerTopDown>().enabled = false;
			}
			else if (messageArgs.message == "Unpause Player")
			{
				GetComponent<EmeraldAICharacterControllerTopDown>().enabled = true;
			}
		}
#else
		public void OnMessage(MessageArgs messageArgs) { }
#endif
	}
}
