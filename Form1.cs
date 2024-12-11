namespace Gladiador
{

    public partial class Form1 : Form
    {
        private bool tokensadmitidos;
        public Form1()
        {
            tokensadmitidos = false;
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnScanner_Click(object sender, EventArgs e)
        {
            try
            {
                Scanner sc = new Scanner(codigo.Text);
                tokensadmitidos = sc.Analizar();
                salidas.Text = sc.Mensaje;
            }
            catch (Exception ex)
            {
                salidas.Text = ex.Message;

            }
        }

        private void scannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnScanner.Visible = true;
            btnParser.Visible = false;
        }

        private void btnParser_Click(object sender, EventArgs e)
        {
            Sintaxis sintaxis = new Sintaxis(codigo.Text);
            try
            {
                if (!tokensadmitidos)
                {
                    MessageBox.Show("Primero debes generar tokens validos para poder analizar la sintaxis");
                    return;
                }
                sintaxis.Analizar();
                salidas.Text = "Programa sintacticamente correcto";
                salidas.SelectAll();
                salidas.SelectionColor = Color.Green;
            }
            catch (Exception ex)
            {
                salidas.Text = ex.Message;
                salidas.SelectAll();
                salidas.SelectionColor = Color.Red;
            }
        }

        private void parserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnScanner.Visible = false;
            btnParser.Visible = true;
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (abrirDoc.ShowDialog() == DialogResult.OK)
            {
                Archivos.mostrarTexto(codigo, abrirDoc.FileName);
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (salvar_doc.ShowDialog() == DialogResult.OK)
            {
                Archivos.salvarArchivo(codigo, salvar_doc.FileName);
            }
        }
    }
}