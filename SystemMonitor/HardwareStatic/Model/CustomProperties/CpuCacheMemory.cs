using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.HardwareStatic.Model.CustomProperties
{
    public struct CpuCacheMemory
    {
        public UnitValue Speed;

        public UnitValue Size;

        public string Level;

        public CpuCacheMemory(UnitValue speed, UnitValue size, string level)
        {
            this.Speed = speed;
            this.Size = size;
            this.Level = level;
        }
    }
}