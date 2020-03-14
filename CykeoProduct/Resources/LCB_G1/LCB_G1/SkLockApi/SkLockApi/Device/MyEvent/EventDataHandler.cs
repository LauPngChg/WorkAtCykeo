using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkLockApi.Device.MyEvent
{
	#region 公用委托
	public delegate void DataSendedHandler(object sender, byte[] buffer);
	public delegate void DataBaseReceivedHandler(object sender, byte[] buffer);		//废弃
	public delegate void DataReceivedHandler(object sender, byte[] buffer);
	public delegate void DataErrorHandler(object sender, int code, string error);
	#endregion

	#region 控制板委托
	public delegate void EquipmentFeedbackHandler(byte cmd, byte[] data_bytes);
	#endregion
}
