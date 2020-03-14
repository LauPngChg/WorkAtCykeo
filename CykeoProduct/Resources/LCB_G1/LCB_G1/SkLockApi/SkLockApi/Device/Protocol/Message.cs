using SkLockApi.Device.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkLockApi.Device.Protocol
{
    [Serializable]
    public class Message
    {
		private MsgType msgType;
		private bool result_ok;
		private string result_msg;
		private byte bcc;

		public string ResultMsg
		{
			get { return result_msg; }
			set { result_msg = value; }
		}

		public bool ReaultOk
		{
			get { return result_ok; }
			set { result_ok = value; }
		}

		public MsgType MyMsgType
		{
			get { return msgType; }
			set { msgType = value; }
		}

		public Message()
		{
			msgType = new MsgType();
		}
		public Message(EnumControlMid my_cmd, byte[] request)
		{
			msgType = new MsgType(my_cmd, request);
		}
		public byte[] ToByte()
		{
			return msgType.ToBytes();
		}
		public override string ToString()
		{
			return msgType.ToString();
		}
		public bool CheckBcc()
		{
			byte _bcc = msgType.ToCheckSum();
			return (bcc == _bcc);
		}
	}
}
