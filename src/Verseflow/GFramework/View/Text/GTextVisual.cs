using VerseFlow.GFramework.Model.Text;

namespace VerseFlow.GFramework.View.Text
{
	public abstract class GTextVisual : GInputElement
	{
		internal const ulong StateNeedLayout = StateHasUnmanagedResources << 1;

		internal const int GTextVisualLastPropKey = GInputElementLastPropKey;

		protected GTextVisual()
		{
			//no need of additional notification from children since everything is dynamically evaluated
			children.m_PreProcessCollectionChange = false;
			children.m_PostProcessCollectionChange = false;

			bitStates[StateNeedLayout] = true;
		}

		public bool IsLaidOut
		{
			get { return bitStates[StateNeedLayout] == false; }
		}

		/// <summary>
		///     Marks the element as 'dirty' - needs re-evaluation of the cached information.
		/// </summary>
		public virtual void InvalidateLayout()
		{
			bitStates[StateNeedLayout] = true;
		}

		public virtual void Layout(GTextViewLayoutContext context)
		{
			if (bitStates[StateNeedLayout])
			{
				LayoutCore(context);
				bitStates[StateNeedLayout] = false;
			}
		}

		public virtual void InitFromTextElement(GTextElement textElement)
		{
		}

		/// <summary>
		///     Performs the core measure logic.
		/// </summary>
		/// <param name="context"></param>
		protected virtual void LayoutCore(GTextViewLayoutContext context)
		{
		}

		protected override void PaintChildren(GPaintContext context)
		{
			var textContext = (GTextViewPaintContext) context;
			int count = children.Count;
			GTextVisual child;

			for (int i = 0; i < count; i++)
			{
				if (textContext.LineStart >= textContext.ViewBounds.Bottom)
				{
					break;
				}

				child = children[i] as GTextVisual;
				if (child != null)
				{
					child.Paint(context);
				}
			}
		}
	}
}