using System.Drawing;
using VerseFlow.GFramework.Events;
using VerseFlow.GFramework.Model;
using VerseFlow.GFramework.Model.Nodes;
using VerseFlow.GFramework.View.Events;

namespace VerseFlow.GFramework.View
{
    /// <summary>
    /// Represents a visual element which may receive user input.
    /// </summary>
    public abstract class GInputElement : GVisualElement
    {
        #region Public Overridables

        public virtual void OnMouseEvent(GEventArgs args)
        {
            GMouseEventData mouseData = args.m_Data as GMouseEventData;
            if (mouseData == null)
            {
                return;
            }

            switch (mouseData.m_Event)
            {
                case MouseEvent.ButtonDown:
                    OnMouseDown(args, mouseData);
                    break;
                case MouseEvent.ButtonUp:
                    OnMouseUp(args, mouseData);
                    break;
                case MouseEvent.ButtonClick:
                    OnMouseClick(args, mouseData);
                    break;
                case MouseEvent.Enter:
                    OnMouseEnter(args, mouseData);
                    break;
                case MouseEvent.Leave:
                    OnMouseLeave(args, mouseData);
                    break;
                case MouseEvent.Hover:
                    OnMouseHover(args, mouseData);
                    break;
                case MouseEvent.Move:
                    OnMouseMove(args, mouseData);
                    break;
                case MouseEvent.Wheel:
                    OnMouseWheel(args, mouseData);
                    break;
            }
        }
        public virtual void PreviewMouseEvent(GEventArgs args)
        {
            GMouseEventData mouseData = args.m_Data as GMouseEventData;
            if (mouseData == null)
            {
                args.m_Result = EventResult.Cancel;
                return;
            }

            if (WantsMouseEvent(mouseData))
            {
                args.m_Result = EventResult.Process;
            }
        }
        public virtual GVisualElement ChildFromPoint(PointF point, bool nestedChildren)
        {
            int count = children.Count;
            GVisualElement visualChild;

            for (int i = 0; i < count; i++)
            {
                GNode child = children[i];

                if (nestedChildren)
                {
                    GInputElement inputChild = child as GInputElement;
                    if (inputChild != null)
                    {
                        visualChild = inputChild.ChildFromPoint(point, nestedChildren);
                        if (visualChild != null)
                        {
                            return visualChild;
                        }
                    }
                }

                visualChild = child as GVisualElement;
                if (visualChild != null && visualChild.HitTest(point))
                {
                    return visualChild;
                }
            }

            return null;
        }

        #endregion

        #region Protected Overridables

        protected virtual bool WantsMouseEvent(GMouseEventData mouseData)
        {
            return false;
        }
        protected virtual void OnMouseDown(GEventArgs args, GMouseEventData mouseData)
        {
            SetMouseState(InputElementMouseState.Pressed);
        }
        protected virtual void OnMouseUp(GEventArgs args, GMouseEventData mouseData)
        {
            InputElementMouseState state = HitTest(mouseData.m_HitPoint) ? InputElementMouseState.Hot : InputElementMouseState.None;
            SetMouseState(state);
        }
        protected virtual void OnMouseClick(GEventArgs args, GMouseEventData mouseData)
        {
        }
        protected virtual void OnMouseEnter(GEventArgs args, GMouseEventData mouseData)
        {
            SetMouseState(InputElementMouseState.Hot);
        }
        protected virtual void OnMouseLeave(GEventArgs args, GMouseEventData mouseData)
        {
            SetMouseState(InputElementMouseState.None);
        }
        protected virtual void OnMouseHover(GEventArgs args, GMouseEventData mouseData)
        {
        }
        protected virtual void OnMouseMove(GEventArgs args, GMouseEventData mouseData)
        {
        }
        protected virtual void OnMouseWheel(GEventArgs args, GMouseEventData mouseData)
        {
        }

        protected virtual void SetMouseState(InputElementMouseState state)
        {
            if (m_MouseState == state)
            {
                return;
            }

            m_MouseState = state;
            OnMouseStateChanged();
        }

        protected virtual void OnMouseStateChanged()
        {
        }

        #endregion

        #region Public Overrides

	    protected override object GetDefaultPropertyValue(int propertyKey)
        {
            switch (propertyKey)
            {
                case EnabledPropertyKey:
                    return true;
                case CursorPropertyKey:
                    return PredefinedCursors.Default;
            }

            return base.GetDefaultPropertyValue(propertyKey);
        }

        #endregion

        #region Properties

        public virtual bool Enabled
        {
            get
            {
                GInputElement parent = ((GNode) this).parent as GInputElement;
                if (parent != null && parent.Enabled == false)
                {
                    return false;
                }

                return (bool)GetPropertyValue(EnabledPropertyKey);
            }
            set
            {
                if (Enabled == value)
                {
                    return;
                }

                SetPropertyValue(EnabledPropertyKey, value);
            }
        }
        /// <summary>
        /// Gets or sets the cursor to be displayed when the mouse hovers this element.
        /// </summary>
        public PredefinedCursors Cursor
        {
            get
            {
                return (PredefinedCursors)GetPropertyValue(CursorPropertyKey);
            }
            set
            {
                if (Cursor == value)
                {
                    return;
                }

                SetPropertyValue(CursorPropertyKey, value);
            }
        }

        #endregion

        #region Fields

        internal InputElementMouseState m_MouseState;

        #endregion

        #region Property Constants

        public const int EnabledPropertyKey = VisiblePropertyKey + 1;
        public const int CursorPropertyKey = EnabledPropertyKey + 1;

        internal const int GInputElementLastPropKey = CursorPropertyKey;

        #endregion

        #region Event Constants

        public const int MouseEventKey = GVisualElement.GVisualElementLastEventKey + 1;

        internal const int GInputElementLastEventKey = MouseEventKey + DefaultEventRange;

        #endregion
    }
}