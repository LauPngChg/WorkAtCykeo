using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ControlBoard.LCB_B1.API.Msg
{
    public class MsgObject_Switch_LED:MessageObject
    {
        eLED temp;
        eSwitch temp1;
        public eLED SetLed { set => temp = value; }
        public eSwitch SetStatus { set => temp1 = value; }
        public MsgObject_Switch_LED()
        {
            temp = eLED.LED1;
            temp1 = eSwitch.Open;
        }
        public override void CmdPacked()
        {
            byte temp ;
            if ((byte)this.temp >= 15)
            {
                temp = (byte)(225+((byte)this.temp - 15) * 2);
            }
            else if ((byte)this.temp >= 8)
            {
                temp = (byte)(209 + ((byte)this.temp - 8) * 2);
            }
            else 
            {
                temp = (byte)(193 + ((byte)this.temp - 1) * 2);
            }
            base.Data = new List<byte[]>() { new byte[1] { (byte)(temp + (byte)temp1) } };
        }
    }
}
