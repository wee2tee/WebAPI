using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebAPI;
using WebAPI.ApiResult;
using Newtonsoft.Json;
using TestAPI.TestingModelResult;

namespace TestAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestGet_Click(object sender, EventArgs e)
        {
            CRUDResult res = ApiActions.GET(ApiConfig.API_MAIN_URL + "macallowed/get_at&mac_id=300");

            List<MacAllowed> data = JsonConvert.DeserializeObject<List<MacAllowed>>(res.data);

            if (data.Count > 0)
            {
                string r = string.Empty;
                foreach (MacAllowed item in data)
                {
                    r += "ID : " + item.id.ToString() + Environment.NewLine;
                    r += "MAC Address : " + item.mac_address + Environment.NewLine;
                    r += "Create by : " + item.create_by + Environment.NewLine;
                    r += "Create at : " + item.create_at + Environment.NewLine + Environment.NewLine;
                }
                this.txtResult.Text = r;
            }
            else
            {
                this.txtResult.Text = "ไม่มีข้อมูล";
            }
        }

        private void btnTestPost_Click(object sender, EventArgs e)
        {
            string json_data = "{\"mac_address\":\"wee2tee@gmail.com\",";
            json_data += "\"create_by\":\"WEE\"}";

            CRUDResult res = ApiActions.POST(ApiConfig.API_MAIN_URL + "macallowed/create", json_data);
            //MacAllowed result = JsonConvert.DeserializeObject<MacAllowed>(res.message);
            if (res.result)
            {
                this.txtResult.Text = res.data;
            }
            else
            {
                GeneralResult result = JsonConvert.DeserializeObject<GeneralResult>(res.data);

                this.txtResult.Text = result.message;
            }
            

        }

        private void btnTestPatch_Click(object sender, EventArgs e)
        {
            string json_data = "{\"id\":15,";
            json_data += "\"mac_address\":\"wee2tee@gmail\",";
            json_data += "\"create_by\":\"WEE\"}";

            CRUDResult res = ApiActions.POST(ApiConfig.API_MAIN_URL + "macallowed/update", json_data);
            //MacAllowed result = JsonConvert.DeserializeObject<MacAllowed>(res.message);
            if (res.result)
            {
                GeneralResult result = JsonConvert.DeserializeObject<GeneralResult>(res.data);

                this.txtResult.Text = result.message;
            }
            else
            {
                this.txtResult.Text = res.data;
            }
        }

        private void btnTestDelete_Click(object sender, EventArgs e)
        {
            CRUDResult res = ApiActions.DELETE(ApiConfig.API_MAIN_URL + "macallowed/delete&id=15");
            GeneralResult result = JsonConvert.DeserializeObject<GeneralResult>(res.data);
            MessageBox.Show(result.message);
        }
    }
}
