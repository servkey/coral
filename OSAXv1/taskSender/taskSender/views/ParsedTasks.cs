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

namespace taskSender.views
{
    public partial class ParsedTasks : Form
    {

        taskGen tg;
        List<Task> parsedTasks;

        public ParsedTasks()
        {
            InitializeComponent();
            tg = new taskGen();
            parsedTasks = new List<Task>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parsedTasks = tg.GenerateTaks();
            addTasksToGrid();
        }

        private void addTasksToGrid()
        {
            foreach (Task tk in parsedTasks)
            {
                dataGridView1.Rows.Add(tk.taskName, tk.executorActor.instances[0], tk.effective, tk.involve, tk.assign, tk.outcome);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
