using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace VerseFlow.UI.Controls
{
	[PermissionSet(SecurityAction.LinkDemand, Unrestricted = true)]
	[PermissionSet(SecurityAction.InheritanceDemand, Unrestricted = true)]
	public class RoundCornersEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}

		public override Object EditValue(ITypeDescriptorContext context, IServiceProvider provider, Object value)
		{
			if (value.GetType() != typeof(Corners))
				return value;

			var edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

			Corners cornerFlags = Corners.None;

			if (edSvc != null)
			{
				using (var lb = new CheckedListBox
				{
					BorderStyle = BorderStyle.None,
					CheckOnClick = true
				})
				{
					var instance = (IHaveRoundCorners)context.Instance;

					lb.Items.Add((object) "TopLeft", (bool) ((instance.RoundCorners & Corners.TopLeft) == Corners.TopLeft));
					lb.Items.Add((object) "TopRight", (bool) ((instance.RoundCorners & Corners.TopRight) == Corners.TopRight));
					lb.Items.Add((object) "BottomLeft", (bool) ((instance.RoundCorners & Corners.BottomLeft) == Corners.BottomLeft));
					lb.Items.Add((object) "BottomRight", (bool) ((instance.RoundCorners & Corners.BottomRight) == Corners.BottomRight));

					edSvc.DropDownControl(lb);

					foreach (object o in lb.CheckedItems)
					{
						cornerFlags = cornerFlags | (Corners)Enum.Parse(typeof(Corners), o.ToString(), true);
					}

				}
				edSvc.CloseDropDown();
				return cornerFlags;
			}

			return value;
		}
	}
}