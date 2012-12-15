using VerseFlow.GFramework.Events;
using VerseFlow.GFramework.Model.Collections;

namespace VerseFlow.GFramework.Model.Nodes
{
    /// <summary>
    /// The element is a node which may have child elements.
    /// </summary>
    public class GElement : GNode
    {
        #region Constructor

        public GElement()
        {
            children = new GNodeCollection(this);
            m_Attributes = new GAttributeCollection(this);
        }

        #endregion

        #region Public Overridables

        public virtual bool CanAcceptChild(GNode child)
        {
            return true;
        }
        public virtual bool CanRemoveChild(GNode child)
        {
            return true;
        }

        #endregion

        #region Protected Overridables

        protected internal virtual void OnCollectionNotification(GEventArgs e)
        {
            GCollectionEventData data = (GCollectionEventData)e.m_Data;

            switch (data.m_Notification)
            {
                case CollectionNotification.ElementAdding:
                case CollectionNotification.ElementInserting:
                    if (CanAcceptChild((GNode)data.m_Element) == false)
                    {
                        e.m_Result |= EventResult.Cancel;
                    }
                    break;

                case CollectionNotification.ElementRemoving:
                    if (CanRemoveChild((GNode)data.m_Element) == false)
                    {
                        e.m_Result |= EventResult.Cancel;
                    }
                    break;

                case CollectionNotification.ElementAdded:
                case CollectionNotification.ElementInserted:
                    if (e.m_Originator == children)
                    {
                        OnChildAdded(data.m_Element);
                    }
                    else
                    {
                        OnAttributeAdded(data.m_Element);
                    }
                    break;
                case CollectionNotification.ElementRemoved:
                    break;
            }
        }
        protected internal virtual void OnAttributePropertyValueChanged(GAttribute sender, int propertyKey)
        {
        }
        protected virtual void AddAttribute(GAttribute attribute)
        {
            m_Attributes.AddInternal(attribute);
        }
        protected virtual void OnChildAdded(object child)
        {
        }
        protected virtual void OnAttributeAdded(object attribute)
        {
        }

        #endregion

        #region Protected Overrides

        protected internal override void SetRoot(GRootElement root)
        {
            base.SetRoot(root);

            int count = children.Count;
            for (int i = 0; i < count; i++)
            {
                children[i].SetRoot(root);
            }
        }
        protected internal override void TunnelEvent(GEventArgs e)
        {
            base.TunnelEvent(e);

            e.m_Sender = this;
            int count = children.Count;
            GNode node;

            for (int i = 0; i < count; i++)
            {
                node = children[i];
                node.OnTunnelEvent(e);
            }
        }

        #endregion

        #region Properties

        public GNodeCollection Children
        {
            get
            {
                return children;
            }
        }
        public GAttributeCollection Attributes
        {
            get
            {
                return m_Attributes;
            }
        }

        #endregion

        #region Fields

        internal GNodeCollection children;
        internal GAttributeCollection m_Attributes;

        #endregion

        #region Event Constants

        public const int CollectionNotificationEventKey = GDisposableObjectLastEventKey + 1;

        internal const int GElementLastEventKey = CollectionNotificationEventKey + DefaultEventRange;

        #endregion
    }
}
