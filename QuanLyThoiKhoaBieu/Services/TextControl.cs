using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThoiKhoaBieu.Services
{
    class TextControl
    {
        public static void emptyTxt(UserControl f, bool searchRecursively = true)
        {
            Action<Control.ControlCollection, bool> clearTextBoxes = null;
            clearTextBoxes = (controls, searchChildren) =>
            {
                foreach (Control c in controls)
                {
                    TextBox txt = c as TextBox;
                    txt?.Clear();
                    if (searchChildren && c.HasChildren)
                        clearTextBoxes(c.Controls, true);
                }
            };

            clearTextBoxes(f.Controls, searchRecursively);
        }

    }

}
