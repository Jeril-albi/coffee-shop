﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Starbucks.presentation.login;
using Starbucks.presentation.admin.dashboard;

namespace Starbucks.domain.admin
{
    public class Login
    {
        public bool adminLogin(String username,String password)
        {
            Screen_Login login = new Screen_Login();
            Screen_Dashboard dashboard = new Screen_Dashboard();

            SqlDataAdapter sda = new SqlDataAdapter($"SELECT COUNT(*) FROM login WHERE username='{username}' AND password='{password}'", Database.con);
            DataTable dt = new DataTable(); 
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                dashboard.Show();
                return true;
            }
            else
            {
                MessageBox.Show("Invalid username or password");
                return false;
            }
        }
    }
}
