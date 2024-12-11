using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Gladiador
{
    class Archivos
    {


        public static void salvarArchivo(RichTextBox textBox, String url)
        {
            TextWriter salvar;
            try
            {
                salvar = new StreamWriter(url);
                char[] texto = textBox.Text.ToArray();
                for (int i = 0; i < texto.Length; i++)
                {
                    salvar.Write(texto[i]);
                }
                salvar.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void mostrarTexto(RichTextBox texto, String url)
        {
            texto.Text = "";
            TextReader recuperar;
            try
            {
                recuperar = new StreamReader(url);
                texto.Text = recuperar.ReadToEnd();
                recuperar.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
