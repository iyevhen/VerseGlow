using VerseFlow.GFramework.Model.Nodes;

namespace VerseFlow.GFramework.Model.Collections
{
    public class GNodeCollection : GNodeCollectionBase
    {
	    public GNodeCollection(GElement ownerElement) : base(ownerElement)
        {
        }

	    public void Add(GNode node)
        {
            AddInternal(node);
        }
        public void AddRange(GNode[] nodes)
        {
            AddRangeInternal(nodes);
        }
        public void Insert(int index, GNode node)
        {
            InsertInternal(index, node);
        }
        public void Remove(GNode node)
        {
            RemoveInternal(node);
        }
        public void RemoveAt(int index)
        {
            RemoveAtInternal(index);
        }
        public void Clear()
        {
            ClearInternal();
        }
    }
}
