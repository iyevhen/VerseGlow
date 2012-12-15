using VerseFlow.GFramework.Drawing.DeviceContexts;
using VerseFlow.GFramework.Model;

namespace VerseFlow.GFramework.View
{
	public class GPaintContext : GDisposableObject
	{
		internal readonly GDeviceContext deviceContext;

		public GPaintContext(GDeviceContext deviceContext)
		{
			this.deviceContext = deviceContext;
		}

		public GDeviceContext DeviceContext
		{
			get { return deviceContext; }
		}

		/// <summary>
		///     Stores specific context data, using the provided key.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="data"></param>
		public virtual void SetData(int key, object data)
		{
			SetPropertyValue(key, data);
		}

		/// <summary>
		///     Retrieves previously stored data or null if no data is associated with the specified key.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public virtual object GetData(int key)
		{
			return GetLocalPropertyValue(key);
		}
	}
}