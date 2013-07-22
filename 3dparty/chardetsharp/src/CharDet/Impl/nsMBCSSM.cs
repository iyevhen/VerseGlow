/* 
 * C# port of Mozilla Character Set Detector
 * 
 * Original Mozilla License Block follows
 * 
 */

#region License Block

// Version: MPL 1.1/GPL 2.0/LGPL 2.1
//
// The contents of this file are subject to the Mozilla Public License Version
// 1.1 (the "License"); you may not use this file except in compliance with
// the License. You may obtain a copy of the License at
// http://www.mozilla.org/MPL/
//
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
// for the specific language governing rights and limitations under the
// License.
//
// The Original Code is Mozilla Universal charset detector code.
//
// The Initial Developer of the Original Code is
// Netscape Communications Corporation.
// Portions created by the Initial Developer are Copyright (C) 2001
// the Initial Developer. All Rights Reserved.
//
// Contributor(s):
//
// Alternatively, the contents of this file may be used under the terms of
// either the GNU General Public License Version 2 or later (the "GPL"), or
// the GNU Lesser General Public License Version 2.1 or later (the "LGPL"),
// in which case the provisions of the GPL or the LGPL are applicable instead
// of those above. If you wish to allow use of your version of this file only
// under the terms of either the GPL or the LGPL, and not to allow others to
// use your version of this file under the terms of the MPL, indicate your
// decision by deleting the provisions above and replace them with the notice
// and other provisions required by the GPL or the LGPL. If you do not delete
// the provisions above, a recipient may use your version of this file under
// the terms of any one of the MPL, the GPL or the LGPL.

#endregion

namespace Mozilla.CharDet.Impl
{
	public partial class SMModel
	{
		// Modification from frank tang's original work:
		// . 0x00 is allowed as a legal character. Since some web pages contains this char in 
		//   text stream.

		// BIG5 
		private static readonly int[] BIG5_cls = new[]
			{
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 00 - 07    //allow 0x00 as legal value
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 0, 0), // 08 - 0f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 10 - 17 
				PkgInt.PCK4BITS(1, 1, 1, 0, 1, 1, 1, 1), // 18 - 1f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 20 - 27 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 28 - 2f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 30 - 37 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 38 - 3f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 40 - 47 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 48 - 4f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 50 - 57 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 58 - 5f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 60 - 67 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 68 - 6f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 70 - 77 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 1), // 78 - 7f 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 80 - 87 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 88 - 8f 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 90 - 97 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 98 - 9f 
				PkgInt.PCK4BITS(4, 3, 3, 3, 3, 3, 3, 3), // a0 - a7 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // a8 - af 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // b0 - b7 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // b8 - bf 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // c0 - c7 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // c8 - cf 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // d0 - d7 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // d8 - df 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // e0 - e7 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // e8 - ef 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // f0 - f7 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 0) // f8 - ff 
			};

		private static readonly int[] BIG5_st = new[]
			{
				PkgInt.PCK4BITS(eError, eStart, eStart, 3, eError, eError, eError, eError), //00-07 
				PkgInt.PCK4BITS(eError, eError, eItsMe, eItsMe, eItsMe, eItsMe, eItsMe, eError), //08-0f 
				PkgInt.PCK4BITS(eError, eStart, eStart, eStart, eStart, eStart, eStart, eStart) //10-17 
			};

		private static readonly int[] Big5CharLenTable = new[] {0, 1, 1, 2, 0};

		public static readonly SMModel Big5SMModel = new SMModel(
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, BIG5_cls),
			5,
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, BIG5_st),
			Big5CharLenTable,
			"Big5"
			);

		private static readonly int[] EUCJP_cls = new[]
			{
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 00 - 07 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 5, 5), // 08 - 0f 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 10 - 17 
				PkgInt.PCK4BITS(4, 4, 4, 5, 4, 4, 4, 4), // 18 - 1f 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 20 - 27 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 28 - 2f 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 30 - 37 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 38 - 3f 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 40 - 47 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 48 - 4f 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 50 - 57 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 58 - 5f 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 60 - 67 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 68 - 6f 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 70 - 77 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 78 - 7f 
				PkgInt.PCK4BITS(5, 5, 5, 5, 5, 5, 5, 5), // 80 - 87 
				PkgInt.PCK4BITS(5, 5, 5, 5, 5, 5, 1, 3), // 88 - 8f 
				PkgInt.PCK4BITS(5, 5, 5, 5, 5, 5, 5, 5), // 90 - 97 
				PkgInt.PCK4BITS(5, 5, 5, 5, 5, 5, 5, 5), // 98 - 9f 
				PkgInt.PCK4BITS(5, 2, 2, 2, 2, 2, 2, 2), // a0 - a7 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // a8 - af 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // b0 - b7 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // b8 - bf 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // c0 - c7 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // c8 - cf 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // d0 - d7 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // d8 - df 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // e0 - e7 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // e8 - ef 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // f0 - f7 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 5) // f8 - ff 
			};

		private static readonly int[] EUCJP_st = new[]
			{
				PkgInt.PCK4BITS(3, 4, 3, 5, eStart, eError, eError, eError), //00-07 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eItsMe, eItsMe, eItsMe, eItsMe), //08-0f 
				PkgInt.PCK4BITS(eItsMe, eItsMe, eStart, eError, eStart, eError, eError, eError), //10-17 
				PkgInt.PCK4BITS(eError, eError, eStart, eError, eError, eError, 3, eError), //18-1f 
				PkgInt.PCK4BITS(3, eError, eError, eError, eStart, eStart, eStart, eStart) //20-27 
			};

		private static readonly int[] EUCJPCharLenTable = new[] {2, 2, 2, 3, 1, 0};

		public static readonly SMModel EUCJPSMModel = new SMModel(
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, EUCJP_cls),
			6,
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, EUCJP_st),
			EUCJPCharLenTable,
			"EUC-JP"
			);

		private static readonly int[] EUCKR_cls = new[]
			{
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 00 - 07 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 0, 0), // 08 - 0f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 10 - 17 
				PkgInt.PCK4BITS(1, 1, 1, 0, 1, 1, 1, 1), // 18 - 1f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 20 - 27 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 28 - 2f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 30 - 37 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 38 - 3f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 40 - 47 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 48 - 4f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 50 - 57 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 58 - 5f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 60 - 67 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 68 - 6f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 70 - 77 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 78 - 7f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 80 - 87 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 88 - 8f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 90 - 97 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 98 - 9f 
				PkgInt.PCK4BITS(0, 2, 2, 2, 2, 2, 2, 2), // a0 - a7 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 3, 3, 3), // a8 - af 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // b0 - b7 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // b8 - bf 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // c0 - c7 
				PkgInt.PCK4BITS(2, 3, 2, 2, 2, 2, 2, 2), // c8 - cf 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // d0 - d7 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // d8 - df 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // e0 - e7 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // e8 - ef 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // f0 - f7 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 0) // f8 - ff 
			};

		private static readonly int[] EUCKR_st = new[]
			{
				PkgInt.PCK4BITS(eError, eStart, 3, eError, eError, eError, eError, eError), //00-07 
				PkgInt.PCK4BITS(eItsMe, eItsMe, eItsMe, eItsMe, eError, eError, eStart, eStart) //08-0f 
			};

		private static readonly int[] EUCKRCharLenTable = new[] {0, 1, 2, 0};

		public static readonly SMModel EUCKRSMModel = new SMModel(
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, EUCKR_cls),
			4,
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, EUCKR_st),
			EUCKRCharLenTable,
			"EUC-KR"
			);

		private static readonly int[] EUCTW_cls = new[]
			{
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 00 - 07 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 0, 0), // 08 - 0f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 10 - 17 
				PkgInt.PCK4BITS(2, 2, 2, 0, 2, 2, 2, 2), // 18 - 1f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 20 - 27 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 28 - 2f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 30 - 37 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 38 - 3f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 40 - 47 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 48 - 4f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 50 - 57 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 58 - 5f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 60 - 67 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 68 - 6f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 70 - 77 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 78 - 7f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 80 - 87 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 6, 0), // 88 - 8f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 90 - 97 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 98 - 9f 
				PkgInt.PCK4BITS(0, 3, 4, 4, 4, 4, 4, 4), // a0 - a7 
				PkgInt.PCK4BITS(5, 5, 1, 1, 1, 1, 1, 1), // a8 - af 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // b0 - b7 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // b8 - bf 
				PkgInt.PCK4BITS(1, 1, 3, 1, 3, 3, 3, 3), // c0 - c7 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // c8 - cf 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // d0 - d7 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // d8 - df 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // e0 - e7 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // e8 - ef 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // f0 - f7 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 0) // f8 - ff 
			};

		private static readonly int[] EUCTW_st = new[]
			{
				PkgInt.PCK4BITS(eError, eError, eStart, 3, 3, 3, 4, eError), //00-07 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eError, eError, eItsMe, eItsMe), //08-0f 
				PkgInt.PCK4BITS(eItsMe, eItsMe, eItsMe, eItsMe, eItsMe, eError, eStart, eError), //10-17 
				PkgInt.PCK4BITS(eStart, eStart, eStart, eError, eError, eError, eError, eError), //18-1f 
				PkgInt.PCK4BITS(5, eError, eError, eError, eStart, eError, eStart, eStart), //20-27 
				PkgInt.PCK4BITS(eStart, eError, eStart, eStart, eStart, eStart, eStart, eStart) //28-2f 
			};

		private static readonly int[] EUCTWCharLenTable = new[] {0, 0, 1, 2, 2, 2, 3};

		public static readonly SMModel EUCTWSMModel = new SMModel(
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, EUCTW_cls),
			7,
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, EUCTW_st),
			EUCTWCharLenTable,
			"x-euc-tw"
			);

#if OBSOLETE
	// obsolete GB2312 by gb18030
        static readonly int[] GB2312_cls  = new int[]{
            PkgInt.PCK4BITS(1,1,1,1,1,1,1,1),  // 00 - 07 
            PkgInt.PCK4BITS(1,1,1,1,1,1,0,0),  // 08 - 0f 
            PkgInt.PCK4BITS(1,1,1,1,1,1,1,1),  // 10 - 17 
            PkgInt.PCK4BITS(1,1,1,0,1,1,1,1),  // 18 - 1f 
            PkgInt.PCK4BITS(1,1,1,1,1,1,1,1),  // 20 - 27 
            PkgInt.PCK4BITS(1,1,1,1,1,1,1,1),  // 28 - 2f 
            PkgInt.PCK4BITS(1,1,1,1,1,1,1,1),  // 30 - 37 
            PkgInt.PCK4BITS(1,1,1,1,1,1,1,1),  // 38 - 3f 
            PkgInt.PCK4BITS(1,1,1,1,1,1,1,1),  // 40 - 47 
            PkgInt.PCK4BITS(1,1,1,1,1,1,1,1),  // 48 - 4f 
            PkgInt.PCK4BITS(1,1,1,1,1,1,1,1),  // 50 - 57 
            PkgInt.PCK4BITS(1,1,1,1,1,1,1,1),  // 58 - 5f 
            PkgInt.PCK4BITS(1,1,1,1,1,1,1,1),  // 60 - 67 
            PkgInt.PCK4BITS(1,1,1,1,1,1,1,1),  // 68 - 6f 
            PkgInt.PCK4BITS(1,1,1,1,1,1,1,1),  // 70 - 77 
            PkgInt.PCK4BITS(1,1,1,1,1,1,1,1),  // 78 - 7f 
            PkgInt.PCK4BITS(1,0,0,0,0,0,0,0),  // 80 - 87 
            PkgInt.PCK4BITS(0,0,0,0,0,0,0,0),  // 88 - 8f 
            PkgInt.PCK4BITS(0,0,0,0,0,0,0,0),  // 90 - 97 
            PkgInt.PCK4BITS(0,0,0,0,0,0,0,0),  // 98 - 9f 
            PkgInt.PCK4BITS(0,2,2,2,2,2,2,2),  // a0 - a7 
            PkgInt.PCK4BITS(2,2,3,3,3,3,3,3),  // a8 - af 
            PkgInt.PCK4BITS(2,2,2,2,2,2,2,2),  // b0 - b7 
            PkgInt.PCK4BITS(2,2,2,2,2,2,2,2),  // b8 - bf 
            PkgInt.PCK4BITS(2,2,2,2,2,2,2,2),  // c0 - c7 
            PkgInt.PCK4BITS(2,2,2,2,2,2,2,2),  // c8 - cf 
            PkgInt.PCK4BITS(2,2,2,2,2,2,2,2),  // d0 - d7 
            PkgInt.PCK4BITS(2,2,2,2,2,2,2,2),  // d8 - df 
            PkgInt.PCK4BITS(2,2,2,2,2,2,2,2),  // e0 - e7 
            PkgInt.PCK4BITS(2,2,2,2,2,2,2,2),  // e8 - ef 
            PkgInt.PCK4BITS(2,2,2,2,2,2,2,2),  // f0 - f7 
            PkgInt.PCK4BITS(2,2,2,2,2,2,2,0)   // f8 - ff 
        };


        static readonly int[] GB2312_st  = new int[]{
            PkgInt.PCK4BITS(eError,eStart,     3,eError,eError,eError,eError,eError),//00-07 
            PkgInt.PCK4BITS(eItsMe,eItsMe,eItsMe,eItsMe,eError,eError,eStart,eStart) //08-0f 
        };

        static readonly int[] GB2312CharLenTable = new int[]{0, 1, 2, 0};

        public static readonly SMModel GB2312SMModel = new SMModel(
            new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, GB2312_cls),
            4,
            new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, GB2312_st),
            GB2312CharLenTable,
            "GB2312",
        );
        #endif

		// the following state machine data was created by perl script in 
		// intl/chardet/tools. It should be the same as in PSM detector.
		private static readonly int[] GB18030_cls = new[]
			{
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 00 - 07 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 0, 0), // 08 - 0f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 10 - 17 
				PkgInt.PCK4BITS(1, 1, 1, 0, 1, 1, 1, 1), // 18 - 1f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 20 - 27 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 28 - 2f 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // 30 - 37 
				PkgInt.PCK4BITS(3, 3, 1, 1, 1, 1, 1, 1), // 38 - 3f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 40 - 47 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 48 - 4f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 50 - 57 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 58 - 5f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 60 - 67 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 68 - 6f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 70 - 77 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 4), // 78 - 7f 
				PkgInt.PCK4BITS(5, 6, 6, 6, 6, 6, 6, 6), // 80 - 87 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 6), // 88 - 8f 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 6), // 90 - 97 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 6), // 98 - 9f 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 6), // a0 - a7 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 6), // a8 - af 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 6), // b0 - b7 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 6), // b8 - bf 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 6), // c0 - c7 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 6), // c8 - cf 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 6), // d0 - d7 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 6), // d8 - df 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 6), // e0 - e7 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 6), // e8 - ef 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 6), // f0 - f7 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 0) // f8 - ff 
			};

		private static readonly int[] GB18030_st = new[]
			{
				PkgInt.PCK4BITS(eError, eStart, eStart, eStart, eStart, eStart, 3, eError), //00-07 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eError, eError, eItsMe, eItsMe), //08-0f 
				PkgInt.PCK4BITS(eItsMe, eItsMe, eItsMe, eItsMe, eItsMe, eError, eError, eStart), //10-17 
				PkgInt.PCK4BITS(4, eError, eStart, eStart, eError, eError, eError, eError), //18-1f 
				PkgInt.PCK4BITS(eError, eError, 5, eError, eError, eError, eItsMe, eError), //20-27 
				PkgInt.PCK4BITS(eError, eError, eStart, eStart, eStart, eStart, eStart, eStart) //28-2f 
			};

		// To be accurate, the length of class 6 can be either 2 or 4. 
		// But it is not necessary to discriminate between the two since 
		// it is used for frequency analysis only, and we are validing 
		// each code range there as well. So it is safe to set it to be 
		// 2 here. 
		private static readonly int[] GB18030CharLenTable = new[] {0, 1, 1, 1, 1, 1, 2};

		public static readonly SMModel GB18030SMModel = new SMModel(
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, GB18030_cls),
			7,
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, GB18030_st),
			GB18030CharLenTable,
			"GB18030"
			);

		// sjis
		private static readonly int[] SJIS_cls = new[]
			{
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 00 - 07 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 0, 0), // 08 - 0f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 10 - 17 
				PkgInt.PCK4BITS(1, 1, 1, 0, 1, 1, 1, 1), // 18 - 1f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 20 - 27 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 28 - 2f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 30 - 37 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 38 - 3f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 40 - 47 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 48 - 4f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 50 - 57 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 58 - 5f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 60 - 67 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 68 - 6f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // 70 - 77 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 1), // 78 - 7f 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // 80 - 87 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // 88 - 8f 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // 90 - 97 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // 98 - 9f 
				//0xa0 is illegal in sjis encoding, but some pages does 
				//contain such byte. We need to be more error forgiven.
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // a0 - a7     
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // a8 - af 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // b0 - b7 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // b8 - bf 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // c0 - c7 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // c8 - cf 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // d0 - d7 
				PkgInt.PCK4BITS(2, 2, 2, 2, 2, 2, 2, 2), // d8 - df 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 3, 3, 3), // e0 - e7 
				PkgInt.PCK4BITS(3, 3, 3, 3, 3, 4, 4, 4), // e8 - ef 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // f0 - f7 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 0, 0, 0) // f8 - ff 
			};

		private static readonly int[] SJIS_st = new[]
			{
				PkgInt.PCK4BITS(eError, eStart, eStart, 3, eError, eError, eError, eError), //00-07 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eItsMe, eItsMe, eItsMe, eItsMe), //08-0f 
				PkgInt.PCK4BITS(eItsMe, eItsMe, eError, eError, eStart, eStart, eStart, eStart) //10-17 
			};

		private static readonly int[] SJISCharLenTable = new[] {0, 1, 1, 2, 0, 0};

		public static readonly SMModel SJISSMModel = new SMModel(
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, SJIS_cls),
			6,
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, SJIS_st),
			SJISCharLenTable,
			"Shift_JIS"
			);

		private static readonly int[] UCS2BE_cls = new[]
			{
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 00 - 07 
				PkgInt.PCK4BITS(0, 0, 1, 0, 0, 2, 0, 0), // 08 - 0f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 10 - 17 
				PkgInt.PCK4BITS(0, 0, 0, 3, 0, 0, 0, 0), // 18 - 1f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 20 - 27 
				PkgInt.PCK4BITS(0, 3, 3, 3, 3, 3, 0, 0), // 28 - 2f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 30 - 37 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 38 - 3f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 40 - 47 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 48 - 4f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 50 - 57 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 58 - 5f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 60 - 67 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 68 - 6f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 70 - 77 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 78 - 7f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 80 - 87 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 88 - 8f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 90 - 97 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 98 - 9f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // a0 - a7 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // a8 - af 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // b0 - b7 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // b8 - bf 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // c0 - c7 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // c8 - cf 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // d0 - d7 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // d8 - df 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // e0 - e7 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // e8 - ef 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // f0 - f7 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 4, 5) // f8 - ff 
			};

		private static readonly int[] UCS2BE_st = new[]
			{
				PkgInt.PCK4BITS(5, 7, 7, eError, 4, 3, eError, eError), //00-07 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eItsMe, eItsMe, eItsMe, eItsMe), //08-0f 
				PkgInt.PCK4BITS(eItsMe, eItsMe, 6, 6, 6, 6, eError, eError), //10-17 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, eItsMe, 6, 6), //18-1f 
				PkgInt.PCK4BITS(6, 6, 6, 6, 5, 7, 7, eError), //20-27 
				PkgInt.PCK4BITS(5, 8, 6, 6, eError, 6, 6, 6), //28-2f 
				PkgInt.PCK4BITS(6, 6, 6, 6, eError, eError, eStart, eStart) //30-37 
			};

		private static readonly int[] UCS2BECharLenTable = new[] {2, 2, 2, 0, 2, 2};

		public static readonly SMModel UCS2BESMModel = new SMModel(
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, UCS2BE_cls),
			6,
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, UCS2BE_st),
			UCS2BECharLenTable,
			"UTF-16BE"
			);

		private static readonly int[] UCS2LE_cls = new[]
			{
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 00 - 07 
				PkgInt.PCK4BITS(0, 0, 1, 0, 0, 2, 0, 0), // 08 - 0f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 10 - 17 
				PkgInt.PCK4BITS(0, 0, 0, 3, 0, 0, 0, 0), // 18 - 1f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 20 - 27 
				PkgInt.PCK4BITS(0, 3, 3, 3, 3, 3, 0, 0), // 28 - 2f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 30 - 37 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 38 - 3f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 40 - 47 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 48 - 4f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 50 - 57 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 58 - 5f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 60 - 67 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 68 - 6f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 70 - 77 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 78 - 7f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 80 - 87 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 88 - 8f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 90 - 97 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // 98 - 9f 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // a0 - a7 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // a8 - af 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // b0 - b7 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // b8 - bf 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // c0 - c7 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // c8 - cf 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // d0 - d7 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // d8 - df 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // e0 - e7 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // e8 - ef 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 0, 0), // f0 - f7 
				PkgInt.PCK4BITS(0, 0, 0, 0, 0, 0, 4, 5) // f8 - ff 
			};

		private static readonly int[] UCS2LE_st = new[]
			{
				PkgInt.PCK4BITS(6, 6, 7, 6, 4, 3, eError, eError), //00-07 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eItsMe, eItsMe, eItsMe, eItsMe), //08-0f 
				PkgInt.PCK4BITS(eItsMe, eItsMe, 5, 5, 5, eError, eItsMe, eError), //10-17 
				PkgInt.PCK4BITS(5, 5, 5, eError, 5, eError, 6, 6), //18-1f 
				PkgInt.PCK4BITS(7, 6, 8, 8, 5, 5, 5, eError), //20-27 
				PkgInt.PCK4BITS(5, 5, 5, eError, eError, eError, 5, 5), //28-2f 
				PkgInt.PCK4BITS(5, 5, 5, eError, 5, eError, eStart, eStart) //30-37 
			};

		private static readonly int[] UCS2LECharLenTable = new[] {2, 2, 2, 2, 2, 2};

		public static readonly SMModel UCS2LESMModel = new SMModel(
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, UCS2LE_cls),
			6,
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, UCS2LE_st),
			UCS2LECharLenTable,
			"UTF-16LE"
			);

		private static readonly int[] UTF8_cls = new[]
			{
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 00 - 07  //allow 0x00 as a legal value
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 0, 0), // 08 - 0f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 10 - 17 
				PkgInt.PCK4BITS(1, 1, 1, 0, 1, 1, 1, 1), // 18 - 1f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 20 - 27 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 28 - 2f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 30 - 37 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 38 - 3f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 40 - 47 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 48 - 4f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 50 - 57 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 58 - 5f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 60 - 67 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 68 - 6f 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 70 - 77 
				PkgInt.PCK4BITS(1, 1, 1, 1, 1, 1, 1, 1), // 78 - 7f 
				PkgInt.PCK4BITS(2, 2, 2, 2, 3, 3, 3, 3), // 80 - 87 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 88 - 8f 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 90 - 97 
				PkgInt.PCK4BITS(4, 4, 4, 4, 4, 4, 4, 4), // 98 - 9f 
				PkgInt.PCK4BITS(5, 5, 5, 5, 5, 5, 5, 5), // a0 - a7 
				PkgInt.PCK4BITS(5, 5, 5, 5, 5, 5, 5, 5), // a8 - af 
				PkgInt.PCK4BITS(5, 5, 5, 5, 5, 5, 5, 5), // b0 - b7 
				PkgInt.PCK4BITS(5, 5, 5, 5, 5, 5, 5, 5), // b8 - bf 
				PkgInt.PCK4BITS(0, 0, 6, 6, 6, 6, 6, 6), // c0 - c7 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 6), // c8 - cf 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 6), // d0 - d7 
				PkgInt.PCK4BITS(6, 6, 6, 6, 6, 6, 6, 6), // d8 - df 
				PkgInt.PCK4BITS(7, 8, 8, 8, 8, 8, 8, 8), // e0 - e7 
				PkgInt.PCK4BITS(8, 8, 8, 8, 8, 9, 8, 8), // e8 - ef 
				PkgInt.PCK4BITS(10, 11, 11, 11, 11, 11, 11, 11), // f0 - f7 
				PkgInt.PCK4BITS(12, 13, 13, 13, 14, 15, 0, 0) // f8 - ff 
			};

		private static readonly int[] UTF8_st = new[]
			{
				PkgInt.PCK4BITS(eError, eStart, eError, eError, eError, eError, 12, 10), //00-07 
				PkgInt.PCK4BITS(9, 11, 8, 7, 6, 5, 4, 3), //08-0f 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eError, eError, eError, eError), //10-17 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eError, eError, eError, eError), //18-1f 
				PkgInt.PCK4BITS(eItsMe, eItsMe, eItsMe, eItsMe, eItsMe, eItsMe, eItsMe, eItsMe), //20-27 
				PkgInt.PCK4BITS(eItsMe, eItsMe, eItsMe, eItsMe, eItsMe, eItsMe, eItsMe, eItsMe), //28-2f 
				PkgInt.PCK4BITS(eError, eError, 5, 5, 5, 5, eError, eError), //30-37 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eError, eError, eError, eError), //38-3f 
				PkgInt.PCK4BITS(eError, eError, eError, 5, 5, 5, eError, eError), //40-47 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eError, eError, eError, eError), //48-4f 
				PkgInt.PCK4BITS(eError, eError, 7, 7, 7, 7, eError, eError), //50-57 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eError, eError, eError, eError), //58-5f 
				PkgInt.PCK4BITS(eError, eError, eError, eError, 7, 7, eError, eError), //60-67 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eError, eError, eError, eError), //68-6f 
				PkgInt.PCK4BITS(eError, eError, 9, 9, 9, 9, eError, eError), //70-77 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eError, eError, eError, eError), //78-7f 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eError, 9, eError, eError), //80-87 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eError, eError, eError, eError), //88-8f 
				PkgInt.PCK4BITS(eError, eError, 12, 12, 12, 12, eError, eError), //90-97 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eError, eError, eError, eError), //98-9f 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eError, 12, eError, eError), //a0-a7 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eError, eError, eError, eError), //a8-af 
				PkgInt.PCK4BITS(eError, eError, 12, 12, 12, eError, eError, eError), //b0-b7 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eError, eError, eError, eError), //b8-bf 
				PkgInt.PCK4BITS(eError, eError, eStart, eStart, eStart, eStart, eError, eError), //c0-c7 
				PkgInt.PCK4BITS(eError, eError, eError, eError, eError, eError, eError, eError) //c8-cf 
			};

		private static readonly int[] UTF8CharLenTable = new[] {0, 1, 0, 0, 0, 0, 2, 3, 3, 3, 4, 4, 5, 5, 6, 6};

		public static readonly SMModel UTF8SMModel = new SMModel(
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, UTF8_cls),
			16,
			new PkgInt(nsIdxSft.eIdxSft4bits, nsSftMsk.eSftMsk4bits, nsBitSft.eBitSft4bits, nsUnitMsk.eUnitMsk4bits, UTF8_st),
			UTF8CharLenTable,
			"UTF-8"
			);
	}
}