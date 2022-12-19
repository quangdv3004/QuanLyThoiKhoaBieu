using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThoiKhoaBieu.Services
{
    class ShowCombobox
    {
        public static void initCombobox(ComboBox cbb, dynamic data )
        {
            cbb.Items.Clear();
            cbb.DataSource = data;
            cbb.ValueMember = "id";
            cbb.DisplayMember = "name";
        }
    }
}
