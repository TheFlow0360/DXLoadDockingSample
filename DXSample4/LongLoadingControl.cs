using System;
using System.Windows.Controls;

namespace DXSample4
{
    public class LongLoadingControl : Button
    {
        public LongLoadingControl()
        {      
            this.Loaded += (sender, args) =>
            {
                var end = DateTime.Now + TimeSpan.FromSeconds(3);
                while (DateTime.Now < end);
            };
        }
    }
}