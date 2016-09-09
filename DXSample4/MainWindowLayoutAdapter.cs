using System;
using DevExpress.Xpf.Docking;

namespace DXSample4
{
    public class MainWindowLayoutAdapter : ILayoutAdapter
    {
        public String Resolve(DockLayoutManager owner, Object item)
        {
            var layoutPanel = item as BaseLayoutItem;
            if (layoutPanel == null)
            {
                return "DocumentHost";
            }

            owner.LayoutController.Activate(layoutPanel);
            return layoutPanel.Tag as String;
        }
    }
}