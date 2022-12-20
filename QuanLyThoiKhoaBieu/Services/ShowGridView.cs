using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThoiKhoaBieu.Services
{
    class ShowGridView
    {
        public static void showDataGridView(DataGridView gridView, dynamic data)
        {

            gridView.Columns.Clear();
            gridView.DataSource = data;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
    }
}
