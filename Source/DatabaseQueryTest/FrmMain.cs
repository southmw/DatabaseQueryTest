using Microsoft.VisualBasic.ApplicationServices;
using Serilog;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace DatabaseQueryTest
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private async void FrmMain_Load(object sender, EventArgs e)
        {
            Log.Information("Program Start");
            string ExternalIP = await NetworkLibrary.GetExternalIPAddressAsync();
            Log.Information($"ExternalIP: {ExternalIP}");

            Dictionary<string, string> config = GetConfig(@"DatabaseQueryTest01.cfg");
            SetDefaultConfig(config);
        }

        private void SetDefaultConfig(Dictionary<string, string> config)
        {
            txbServerIP.Text = (config != null && config.ContainsKey("serverip")) ? config["serverip"] : "127.0.0.1";
            txbServerPort.Text = (config != null && config.ContainsKey("serverport")) ? config["serverport"] : "1433";
            txbDBName.Text = (config != null && config.ContainsKey("dbname")) ? config["dbname"] : "testdb";
            txbUserID.Text = (config != null && config.ContainsKey("userid")) ? config["userid"] : "sa";
            txbPassword.Text = (config != null && config.ContainsKey("password")) ? new AesCrypt().DecryptString_Aes(config["password"]) : string.Empty;
            txbTimeout.Text = (config != null && config.ContainsKey("timeout")) ? config["timeout"] : "30";
            txbQuery.Text = (config != null && config.ContainsKey("query")) ? config["query"] : string.Empty;
        }

        private static Dictionary<string, string> GetConfig(string filename)
        {
            string configString = string.Empty;

            if(File.Exists(filename)) {
                Log.Information("Config File Read");
                using StreamReader sr = new(filename);
                configString = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
            }

            Dictionary<string, string> dirConig = new(); 

            var cnfstr = configString.Split("\r\n");

            foreach(string item in cnfstr) {
                if(string.IsNullOrEmpty(item)) continue;

                var keyPair = item.Split(':');
                dirConig.Add(keyPair[0].ToLower().Trim(), keyPair[1].Trim());
            }

            return dirConig;
        }

        private void CkbPwView_CheckedChanged(object sender, EventArgs e)
        {
            txbPassword.UseSystemPasswordChar = !ckbPwView.Checked;
            Log.Information(ckbPwView.Checked ? "Password View" : "Password Hide");
        }

        private async void BtnExcuteQuery_Click(object sender, EventArgs e)
        {
            int serverport = int.Parse(txbServerPort.Text.Trim());
            int timeout = int.Parse(txbTimeout.Text.Trim());
            Log.Information($"Start Query: {txbQuery.Text.Trim()}");
            Stopwatch stopwatch = new();
            stopwatch.Start();
            MsSqlLibrary msSql = new(txbServerIP.Text, serverport, txbDBName.Text, txbUserID.Text, txbPassword.Text, timeout);
            DataTable dt = await msSql.AsyncExecuteDataTable(txbQuery.Text.Trim());
            stopwatch.Stop();
            Log.Information($"End Query({stopwatch.ElapsedMilliseconds} ms)");

            Log.Information($"Select Row: {dt.Rows.Count}");
            dgvResult.DataSource = null;
            if(ckbResultView.Checked) {

                dgvResult.DataSource = dt;
            }

        }

        private void BtnClearQuery_Click(object sender, EventArgs e)
        {
            txbQuery.Clear();
            Log.Information("Query Text Clear");
        }

        private void BtnClearLog_Click(object sender, EventArgs e)
        {
            txbDebug.ClearLogs();
        }

        private void CkbResultView_CheckedChanged(object sender, EventArgs e)
        {
            plResultGrid.Visible = ckbResultView.Checked;
        }

        private void BtnSaveCfg_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"ServerIP:{txbServerIP.Text}");
            stringBuilder.AppendLine($"ServerPort:{txbServerPort.Text}");
            stringBuilder.AppendLine($"DBName:{txbDBName.Text}");
            stringBuilder.AppendLine($"userid:{txbUserID.Text}");
            stringBuilder.AppendLine($"password:{new AesCrypt().EncryptString_Aes(txbPassword.Text)}");
            stringBuilder.AppendLine($"timeout:{txbTimeout.Text}");
            stringBuilder.AppendLine($"query:{txbQuery.Text}");

            SaveConfig(@"DatabaseQueryTest01.cfg", stringBuilder.ToString());

            Log.Information("Save Config Complete.");
        }

        private static void SaveConfig(string filename, string cfg)
        {
            using StreamWriter sw = new(filename);
            sw.Write(cfg);
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
    }
}