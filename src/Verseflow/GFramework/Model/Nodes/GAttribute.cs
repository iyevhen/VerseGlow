using System;

namespace VerseFlow.GFramework.Model.Nodes
{
    /// <summary>
    /// An attribute is a special node which stores information about its owner element.
    /// </summary>
    public abstract class GAttribute : GNode
    {
        #region Constructor

        public GAttribute()
        {
        }

        #endregion

        #region Protected Overrides

        protected internal override void OnParentChanged(GElement parent)
        {
            base.OnParentChanged(parent);

            m_Owner = parent as GElement;
        }
        protected override void OnPropertyValueChanged(int propertyKey)
        {
            if (m_Owner != null)
            {
                m_Owner.OnAttributePropertyValueChanged(this, propertyKey);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the GElement instance that owns this attribute.
        /// </summary>
        public GElement Owner
        {
            get
            {
                return m_Owner;
            }
        }

        #endregion

        #region Fields

        [NonSerialized]
        internal GElement m_Owner;

        #endregion
    }
}
