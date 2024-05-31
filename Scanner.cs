using System;
using System.Text.RegularExpressions;

/*Los Region no hacen nada al código solo son como comentarios y sirven para agrupar el código
de esa manera se trabaja sin tanto codigo estorboso y se accedemejor a ciertas partes del programa*/

namespace Gladiador
{
    internal class Scanner
    {
        String fuente;
        String mensaje;
        public Scanner(String fuente)
        {
            this.fuente = fuente;
            mensaje = "";
        }

        public bool Analizar()
        {
            String encontrado;
            bool retorno = false;
            if (fuente.Length == 0)
            {
                throw new Exception("No debe dejar el campo de texto vacio");
            }
            while (fuente.Length > 0)
            {
                
                
                if (Regex.IsMatch(fuente,"^"+Patrones.id))
                {
                    encontrado = Regex.Match(fuente, Patrones.id).Value;
                    if (Patrones.reservada.Contains(encontrado))
                    {
                        fuente = fuente.Substring(encontrado.Length);
                        retorno = generarElmensaje(encontrado, TipoToken.reservada);
                        continue;
                    }
                        fuente = fuente.Substring(encontrado.Length);
                        retorno = generarElmensaje(encontrado, TipoToken.id);
                        continue;
                }
                else if (Regex.IsMatch(fuente, "^"+Patrones.opRelac))
                {
                    encontrado = Regex.Match(fuente, Patrones.opRelac).Value;
                    fuente = fuente.Substring(encontrado.Length);
                    retorno = generarElmensaje(encontrado, TipoToken.opRelac);
                    continue;
                }

                else if( Regex.IsMatch(fuente,"^" + Patrones.numero))
                {
                    encontrado = Regex.Match(fuente,Patrones.numero).Value;
                    fuente = fuente.Substring(encontrado.Length);
                    retorno = generarElmensaje(encontrado, TipoToken.numerico);
                    continue;
                }
                else if(Regex.IsMatch(fuente,"^="))
                {
                    fuente = fuente.Substring(1);
                    retorno = generarElmensaje("=",TipoToken.asignacion);
                    continue;
                }
                else
                {
                    if (fuente[0] == ' ' | fuente[0] == '\n')
                    {
                        fuente = fuente.Substring(1);
                        continue;
                    }
                    if (Patrones.especiales.Contains(fuente[0]))
                    {
                        encontrado = fuente[0].ToString();
                        fuente = fuente.Substring(1);
                        retorno = generarElmensaje(encontrado, TipoToken.caracter_especial);
                        continue;
                    }
                    encontrado = fuente[0].ToString();
                    fuente = fuente.Substring(1);
                    retorno = generarElmensaje(encontrado,0);
                    fuente = "";
                }
            }

            return retorno;
        }

        #region Creacion del mensaje a imprimir

        public bool generarElmensaje(string caracteres, TipoToken token)
        {

            switch (token)
            {
                #region Cases
                case TipoToken.id:
                    mensaje += (caracteres + " es un identificador\n");
                    return true;
                case TipoToken.asignacion:
                    mensaje += " = es un caracter de asignación\n";
                    return true;
                case TipoToken.comentario:
                    mensaje += (caracteres + " es un comentario\n");
                    return true;
                case TipoToken.opRelac:
                    mensaje += (caracteres + " es un operador relacional\n");
                    return true;
                case TipoToken.reservada:
                    mensaje += (caracteres + " es una palabra reservada\n");
                    return true;
                case TipoToken.numerico:
                    mensaje += (caracteres + " es un numero\n");
                    return true;
                case TipoToken.caracter_especial:
                    mensaje += (caracteres + " es un caracter especial admitido\n");
                    return true;
                case 0:/*Aqui se pone Cero por que TipoToken es un contador y al no haber coincidencias significa que no se le pudo dar un
                    numero de tipo de token*/
                    mensaje += (caracteres + " es un token invalido\n");
                    return false;
                    #endregion
            }
            return false;
        }
        #endregion

        public string Mensaje
        {
            get { return mensaje; }
        }
    }
}
