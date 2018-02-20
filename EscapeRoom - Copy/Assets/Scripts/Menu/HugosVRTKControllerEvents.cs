namespace VRTK.UnityEventHelper
{
    using UnityEngine;
    using UnityEngine.Events;
    using System;

    [AddComponentMenu("VRTK/Scripts/Utilities/Unity Events/VRTK_ControllerEvents_UnityEvents")]
    public sealed class HugosVRTKControllerEvents : VRTK_UnityEvents<VRTK_ControllerEvents>
    {
        [Serializable]
        public sealed class ControllerInteractionEvent : UnityEvent<object, ControllerInteractionEventArgs> { }

        public ControllerInteractionEvent OnButtonTwoPressed = new ControllerInteractionEvent();
        public ControllerInteractionEvent OnButtonTwoReleased = new ControllerInteractionEvent();

        protected override void AddListeners(VRTK_ControllerEvents component)
        {
            component.ButtonTwoPressed += ButtonTwoPressed;
            component.ButtonTwoReleased += ButtonTwoReleased;
#pragma warning disable 0618
#pragma warning restore 0618
        }

        protected override void RemoveListeners(VRTK_ControllerEvents component)
        {
            component.ButtonTwoPressed -= ButtonTwoPressed;
            component.ButtonTwoReleased -= ButtonTwoReleased;
#pragma warning disable 0618
#pragma warning restore 0618
        }
        private void ButtonTwoPressed(object o, ControllerInteractionEventArgs e)
        {
            OnButtonTwoPressed.Invoke(o, e);
        }
        private void ButtonTwoReleased(object o, ControllerInteractionEventArgs e)
        {
            OnButtonTwoReleased.Invoke(o, e);
        }
    }
}