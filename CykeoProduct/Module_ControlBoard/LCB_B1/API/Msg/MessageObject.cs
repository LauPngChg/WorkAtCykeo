using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ControlBoard.LCB_B1.API.Msg
{
    [Serializable]
    public  class MessageObject
    {
        List<byte[]> temp;
        internal List<byte[]> Data { set => temp = value; get => temp; }

        public MessageObject() 
        { }
        public MessageObject(byte[] temp)
        {
            this.temp = new List<byte[]>() { new byte[] { temp[2], temp[3] } };
        }
        public virtual void CmdPacked()
        {
        } 
    }   
}
