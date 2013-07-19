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
	public enum SMState
	{
		Start = 0,
		Error = 1,
		ItsMe = 2,
	};

	public partial class SMModel
	{
		private const int eError = (int) SMState.Error;
		private const int eItsMe = (int) SMState.ItsMe;
		private const int eStart = (int) SMState.Start;

		public int[] charLenTable;
		public int classFactor;
		public PkgInt classTable;
		public string name;
		public PkgInt stateTable;

		protected SMModel(PkgInt classTable, int classFactor, PkgInt stateTable, int[] charLenTable, string name)
		{
			this.classTable = classTable;
			this.classFactor = classFactor;
			this.stateTable = stateTable;
			this.charLenTable = charLenTable;
			this.name = name;
		}
	}

	public class CodingStateMachine
	{
		protected int mCurrentBytePos;
		protected int mCurrentCharLen;
		protected SMState mCurrentState;
		protected SMModel mModel;

		public CodingStateMachine(SMModel sm)
		{
			mCurrentState = SMState.Start;
			mModel = sm;
		}

		public SMState NextState(byte c)
		{
			//for each byte we get its class , if it is first byte, we also get byte length
			int byteCls = PkgInt.GETFROMPCK(c, mModel.classTable);

			if (mCurrentState == SMState.Start)
			{
				mCurrentBytePos = 0;
				mCurrentCharLen = mModel.charLenTable[byteCls];
			}
			//from byte's class and stateTable, we get its next state
			mCurrentState = (SMState) PkgInt.GETFROMPCK((int) mCurrentState*(mModel.classFactor) + byteCls,
			                                            mModel.stateTable);
			mCurrentBytePos++;
			return mCurrentState;
		}

		public void Reset()
		{
			mCurrentState = SMState.Start;
		}

		public int CurrentCharLen
		{
			get { return mCurrentCharLen; }
		}

		public string Name
		{
			get { return mModel.name; }
		}
	}
}