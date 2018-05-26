using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Client.WPF.ViewModel
{
    public class SliceData
    {
        public Dictionary<string, double> Slice { get; set; }

        public string SliceDataUnit { get; set; }

        public SliceData(string unit)
        {
            this.Slice = new Dictionary<string, double>();
            this.SliceDataUnit = unit;
        }

        public void AddSlice(string slicename, double slicevalue)
        {
            this.Slice.Add(slicename, slicevalue);
            this.RefreshSliceDataBasedOnUnit();
        }

        private void RefreshSliceDataBasedOnUnit()
        {

        }
    }
}
