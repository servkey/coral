using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using taskSender.taskModel;
using taskSender.ServiceReference1;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace taskSender.views
{
    public partial class ScriptMonitor : Form
    {

        taskGen tg;
        ServiceReference1.TaskCatcherClient tc = new ServiceReference1.TaskCatcherClient();
        int currentWindow;
        int aux, aux2;
        randomServiceTask rt;
        List<Task> tareas = new List<Task>();
        string results;

        public ScriptMonitor()
        {
            aux = 1;
            aux2 = 1;
            currentWindow = 0;
            rt = new randomServiceTask();
            tg = new taskGen();
            InitializeComponent();
            fillTables();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearLabels();
            aux2++;
            if(aux2 == 18)
            {
                aux2 = 0;
                resetFrecs();
            }
            if (aux == 6)
            {
                aux = 0;
                currentWindow++;
                window_label.Text = "Ventana: " + currentWindow;
            }
            tareas = tg.GenerateTaks();
            foreach (Task k in tareas)
            {
                results = tc.recieveTaskWithWindow(k, currentWindow);
                if (results != "\n" && results != "\n\n\n\n")
                {
                    Console.WriteLine(results);
                    insertInfo(results);
                }
            }
            aux++;
        }

        private void insertInfo(string result)
        {
            string[] scriptResults;
            string[] results;
            string[] resultData;
            string[] resultDataMatch;
            scriptResults = Regex.Split(result.Trim('\n'),"\n\n");
            foreach (string res in scriptResults)
            {
                if (res.Contains('$'))
                {
                    resultDataMatch = res.Split('$')[1].Split(';');
                    setMatchedScript(resultDataMatch);
                    results = res.Split('$')[0].Split('\n');
                }
                else results = res.Trim('\n').Split('\n');

                foreach (string rd in results)
                {
                    resultData = rd.Split(';');
                    if (resultData[0] == "inactive")
                    {
                        if (resultData[2] == "Alex")
                        {
                            foreach (DataGridViewRow row in inactive_alex.Rows)
                            {
                                if (resultData[1] == row.Cells[0].Value.ToString()) row.Cells[2].Value = Int32.Parse(row.Cells[2].Value.ToString()) + 1;
                            }
                        }
                        else if (resultData[2] == "nakata")
                        {
                            foreach (DataGridViewRow row in inactive_nakata.Rows)
                            {
                                if (resultData[1] == row.Cells[0].Value.ToString()) row.Cells[2].Value = Int32.Parse(row.Cells[2].Value.ToString()) + 1;
                            }
                        }
                        else if (resultData[2] == "kavir")
                        {
                            foreach (DataGridViewRow row in inactive_kavir.Rows)
                            {
                                if (resultData[1] == row.Cells[0].Value.ToString()) row.Cells[2].Value = Int32.Parse(row.Cells[2].Value.ToString()) + 1;
                            }
                        }
                    }
                    else if (resultData[0] == "beginer")
                    {
                        if (resultData[2] == "Alex")
                        {
                            foreach (DataGridViewRow row in beginer_alex.Rows)
                            {
                                if (resultData[1] == row.Cells[0].Value.ToString()) row.Cells[2].Value = Int32.Parse(row.Cells[2].Value.ToString()) + 1;
                            }
                        }
                        else if (resultData[2] == "nakata")
                        {
                            foreach (DataGridViewRow row in beginer_nakata.Rows)
                            {
                                if (resultData[1] == row.Cells[0].Value.ToString()) row.Cells[2].Value = Int32.Parse(row.Cells[2].Value.ToString()) + 1;
                            }
                        }
                        else if (resultData[2] == "kavir")
                        {
                            foreach (DataGridViewRow row in beginer_kavir.Rows)
                            {
                                if (resultData[1] == row.Cells[0].Value.ToString()) row.Cells[2].Value = Int32.Parse(row.Cells[2].Value.ToString()) + 1;
                            }
                        }
                    }

                }
            }
        }

        private void setMatchedScript(string[] matchData)
        {
            if (matchData[1] == "inactive")
            {
                if (matchData[0] == "Alex")
                {
                    match_i_alex.Text = "guion inactivo activado!!";
                }
                else if (matchData[0] == "nakata")
                {
                    match_i_nakata.Text = "guion inactivo activado!!";
                }
                else if (matchData[0] == "kavir")
                {
                    match_i_kavir.Text = "guion inactivo activado!!";
                }
            }
            else if (matchData[1] == "inactive")
            {
                if (matchData[0] == "Alex")
                {
                    match_b_alex.Text = "guion principiante activado!!";
                }
                else if (matchData[0] == "nakata")
                {
                    match_b_nakata.Text = "guion principiante activado!!";
                }
                else if (matchData[0] == "kavir")
                {
                    match_b_kavir.Text = "guion principiante activado!!";
                }
            }
        }

        private void fillTables()
        {
            inactive_alex.Rows.Clear();
            inactive_nakata.Rows.Clear();
            inactive_kavir.Rows.Clear();
            beginer_alex.Rows.Clear();
            beginer_nakata.Rows.Clear();
            beginer_kavir.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=AssaultCube;User ID=SA;Password=a1s2d3";
            SqlCommand cmd = new SqlCommand("getScriptRules", con);
            SqlDataReader set;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@scriptName", SqlDbType.VarChar).Value = "inactive";
            con.Open();
            set = cmd.ExecuteReader();
            while (set.Read())
            {
                inactive_alex.Rows.Add(set.GetString(0).ToString().ToUpper(),set.GetInt32(1),0);
                inactive_nakata.Rows.Add(set.GetString(0).ToString().ToUpper(), set.GetInt32(1), 0);
                inactive_kavir.Rows.Add(set.GetString(0).ToString().ToUpper(), set.GetInt32(1), 0);
            }
            con.Close();

            cmd.Parameters.Clear();
            cmd.Parameters.Add("@scriptName", SqlDbType.VarChar).Value = "beginer";
            con.Open();
            set = cmd.ExecuteReader();
            while (set.Read())
            {
                beginer_alex.Rows.Add(set.GetString(0).ToString().ToUpper(), set.GetInt32(1), 0);
                beginer_nakata.Rows.Add(set.GetString(0).ToString().ToUpper(), set.GetInt32(1), 0);
                beginer_kavir.Rows.Add(set.GetString(0).ToString().ToUpper(), set.GetInt32(1), 0);
            }
            con.Close();
        }

        private void clearLabels()
        {
            match_b_alex.Text = "";
            match_b_nakata.Text = "";
            match_b_kavir.Text = "";
            match_i_alex.Text = "";
            match_i_nakata.Text = "";
            match_i_kavir.Text = "";
        }

        private void resetFrecs()
        {
            foreach (DataGridViewRow row in inactive_alex.Rows)
            {
                row.Cells[2].Value = 0;
            }
            foreach (DataGridViewRow row in inactive_nakata.Rows)
            {
                row.Cells[2].Value = 0;
            }
            foreach (DataGridViewRow row in inactive_kavir.Rows)
            {
                row.Cells[2].Value = 0;
            }
            foreach (DataGridViewRow row in beginer_kavir.Rows)
            {
                row.Cells[2].Value = 0;
            }
            foreach (DataGridViewRow row in beginer_alex.Rows)
            {
                row.Cells[2].Value = 0;
            }
            foreach (DataGridViewRow row in beginer_kavir.Rows)
            {
                row.Cells[2].Value = 0;
            }
        }
    }
}
