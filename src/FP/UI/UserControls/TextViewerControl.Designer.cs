using System.Windows.Forms;
using FreePresenter.UI.Controls;
using VerseFlow.Properties;

namespace FreePresenter.UI.UserControls
{
	partial class TextViewerControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.bar = new System.Windows.Forms.ToolStrip();
			this.cbSearchText = new System.Windows.Forms.ToolStripComboBox();
			this.tsBtnSearch = new System.Windows.Forms.ToolStripSplitButton();
			this.tsCaseSensative = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsAnyWord = new System.Windows.Forms.ToolStripMenuItem();
			this.tsStrictWord = new System.Windows.Forms.ToolStripMenuItem();
			this.tsBtnSearchResults = new System.Windows.Forms.ToolStripButton();
			this.tsBtnFont = new System.Windows.Forms.ToolStripButton();
			this.splitterHorisontal = new System.Windows.Forms.Splitter();
			this.pnlContent = new System.Windows.Forms.Panel();
			this.listViewVerses = new UI.Controls.DbListView();
			this.columnVersesNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnVersesText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.listViewSearchResults = new UI.Controls.DbListView();
			this.columnSearchNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSearchLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSearchVerse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.bar.SuspendLayout();
			this.pnlContent.SuspendLayout();
			this.SuspendLayout();
			// 
			// bar
			// 
			this.bar.AutoSize = false;
			this.bar.BackColor = System.Drawing.Color.LightBlue;
			this.bar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.bar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbSearchText,
            this.tsBtnSearch,
            this.tsBtnSearchResults,
            this.tsBtnFont});
			this.bar.Location = new System.Drawing.Point(0, 0);
			this.bar.Name = "bar";
			this.bar.Padding = new System.Windows.Forms.Padding(2);
			this.bar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.bar.Size = new System.Drawing.Size(340, 30);
			this.bar.TabIndex = 4;
			this.bar.Text = "toolStrip1";
			// 
			// cbSearchText
			// 
			this.cbSearchText.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.cbSearchText.IntegralHeight = false;
			this.cbSearchText.Name = "cbSearchText";
			this.cbSearchText.Size = new System.Drawing.Size(100, 26);
			this.cbSearchText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbSearchText_KeyPress);
			// 
			// tsBtnSearch
			// 
			this.tsBtnSearch.DropDownButtonWidth = 20;
			this.tsBtnSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCaseSensative,
            this.toolStripMenuItem1,
            this.tsAnyWord,
            this.tsStrictWord});
			this.tsBtnSearch.Name = "tsBtnSearch";
			this.tsBtnSearch.Size = new System.Drawing.Size(55, 23);
			this.tsBtnSearch.Text = "Find";
			this.tsBtnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// tsCaseSensative
			// 
			this.tsCaseSensative.Checked = true;
			this.tsCaseSensative.CheckOnClick = true;
			this.tsCaseSensative.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tsCaseSensative.Name = "tsCaseSensative";
			this.tsCaseSensative.Size = new System.Drawing.Size(134, 22);
			this.tsCaseSensative.Text = "Ignore case";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(131, 6);
			// 
			// tsAnyWord
			// 
			this.tsAnyWord.Checked = true;
			this.tsAnyWord.CheckOnClick = true;
			this.tsAnyWord.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tsAnyWord.Name = "tsAnyWord";
			this.tsAnyWord.Size = new System.Drawing.Size(134, 22);
			this.tsAnyWord.Text = "Any word";
			// 
			// tsStrictWord
			// 
			this.tsStrictWord.CheckOnClick = true;
			this.tsStrictWord.Name = "tsStrictWord";
			this.tsStrictWord.Size = new System.Drawing.Size(134, 22);
			this.tsStrictWord.Text = "Strict word";
			this.tsStrictWord.Click += new System.EventHandler(this.tsStrictWord_Clicked);
			// 
			// tsBtnSearchResults
			// 
			this.tsBtnSearchResults.CheckOnClick = true;
			this.tsBtnSearchResults.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBtnSearchResults.Image = Resources.toggle_plus;
			this.tsBtnSearchResults.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnSearchResults.Name = "tsBtnSearchResults";
			this.tsBtnSearchResults.Size = new System.Drawing.Size(23, 23);
			this.tsBtnSearchResults.Text = "Результаты поиска";
			this.tsBtnSearchResults.CheckedChanged += new System.EventHandler(this.tsSearchResults_CheckedChanged);
			// 
			// tsBtnFont
			// 
			this.tsBtnFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsBtnFont.Name = "tsBtnFont";
			this.tsBtnFont.Size = new System.Drawing.Size(35, 23);
			this.tsBtnFont.Text = "Font";
			this.tsBtnFont.Click += new System.EventHandler(this.tsBtnFont_Click);
			// 
			// splitterHorisontal
			// 
			this.splitterHorisontal.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitterHorisontal.Location = new System.Drawing.Point(0, 149);
			this.splitterHorisontal.Name = "splitterHorisontal";
			this.splitterHorisontal.Size = new System.Drawing.Size(340, 3);
			this.splitterHorisontal.TabIndex = 9;
			this.splitterHorisontal.TabStop = false;
			// 
			// pnlContent
			// 
			this.pnlContent.BackColor = System.Drawing.Color.Transparent;
			this.pnlContent.Controls.Add(this.listViewVerses);
			this.pnlContent.Controls.Add(this.splitterHorisontal);
			this.pnlContent.Controls.Add(this.listViewSearchResults);
			this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlContent.Location = new System.Drawing.Point(0, 30);
			this.pnlContent.Name = "pnlContent";
			this.pnlContent.Size = new System.Drawing.Size(340, 294);
			this.pnlContent.TabIndex = 13;
			// 
			// listViewVerses
			// 
			this.listViewVerses.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewVerses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnVersesNumber,
            this.columnVersesText});
			this.listViewVerses.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewVerses.FullRowSelect = true;
			this.listViewVerses.Location = new System.Drawing.Point(0, 152);
			this.listViewVerses.Name = "listViewVerses";
			this.listViewVerses.Size = new System.Drawing.Size(340, 142);
			this.listViewVerses.TabIndex = 12;
			this.listViewVerses.UseCompatibleStateImageBehavior = false;
			this.listViewVerses.View = System.Windows.Forms.View.Details;
			this.listViewVerses.SelectedIndexChanged += new System.EventHandler(this.listViewVerses_SelectedIndexChanged);
			// 
			// columnVersesNumber
			// 
			this.columnVersesNumber.Text = "#";
			this.columnVersesNumber.Width = 30;
			// 
			// columnVersesText
			// 
			this.columnVersesText.Text = "";
			this.columnVersesText.Width = 257;
			// 
			// listViewSearchResults
			// 
			this.listViewSearchResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewSearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSearchNumber,
            this.columnSearchLink,
            this.columnSearchVerse});
			this.listViewSearchResults.Dock = System.Windows.Forms.DockStyle.Top;
			this.listViewSearchResults.FullRowSelect = true;
			this.listViewSearchResults.Location = new System.Drawing.Point(0, 0);
			this.listViewSearchResults.MultiSelect = false;
			this.listViewSearchResults.Name = "listViewSearchResults";
			this.listViewSearchResults.Size = new System.Drawing.Size(340, 149);
			this.listViewSearchResults.TabIndex = 8;
			this.listViewSearchResults.UseCompatibleStateImageBehavior = false;
			this.listViewSearchResults.View = System.Windows.Forms.View.Details;
			this.listViewSearchResults.Visible = false;
			this.listViewSearchResults.SelectedIndexChanged += new System.EventHandler(this.listViewSearchResults_SelectedIndexChanged);
			// 
			// columnSearchNumber
			// 
			this.columnSearchNumber.Text = "#";
			this.columnSearchNumber.Width = 30;
			// 
			// columnSearchLink
			// 
			this.columnSearchLink.Text = "Ref";
			// 
			// columnSearchVerse
			// 
			this.columnSearchVerse.Text = "";
			this.columnSearchVerse.Width = 229;
			// 
			// TextViewerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pnlContent);
			this.Controls.Add(this.bar);
			this.Name = "TextViewerControl";
			this.Size = new System.Drawing.Size(340, 324);
			this.bar.ResumeLayout(false);
			this.bar.PerformLayout();
			this.pnlContent.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip bar;
		private System.Windows.Forms.ToolStripButton tsBtnFont;
		private System.Windows.Forms.ToolStripComboBox cbSearchText;
		private System.Windows.Forms.ToolStripSplitButton tsBtnSearch;
		private System.Windows.Forms.ToolStripMenuItem tsCaseSensative;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem tsAnyWord;
		private System.Windows.Forms.ToolStripMenuItem tsStrictWord;
		private System.Windows.Forms.ToolStripButton tsBtnSearchResults;
		private DbListView listViewSearchResults;
		private ColumnHeader columnSearchNumber;
		private ColumnHeader columnSearchLink;
		private ColumnHeader columnSearchVerse;
		private Splitter splitterHorisontal;
		private DbListView listViewVerses;
		private ColumnHeader columnVersesNumber;
		private ColumnHeader columnVersesText;
		private Panel pnlContent;


	}
}
