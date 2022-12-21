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

        public static void showDataGridView(DataGridView gridView, dynamic data, bool fill = true)
        {

            gridView.Columns.Clear();
            gridView.DataSource = data;
            if (fill == true)
                gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
    }
}
