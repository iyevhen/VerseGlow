using System;
using System.Net.NetworkInformation;

namespace VerseFlow
{
	internal static class NetInterface
	{
		public static string MAC()
		{
			foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
			{
				if (ni.OperationalStatus == OperationalStatus.Up)
					return BitConverter.ToString(ni.GetPhysicalAddress().GetAddressBytes()).Replace("-", "");
			}

			return null;
		}
	}
}