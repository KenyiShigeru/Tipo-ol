using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiador
{
    internal class Patrones
    {
        public static String id = "([a-z]|[A-Z]|ñ|Ñ)+([A-Z]|_|[a-z]|[1-9]|ñ|Ñ)*";
        public static String opRelac = "(<=|>=|==|!=)";
         
        public String comentario = "(\\/\\*(\\n|\\s*|.*?)*\\*\\/)|(\\/\\/.*)";
        //Palabras reservadas

        public static LinkedList<String> tipodedato = new LinkedList<String>(new String[] {"entero", "flotante", "caracter", "boleano"});

        public static LinkedList<String> reservada = new LinkedList<String>(new String[] {"clase","mientras","si","entonces", "leer","imprimir","variable"});

        public static int encontrarReservada(String id)
        {
            int pos = 0;
            while (reservada.Contains(id))
            {
                pos++;
                if(id == reservada.ElementAt(pos))
                    return pos;
            }
            return pos;
        }
        


        #region Caracteres especiales
        
        
        public static LinkedList<char> especiales = new LinkedList<char>(new char[] {'(',')','{','}','[',']',',',';','=',':'});
        public static int encontrarEspeciales(char id)
        {
            int pos = 0;
            while (especiales.Contains(id))
            {
                pos++;
                if (id == especiales.ElementAt(pos))
                    return pos;
            }
            return pos;
        }

        

        #endregion

        #region Declaracion de los numeros
        public static String digito = "[0-9]"; 
        public static String digitos = "(" + digito + "+)";
        public static String decimales = "(\\." + digitos + "|)";
        public static String exponente = "(E(\\+|\\-|)" + digitos + "|)";
        public static String numero = digitos + decimales + exponente;
        #endregion
    }

    public enum numeracionespeciales
    {
        parentesisabre, parentesiscierre, bracketabre, bracketcierra, corcheteabre, corchetecierra, punto, puntoycoma, igual, DOBLEPUNTO
    }

    public enum numeracionReservadas
    {
        clase, mientras, si, entonces, leer, imprimir,variables
    }

    public enum TipoToken
    {
        Inicio, id, opRelac, comentario, asignacion, reservada, numerico, caracter_especial
    }

    public enum relacionales
    {
        menor, mayor, menorigual, mayorigual, igual
    }
}
