namespace Gladiador
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            guardarToolStripMenuItem = new ToolStripMenuItem();
            abrirToolStripMenuItem = new ToolStripMenuItem();
            fasesToolStripMenuItem = new ToolStripMenuItem();
            scannerToolStripMenuItem = new ToolStripMenuItem();
            parserToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            pnlscnnr = new Panel();
            btnParser = new Button();
            btnScanner = new Button();
            salidas = new RichTextBox();
            codigo = new RichTextBox();
            abrirDoc = new OpenFileDialog();
            salvar_doc = new SaveFileDialog();
            menuStrip1.SuspendLayout();
            pnlscnnr.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, fasesToolStripMenuItem, salirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1904, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { guardarToolStripMenuItem, abrirToolStripMenuItem });
            archivoToolStripMenuItem.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(106, 36);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // guardarToolStripMenuItem
            // 
            guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            guardarToolStripMenuItem.Size = new Size(180, 36);
            guardarToolStripMenuItem.Text = "Guardar";
            guardarToolStripMenuItem.Click += guardarToolStripMenuItem_Click;
            // 
            // abrirToolStripMenuItem
            // 
            abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            abrirToolStripMenuItem.Size = new Size(180, 36);
            abrirToolStripMenuItem.Text = "Abrir";
            abrirToolStripMenuItem.Click += abrirToolStripMenuItem_Click;
            // 
            // fasesToolStripMenuItem
            // 
            fasesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { scannerToolStripMenuItem, parserToolStripMenuItem });
            fasesToolStripMenuItem.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            fasesToolStripMenuItem.Name = "fasesToolStripMenuItem";
            fasesToolStripMenuItem.Size = new Size(82, 36);
            fasesToolStripMenuItem.Text = "Fases";
            // 
            // scannerToolStripMenuItem
            // 
            scannerToolStripMenuItem.Name = "scannerToolStripMenuItem";
            scannerToolStripMenuItem.Size = new Size(173, 36);
            scannerToolStripMenuItem.Text = "Scanner";
            scannerToolStripMenuItem.Click += scannerToolStripMenuItem_Click;
            // 
            // parserToolStripMenuItem
            // 
            parserToolStripMenuItem.Name = "parserToolStripMenuItem";
            parserToolStripMenuItem.Size = new Size(173, 36);
            parserToolStripMenuItem.Text = "Parser";
            parserToolStripMenuItem.Click += parserToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(71, 36);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // pnlscnnr
            // 
            pnlscnnr.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlscnnr.AutoSize = true;
            pnlscnnr.Controls.Add(btnParser);
            pnlscnnr.Controls.Add(btnScanner);
            pnlscnnr.Controls.Add(salidas);
            pnlscnnr.Controls.Add(codigo);
            pnlscnnr.Location = new Point(0, 43);
            pnlscnnr.Name = "pnlscnnr";
            pnlscnnr.Size = new Size(1904, 1015);
            pnlscnnr.TabIndex = 1;
            // 
            // btnParser
            // 
            btnParser.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnParser.Location = new Point(884, 488);
            btnParser.Name = "btnParser";
            btnParser.Size = new Size(123, 80);
            btnParser.TabIndex = 3;
            btnParser.Text = "Parser";
            btnParser.UseVisualStyleBackColor = true;
            btnParser.Visible = false;
            btnParser.Click += btnParser_Click;
            // 
            // btnScanner
            // 
            btnScanner.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnScanner.Location = new Point(884, 488);
            btnScanner.Name = "btnScanner";
            btnScanner.Size = new Size(123, 80);
            btnScanner.TabIndex = 2;
            btnScanner.Text = "Scanner";
            btnScanner.UseVisualStyleBackColor = true;
            btnScanner.Click += btnScanner_Click;
            // 
            // salidas
            // 
            salidas.Dock = DockStyle.Right;
            salidas.Font = new Font("Segoe UI Black", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            salidas.Location = new Point(1092, 0);
            salidas.Name = "salidas";
            salidas.Size = new Size(812, 1015);
            salidas.TabIndex = 1;
            salidas.Text = "";
            // 
            // codigo
            // 
            codigo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            codigo.Font = new Font("Segoe UI Black", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            codigo.Location = new Point(3, 3);
            codigo.Name = "codigo";
            codigo.Size = new Size(759, 1009);
            codigo.TabIndex = 0;
            codigo.Text = "";
            // 
            // abrirDoc
            // 
            abrirDoc.FileName = "openFileDialog1";
            abrirDoc.Filter = "Archivos de tipo Ken(*.ken)|*.ken|Archivo de texto(*.txt)|*.txt";
            abrirDoc.Tag = "";
            // 
            // salvar_doc
            // 
            salvar_doc.Filter = "Archivos de tipo Ken(*.ken)|*.ken|Archivo de texto(*.txt)|*.txt";
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            int width = Screen.PrimaryScreen.Bounds.Width-16;
            int height = Screen.PrimaryScreen.Bounds.Height-65;
            ClientSize = new Size(width, height);
            Controls.Add(pnlscnnr);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Gladiador";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlscnnr.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem guardarToolStripMenuItem;
        private ToolStripMenuItem abrirToolStripMenuItem;
        private ToolStripMenuItem fasesToolStripMenuItem;
        private ToolStripMenuItem scannerToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private Panel pnlscnnr;
        private RichTextBox salidas;
        private RichTextBox codigo;
        private Button btnScanner;
        private ToolStripMenuItem parserToolStripMenuItem;
        private Button btnParser;
        private OpenFileDialog abrirDoc;
        private SaveFileDialog salvar_doc;
    }
}