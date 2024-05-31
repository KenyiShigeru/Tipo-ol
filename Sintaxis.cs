using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Gladiador
{
    internal class Sintaxis
    {
        private String texto;
        private String encontrado;
        public Sintaxis(String texto) 
        {
            this.texto = texto;
        }
        public void Analizar()
        {
            PROGRAMA();
        }
        private void PROGRAMA()
        {
            if (Regex.IsMatch(texto, "^clase(\\n|\\s)"))
            {
                encontrado = Regex.Match(texto, "^clase(\\n|\\s)").Value;
                texto = Quitar(encontrado);
                if (Regex.IsMatch(texto, "^"+Patrones.id))
                {
                    if(Regex.IsMatch(texto,"^(\\n|\\s)"))
                        texto = EliminarSiguiente();
                    encontrado = Regex.Match(texto, Patrones.id).Value;
                    texto = Quitar(encontrado);
                    BLOQUE();
                }
                else
                    throw new Exception("Se esperaba un nombre para la clase");
            }
            else
                throw new Exception("Se esperaba que el programa Iniciara con la palabra clase");
        }


        private void BLOQUE()
        {
            texto = EliminarSiguiente();
            try
            {
                if (texto[0] != '{')
                    throw new Exception("Se esperaba un {");
                else
                {
                    texto = avanzar();
                    texto = EliminarSiguiente();
                    try
                    {
                        INSTRUCCIONES();
                        try
                        {
                            if (texto[0] != '}')
                            {
                                throw new Exception("Falta la cerradura del bloque de instruccion }");
                            }
                            texto = avanzar();
                            return;
                        }
                        catch
                        {
                            throw new Exception("Se esperaba un }");
                        }
                    }
                    catch(Exception e) 
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
            catch(Exception e) 
            {
                throw new Exception(e.Message);
            }
        }


        private void INSTRUCCIONES()
        {
            texto = EliminarSiguiente();
            while (Regex.IsMatch(texto,Patrones.id))
            {
                encontrado = Regex.Match(texto, "^" + Patrones.id).Value;
                texto = EliminarSiguiente();
                try
                {
                    numeracionReservadas palabra = (numeracionReservadas)Patrones.encontrarReservada(encontrado);
                    switch (palabra)
                    {
                        case numeracionReservadas.mientras:
                            texto = EliminarSiguiente();
                            ESTRUCTURA_DE_CONTROL();
                            break;
                        case numeracionReservadas.si:
                            ESTRUCTURA_DE_CONTROL();
                            break;
                        case numeracionReservadas.leer:
                            ENTRADA();
                            break;
                        case numeracionReservadas.variables:
                            DECLARACION();
                            break;
                        case numeracionReservadas.imprimir:
                            ESCRIBIR();
                            break;
                        case numeracionReservadas.entonces:
                            throw new Exception("Se esperaba que pusieras primero una condicion");
                        default:
                            throw new Exception("Se esperaba una instruccion valida");
                    }
                    texto= EliminarSiguiente();
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        

        private void ENTRADA()
        {
            texto = Quitar(encontrado);
            texto = EliminarSiguiente();
            if (texto[0] != Patrones.especiales.ElementAt((int)numeracionespeciales.parentesisabre))
            {
                throw new Exception("Se esperaba un (");
            }
            texto = avanzar();
            texto = EliminarSiguiente();
            encontrado = TERMINO();
            texto = Quitar(encontrado);
            texto = EliminarSiguiente();
            if (encontrado == "")
                throw new Exception("Se esperaba una variable");
            if (texto[0] != Patrones.especiales.ElementAt((int)numeracionespeciales.parentesiscierre))
                throw new Exception("Se esperaba que cierre el parentesis");
            texto = avanzar();
            texto = EliminarSiguiente();
            if (texto[0] != Patrones.especiales.ElementAt((int)numeracionespeciales.puntoycoma))
                throw new ErrorPuntoyComa();
            texto = avanzar();
        }

        private void ESCRIBIR()
        {
            texto = Quitar(encontrado);
            texto = EliminarSiguiente();
            if (texto[0] != Patrones.especiales.ElementAt((int) numeracionespeciales.parentesisabre))
            {
                throw new Exception("Se esperaba un (");
            }
            texto = avanzar();
            texto = EliminarSiguiente();
            encontrado = TERMINO();
            texto = Quitar(encontrado);
            texto = EliminarSiguiente();
            if (encontrado == "")
                throw new Exception("Se requiere una instruccion para mostrar en pantalla");
            if (texto[0] != Patrones.especiales.ElementAt((int)numeracionespeciales.parentesiscierre))
                throw new Exception("Se esperaba que cierre el parentesis");
            texto = avanzar();
            texto = EliminarSiguiente();
            if (texto[0] != Patrones.especiales.ElementAt((int)numeracionespeciales.puntoycoma))
                throw new ErrorPuntoyComa();
            texto = avanzar();
        }

        private void ESTRUCTURA_DE_CONTROL()
        {
            texto = Quitar(encontrado);
            texto = EliminarSiguiente();
            COMPARACION();
            BLOQUE();
        }

        private void ASIGNACION()
        {

            texto = EliminarSiguiente();
            texto = avanzar();
            texto = EliminarSiguiente();
            encontrado = TERMINO();
            texto = EliminarSiguiente();
            if (encontrado == "")
                throw new Exception("Se esperaba que asginara un valor a la variable");
            texto = Quitar(encontrado);
            texto = EliminarSiguiente();
            if (texto[0] != Patrones.especiales.ElementAt((int)numeracionespeciales.puntoycoma))
                throw new ErrorPuntoyComa();
            texto = avanzar();
            return;
            #region Documentacion del funcionamiento ASIGNACION

            #endregion
        }

        private void DECLARACION()
        {
            texto = Quitar(encontrado);
            texto=EliminarSiguiente();
            encontrado = Regex.Match(texto, Patrones.id).Value;
            if (Patrones.reservada.Contains(encontrado))
                throw new Exception("No se puede usar una palabra reservada como identificador");
            texto = Quitar(encontrado);
            texto = EliminarSiguiente();
            if (texto[0] != Patrones.especiales.ElementAt((int)numeracionespeciales.DOBLEPUNTO))
                throw new Exception("Se esperaba que definieras un tipo de dato con \":\" \nSintaxis: variable NOMBRE_VARIABLE: TIPODATO[entero, flotante, caracter, boleano]");
            texto = avanzar();
            texto=EliminarSiguiente();
            encontrado = Regex.Match(texto, Patrones.id).Value;
            if (!Patrones.tipodedato.Contains(encontrado))
                throw new Exception("Se debe poner un tipo de dato valido [entero, flotante, caracter, boleano]");
            texto = Quitar(encontrado);
            texto = EliminarSiguiente();

            #region Zona de cambio al punto y coma por asignacion

            char actual = texto[0];
            if (actual == Patrones.especiales.ElementAt((int)numeracionespeciales.puntoycoma))
            {
                texto = avanzar();
                return;
            }
            else if (actual == Patrones.especiales.ElementAt((int)numeracionespeciales.igual))
            {
                ASIGNACION();
            }
            else
                throw new ErrorPuntoyComa();
            #endregion 

            #region programa que funciona con el punto y coma
            /*f (texto[0] != Patrones.especiales.ElementAt((int)numeracionespeciales.puntoycoma))
                throw new Exception("Se esperaba que terminaras la instruccion con un punto y coma");
            texto = avanzar();*/
            #endregion



            #region Documentacion funcionamiento DECLARACION
            /*
                    TIPO -> int | boleano | caracter | flotante
                    Declaracion ->  variable IDENTIFICADOR:TIPO;

                VAMOS A EMPEZAR BUSCANDO ESAS PALABRAS RESERVADAS
                SI LAS ENCUENTRA PASAMOS A LA DECLARACION QUE ES
                PONER UNA IDENTIFICADOR QUE SERIA EL NOMBRE DE LA 
                VARIABLE QUE SERÁ RECONOCIBLE PARA EL PROGRAMADOR DE
                ALLÍ QUE SE LLAME IDENTIFICADOR
             */
            #endregion
        }

        private void COMPARACION()
        {
            texto = EliminarSiguiente();
            if (Patrones.especiales.ElementAt((int)numeracionespeciales.parentesisabre) == texto[0])
            {
                texto = EliminarSiguiente();
                String patron = "^(" + Patrones.id + "|" + Patrones.numero +//Separe el codigo para que sea mas pequeno
                    ")";
                texto = avanzar();
                encontrado = Regex.IsMatch(texto,patron)? Regex.Match(texto,patron).Value: "";
                if (encontrado == "")
                    throw new Exception("No se encontro una instruccion valida");
                else
                {
                    if (Regex.IsMatch(texto,Patrones.id))
                    {
                        texto = Quitar(encontrado);
                        texto = EliminarSiguiente();
                        encontrado = texto.Substring(0, 2);
                        if (Patrones.opRelac.Contains(encontrado))
                        {
                            texto = Quitar(encontrado);
                            try {
                                COMPARACION(); 
                            } 
                            catch 
                            {
                                encontrado = TERMINO();;
                                texto = Quitar(encontrado);
                                texto = avanzar();
                                return;
                            }
                            texto = avanzar();
                            texto = EliminarSiguiente();
                            texto = avanzar();
                            texto = EliminarSiguiente();
                            encontrado = TERMINO();;
                            texto = Quitar(encontrado);
                        }
                    }
                }
                if (texto[0] != Patrones.especiales.ElementAt((int)numeracionespeciales.parentesiscierre))
                    throw new Exception("Se esperaba un )");
                texto = avanzar();
                return;
            }
            else
                throw new Exception("Se esperaba iniciara con un parentesis (");
        }

        private String Quitar(String quitar)
        {
            return texto.Substring(quitar.Length);
        }

        private String EliminarSiguiente()
        {
            String expr = "^(\\n|\\s)+";
            return Regex.IsMatch(texto, expr)? 
                texto.Substring(Regex.Match(texto, expr).Length) : texto;
        }

        private String avanzar()
        {
            return texto.Substring(1);
        }
        
        public String TERMINO()
        {
            String patron = "^(" + Patrones.id + "|" + Patrones.numero +//Separe el codigo para que sea mas pequeno
                ")";
            return Regex.IsMatch(texto, patron) ? Regex.Match(texto, patron).Value : ""; 
        }
    }
}
