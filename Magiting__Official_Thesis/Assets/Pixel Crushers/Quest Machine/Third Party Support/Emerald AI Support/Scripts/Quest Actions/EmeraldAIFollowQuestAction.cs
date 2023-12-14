// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;
using PixelCrushers.EmeraldAISupport;

namespace PixelCrushers.QuestMachine.EmeraldAISupport
{

    /// <summary>
    /// Tells Emerald AIs of a specific faction to follow or stay.
    /// </summary>
    public class EmeraldAIFollowQuestAction : QuestAction
    {

        public enum FollowAction { Follow, Stay }

        public enum FollowAs { Companion, Pet }

        [EmeraldAIFaction]
        [SerializeField]
        private int m_faction;

        [SerializeField]
        private FollowAction m_followAction = FollowAction.Follow;

        [SerializeField]
        private FollowAs m_followAs = FollowAs.Companion;

        [SerializeField]
        private StringField m_followTarget = new StringField();

        public int faction
        {
            get { return m_faction; }
            set { m_faction = value; }
        }

        public FollowAction followAction
        {
            get { return m_followAction; }
            set { m_followAction = value; }
        }

        public FollowAs followAs
        {
            get { return m_followAs; }
            set { m_followAs = value; }
        }

        public StringField followTarget
        {
            get { return m_followTarget; }
            set { m_followTarget = value; }
        }

        public override void Execute()
        {
            base.Execute();
            EmeraldAIUtility.ApplyToFaction(faction, Follow);
        }

        private void Follow(EmeraldAI.EmeraldAISystem ai)
        {
            if (ai == null) return;
            switch (followAction)
            {
                case FollowAction.Follow:
                    if (StringField.IsNullOrEmpty(followTarget))
                    {
                        if (QuestMachine.debug) Debug.Log("Quest Machine: Emerald AI " + ai.name + " following current target.", ai);
                    }
                    else
                    {
                        var go = QuestMachineMessages.FindGameObjectWithID(followTarget);
                        if (go == null)
                        {
                            if (QuestMachine.debug || Debug.isDebugBuild) Debug.LogWarning("Quest Machine: Emerald AI " + ai.name + " can't find target with ID/name '" + followTarget + "'.", ai);
                            return;
                        }
                        else
                        {
                            if (QuestMachine.debug) Debug.Log("Quest Machine: Emerald AI " + ai.name + " following new target '" + followTarget + " as " + followAs + "'.", ai);
                            ai.BehaviorRef = (followAs == FollowAs.Companion) ? EmeraldAI.EmeraldAISystem.CurrentBehavior.Companion : EmeraldAI.EmeraldAISystem.CurrentBehavior.Pet;
                            ai.EmeraldEventsManagerComponent.SetFollowerTarget(go.transform);
                        }
                    }
                    ai.EmeraldEventsManagerComponent.ResumeFollowing();
                    break;
                case FollowAction.Stay:
                    if (QuestMachine.debug) Debug.Log("Quest Machine: Emerald AI " + ai.name + " stay (stop following).", ai);
                    ai.EmeraldEventsManagerComponent.StopFollowing();
                    break;
            }
        }

        public override string GetEditorName()
        {
            switch (followAction)
            {
                case FollowAction.Follow:
                    return "Emerald AI follow " + (StringField.IsNullOrEmpty(followTarget) ? "current follow target" : followTarget.value);
                case FollowAction.Stay:
                    return "Emerald AI stay (stop following)";
                default:
                    return base.GetEditorName();
            }            
        }

    }
}
