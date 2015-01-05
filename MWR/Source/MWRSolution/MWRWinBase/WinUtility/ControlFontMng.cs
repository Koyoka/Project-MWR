using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace YRKJ.MWR.WinBase.WinUtility
{
    public class ControlFontMng
    {
        private const string ClassName = "YRKJ.MWR.WinBase.WinUtility";

        private Form _form = null;

        private bool _formClosed = false;

        public ControlFontMng(Form form)
        {
            _form = form;

            Control[] controlsList = WinFn.GetFormAllControls(_form);
        }

        public void SetControlsFont(Font newFont)
        {
            //if (_formClosed)
            //{
            //    return;
            //}

            //if (!_enabled)
            //{
            //    return;
            //}

            Control[] controlsList = WinFn.GetFormAllControls(_form);
            foreach (Control ctl in controlsList)
            {

                //ctl.Font = GetNewFont(ctl.Name, newFont);
                //if (ctl is DevExpress.XtraGrid.GridControl)
                //{
                //    DevExpress.XtraGrid.GridControl grid = (DevExpress.XtraGrid.GridControl)ctl;
                //    DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)grid.Views[0];

                //    view.Appearance.FooterPanel.Font = GetNewFont(view.Name + "_FooterPanel", newFont);

                //    foreach (DevExpress.XtraGrid.Columns.GridColumn col in view.Columns)
                //    {
                //        col.AppearanceHeader.Font = GetNewFont(col.Name + "_Header", newFont);
                //        col.AppearanceCell.Font = GetNewFont(col.Name + "_Cell", newFont);
                //    }

                //    if (view is DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)
                //    {
                //        DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandView = (DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)grid.Views[0];
                //        DevExpress.XtraGrid.Views.BandedGrid.GridBand[] bandList = GridHelper.GetAllBands(bandView);
                //        foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand band in bandList)
                //        {
                //            band.AppearanceHeader.Font = GetNewFont(band.Name, newFont);
                //        }
                //    }
                //}
                //else if (ctl is DevExpress.XtraEditors.GroupControl)
                //{
                //    DevExpress.XtraEditors.GroupControl group = (DevExpress.XtraEditors.GroupControl)ctl;
                //    group.AppearanceCaption.Font = GetNewFont(group.Name, newFont);
                //}
                //else if (ctl is DevExpress.XtraTab.XtraTabControl)
                //{
                //    DevExpress.XtraTab.XtraTabControl tab = (DevExpress.XtraTab.XtraTabControl)ctl;
                //    tab.AppearancePage.Header.Font = GetNewFont(tab.Name, newFont);
                //}
                //else if (ctl is DevExpress.XtraEditors.ComboBoxEdit)
                //{
                //    DevExpress.XtraEditors.ComboBoxEdit cmb = (DevExpress.XtraEditors.ComboBoxEdit)ctl;
                //    cmb.Font = GetNewFont(cmb.Name, newFont);
                //    cmb.Properties.AppearanceDropDown.Font = GetNewFont(cmb.Name + "_DropDown", newFont);
                //}
                //else if (ctl is DevExpress.XtraNavBar.NavBarControl)
                //{
                //    DevExpress.XtraNavBar.NavBarControl nbc = (DevExpress.XtraNavBar.NavBarControl)ctl;
                //    nbc.Appearance.GroupHeader.Font = GetNewFont(nbc.Name + "_Group", newFont);
                //    nbc.Appearance.Item.Font = GetNewFont(nbc.Name + "_Item", newFont);
                //    nbc.Appearance.ItemPressed.Font = new Font(GetNewFont(nbc.Name + "_ItemPressed", newFont), FontStyle.Underline);
                //    nbc.Appearance.ItemHotTracked.Font = new Font(GetNewFont(nbc.Name + "_ItemHotTracked", newFont), FontStyle.Underline);
                //}
                //else if (ctl is DevExpress.XtraTreeList.TreeList)
                //{
                //    DevExpress.XtraTreeList.TreeList trl = (DevExpress.XtraTreeList.TreeList)ctl;
                //    trl.Appearance.HeaderPanel.Font = GetNewFont(trl.Name + "_Header", newFont);
                //    trl.Appearance.Row.Font = GetNewFont(trl.Name + "_Row", newFont);
                //}
                //else
                //{
                //    ctl.Font = GetNewFont(ctl.Name, newFont);
                //}
            }
        }

        //private Font GetNewFont(string controlName, Font newFont)
        //{
        //    float oldFontSize = newFont.Size;
        //    bool oldFontBold = newFont.Bold;

        //    for (int i = 0; i < _controlNameList.Count; i++)
        //    {
        //        if (_controlNameList[i] == controlName)
        //        {
        //            oldFontSize = _fontSizeList[i];
        //            oldFontBold = _fontBoldList[i];
        //        }
        //    }

        //    string newFontName = newFont.Name;
        //    float newFontSize = newFont.Size;
        //    bool newFontBold = oldFontBold;

        //    if (oldFontSize == 8)
        //    {
        //        newFontName = GetSystemDefaultFont().Name;
        //        newFontSize = GetSystemDefaultFont().Size;
        //    }
        //    else if (oldFontSize == 10.75)
        //    {
        //        if (newFontSize > oldFontSize)
        //        {
        //            newFontSize = oldFontSize;
        //        }
        //    }
        //    else if (oldFontSize >= 13)
        //    {
        //        newFontSize = oldFontSize;
        //    }

        //    return new Font(newFontName, newFontSize, (newFontBold ? FontStyle.Bold : FontStyle.Regular));
        //}

        public void CLose()
        {
            _formClosed = true;

            _form = null;
        }
    }
}
