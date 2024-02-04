namespace EasyGalaxySwapper
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.actions_run = new System.Windows.Forms.Button();
            this.link_discord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 215);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(49, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "EasyGalaxy Swapper";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 10F);
            this.label3.Location = new System.Drawing.Point(19, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(309, 38);
            this.label3.TabIndex = 2;
            this.label3.Text = "β教祖が作成したEasyGalaxy SwapperのGUI版です。\r\n製作者には敬意を持ちましょう。";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this.label5.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label5.Location = new System.Drawing.Point(19, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "ダウンロードを開始してください";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // actions_run
            // 
            this.actions_run.ForeColor = System.Drawing.Color.Black;
            this.actions_run.Location = new System.Drawing.Point(24, 160);
            this.actions_run.Name = "actions_run";
            this.actions_run.Size = new System.Drawing.Size(171, 33);
            this.actions_run.TabIndex = 6;
            this.actions_run.Text = "ダウンロードを開始";
            this.actions_run.UseVisualStyleBackColor = true;
            this.actions_run.Click += new System.EventHandler(this.button1_Click);
            // 
            // link_discord
            // 
            this.link_discord.ForeColor = System.Drawing.Color.Black;
            this.link_discord.Location = new System.Drawing.Point(201, 160);
            this.link_discord.Name = "link_discord";
            this.link_discord.Size = new System.Drawing.Size(113, 33);
            this.link_discord.TabIndex = 8;
            this.link_discord.Text = "公式Discord";
            this.link_discord.UseVisualStyleBackColor = true;
            this.link_discord.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(20)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(339, 214);
            this.Controls.Add(this.link_discord);
            this.Controls.Add(this.actions_run);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "EasyGalaxy Swapper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button actions_run;
        private System.Windows.Forms.Button link_discord;
    }
}

