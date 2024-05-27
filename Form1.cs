using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();
        private void Form1_Load(object sender, EventArgs e)
        {
            try{
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = modify.getAllNhanVien();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            string id = txtMa.Text;
            string name = txtTen.Text;
            DateTime dateOfBirth = dateTimePicker.Value ;
            string gioiTinh = rdBNam.Checked ? rdBNam.Text : rdBNu.Text;
            string address = txtDiaChi.Text;
            string number = txtSoDienThoai.Text;
            if (modify.insert(new NhanVien(id, name, dateOfBirth, gioiTinh, address, number)))
                MessageBox.Show("Thêm Thành Công");
            else
                MessageBox.Show("Thêm Thất bại");
            dataGridView1.DataSource = modify.getAllNhanVien();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            txtMa.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTen.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            dateTimePicker.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "Nam")
                rdBNam.Checked = true;
            else
                rdBNu.Checked = true;
            txtDiaChi.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtSoDienThoai.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();

        }

        private void bntSua_Click(object sender, EventArgs e)
        {

            string id = txtMa.Text;
            string name = txtTen.Text;
            DateTime dateOfBirth = dateTimePicker.Value;
            string gioiTinh = rdBNam.Checked ? rdBNam.Text : rdBNu.Text;
            string address = txtDiaChi.Text;
            string number = txtSoDienThoai.Text;
            if (modify.update(new NhanVien(id, name, dateOfBirth, gioiTinh, address, number)) != 0)
                MessageBox.Show("Cật nhật  Thành Công");
            else
                MessageBox.Show("Cật nhật thất bại chưa có dòng nào thay đổi");
            dataGridView1.DataSource = modify.getAllNhanVien();

        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn Chắc Chắn muốn xoá","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Error);

            if (result == DialogResult.Yes)
            {
                if (modify.delete(txtMa.Text) != -1)
                {
                    dataGridView1.DataSource = modify.getAllNhanVien();
                }
                else
                    MessageBox.Show("Xoá Thất bại");
            }
        }
    }
}
