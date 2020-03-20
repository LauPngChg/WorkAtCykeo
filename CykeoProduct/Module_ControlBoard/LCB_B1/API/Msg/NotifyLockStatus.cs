using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ControlBoard.LCB_B1.API.Msg
{
    public class NotifyLockStatus : MessageObject
    {
        List<eLock> temp;
        bool[] temp1;
        public List<eLock> OpenedLock { get => temp; }
        public bool[] AllLockStatus { get => temp1; }
        public NotifyLockStatus()
        { }
        public void Unpacked()
        {
            if (base.Data == null)
                return;
            this.temp1 = new bool[16];
            this.temp = new List<eLock>();
            string temp = Convert.ToString(base.Data[0][1], 2) + Convert.ToString(base.Data[0][0], 2);
            for (int i = 0; i <16; i++)
            {
                if (this.temp1[i] = temp[i] == '0' ? true : false)
                    this.temp.Add((eLock)(i + 1));
            }
            Array.Reverse(this.temp1);
        }
    }

}
