// Copyright © Pixel Crushers. All rights reserved.

using PixelCrushers.EmeraldAISupport;
using UnityEngine;

namespace PixelCrushers.QuestMachine.EmeraldAISupport
{

    /// <summary>
    /// Makes all Emerald AIs belonging to a specified faction play an emote animation and/or sound effect.
    /// </summary>
    public class EmeraldAIEmoteQuestAction : QuestAction
    {

        [EmeraldAIFaction]
        [SerializeField]
        private int m_faction;

        [SerializeField]
        private bool m_playSound = false;

        [SerializeField]
        private int m_soundEffectID;

        [SerializeField]
        private bool m_playAnimation = false;

        [SerializeField]
        private int m_animationID;

        public enum AnimationMode { Play, Loop, Stop }

        [SerializeField]
        private AnimationMode m_animationMode = AnimationMode.Play;

        public int faction
        {
            get { return m_faction; }
            set { m_faction = value; }
        }

        public bool playSound
        {
            get { return m_playSound; }
            set { m_playSound = value; }
        }

        public int soundEffectID
        {
            get { return m_soundEffectID; }
            set { m_soundEffectID = value; }
        }

        public bool playAnimation
        {
            get { return m_playAnimation; }
            set { m_playAnimation = value; }
        }

        public int animationID
        {
            get { return m_animationID; }
            set { m_animationID = value; }
        }

        public AnimationMode animationMode
        {
            get { return m_animationMode; }
            set { m_animationMode = value; }
        }

        public override void Execute()
        {
            base.Execute();
            EmeraldAIUtility.ApplyToFaction(faction, Emote);
        }

        private void Emote(EmeraldAI.EmeraldAISystem ai)
        {
            if (ai == null) return;
            if (QuestMachine.debug) Debug.Log("Quest Machine: " + GetEditorName() + ".", ai);
            if (playSound) ai.EmeraldEventsManagerComponent.PlaySoundEffect(soundEffectID);
            if (playAnimation)
            {
                switch (animationMode)
                {
                    case AnimationMode.Play:
                        ai.EmeraldEventsManagerComponent.PlayEmoteAnimation(animationID);
                        break;
                    case AnimationMode.Loop:
                        ai.EmeraldEventsManagerComponent.LoopEmoteAnimation(animationID);
                        break;
                    case AnimationMode.Stop:
                        ai.EmeraldEventsManagerComponent.StopLoopEmoteAnimation(animationID);
                        break;
                }
            }
        }

        public override string GetEditorName()
        {
            if (playSound && playAnimation) return "Play Emerald AI sound " + soundEffectID + " & animation " + animationID;
            else if (playSound) return "Play Emerald AI sound " + soundEffectID;
            else if (playAnimation) return "Play Emerald AI animation " + animationID;
            else return "Play Emerald AI sound/animation (not configured yet)";
        }

    }
}
