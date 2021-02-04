using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFM.Model;
using WFM.Service;

namespace WFM
{
    public partial class Form1 : Form
    {

        private UserService userService;
        public Form1()
        {
            InitializeComponent();
            userService = new UserService();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            AddUserModel userModel = new AddUserModel();
            userModel.email = txtEmail.Text;
            userModel.username = txtUsername.Text;
            userModel.password = txtUsername.Text;
            int responce = userService.AddNewUser(userModel);
            if (responce == 1)
            {
                MessageBox.Show("Added successfully", "Message");
            }
            else
            {
                MessageBox.Show("Added Falied", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
