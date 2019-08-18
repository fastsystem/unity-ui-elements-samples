using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UIElements;


namespace MyControls
{
    internal class RedButton : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<RedButton, UxmlTraits> { }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            UxmlStringAttributeDescription m_Text = 
                new UxmlStringAttributeDescription { name = "text", defaultValue = "none label" };

            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
            {
                get { yield break; }
            }

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var text = m_Text.GetValueFromBag(bag, cc);
                ((RedButton)ve).Init(text);
            }
        }

        private Button m_button;

        public string text
        {
            get { return m_button.text; }
            set { m_button.text = value; }
        }

        public event Action<EventBase> clicked;

        public RedButton()
        {
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/Components/RedButton.uss");
            styleSheets.Add(styleSheet);

            m_button = new Button();
            m_button.text = "noen label";
            m_button.clickable.clickedWithEventInfo += Button_Clicked;
            hierarchy.Add(m_button);
        }

        public RedButton(string text) : this()
        {
            Init(text);
        }

        public void Init(string text)
        {
            this.text = text;
        }

        private void Button_Clicked(EventBase eb)
        {
            eb.target = this;
            clicked?.Invoke(eb);
        }
    }
}
