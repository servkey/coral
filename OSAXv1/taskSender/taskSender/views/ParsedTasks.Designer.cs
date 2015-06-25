namespace taskSender.views
{
    partial class ParsedTasks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.effectiveness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.involvement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assignment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outcome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AccessibleName = "taskTable";
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.task,
            this.user,
            this.effectiveness,
            this.involvement,
            this.assignment,
            this.outcome});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(693, 624);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(711, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "GenerarTareas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // task
            // 
            this.task.HeaderText = "Tarea";
            this.task.Name = "task";
            this.task.ReadOnly = true;
            // 
            // user
            // 
            this.user.HeaderText = "Usuario";
            this.user.Name = "user";
            this.user.ReadOnly = true;
            // 
            // effectiveness
            // 
            this.effectiveness.HeaderText = "Efectividad";
            this.effectiveness.Name = "effectiveness";
            this.effectiveness.ReadOnly = true;
            // 
            // involvement
            // 
            this.involvement.HeaderText = "participación";
            this.involvement.Name = "involvement";
            this.involvement.ReadOnly = true;
            // 
            // assignment
            // 
            this.assignment.HeaderText = "asignación";
            this.assignment.Name = "assignment";
            this.assignment.ReadOnly = true;
            // 
            // outcome
            // 
            this.outcome.HeaderText = "resultado";
            this.outcome.Name = "outcome";
            this.outcome.ReadOnly = true;
            this.outcome.Width = 150;
            // 
            // ParsedTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 648);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ParsedTasks";
            this.Text = "ParsedTasks";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn task;
        private System.Windows.Forms.DataGridViewTextBoxColumn user;
        private System.Windows.Forms.DataGridViewTextBoxColumn effectiveness;
        private System.Windows.Forms.DataGridViewTextBoxColumn involvement;
        private System.Windows.Forms.DataGridViewTextBoxColumn assignment;
        private System.Windows.Forms.DataGridViewTextBoxColumn outcome;
    }
}