using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Gladiador
{
    internal class AnalizadorSemantico
    {
        private readonly Sintaxis sintaxis;

        public AnalizadorSemantico(Sintaxis sintaxis)
        {
            this.sintaxis = sintaxis;
        }

        public void AnalizarSemantica()
        {
            try
            {
                VerificarDeclaracionVariables();
                VerificarAsignacionTipos();
                VerificarControlFlujo();
                VerificarImpresionEntrada();
                Console.WriteLine("Análisis semántico completado sin errores.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error semántico: " + ex.Message);
            }
        }

        private void VerificarDeclaracionVariables()
        {
            HashSet<string> variablesDeclaradas = new HashSet<string>();

            foreach (var instruccion in sintaxis.ObtenerInstrucciones())
            {
                if (instruccion is DeclaracionVariable declaracion)
                {
                    if (variablesDeclaradas.Contains(declaracion.Nombre))
                    {
                        throw new Exception($"La variable '{declaracion.Nombre}' ya ha sido declarada.");
                    }

                    variablesDeclaradas.Add(declaracion.Nombre);
                }
            }
        }

        private void VerificarAsignacionTipos()
        {
            foreach (var instruccion in sintaxis.ObtenerInstrucciones())
            {
                if (instruccion is Asignacion asignacion)
                {
                    var tipoVariable = sintaxis.ObtenerTipoVariable(asignacion.Variable);
                    var tipoExpresion = ObtenerTipoExpresion(asignacion.Expresion);

                    if (tipoVariable != tipoExpresion)
                    {
                        throw new Exception($"Error de tipo en la asignación a '{asignacion.Variable}'. Se esperaba un {tipoVariable} pero se encontró un {tipoExpresion}.");
                    }
                }
            }
        }

        private void VerificarControlFlujo()
        {
            foreach (var instruccion in sintaxis.ObtenerInstrucciones())
            {
                if (instruccion is EstructuraControl estructuraControl)
                {
                    var tipoExpresion = ObtenerTipoExpresion(estructuraControl.Condicion);

                    if (tipoExpresion != TipoExpresion.Booleano)
                    {
                        throw new Exception("La condición en la estructura de control debe ser una expresión booleana.");
                    }
                }
            }
        }

        private void VerificarImpresionEntrada()
        {
            foreach (var instruccion in sintaxis.ObtenerInstrucciones())
            {
                if (instruccion is Entrada entrada)
                {
                    if (!sintaxis.ExisteVariableDeclarada(entrada.Variable))
                    {
                        throw new Exception($"La variable '{entrada.Variable}' utilizada en la entrada no ha sido declarada.");
                    }
                }
                else if (instruccion is Impresion impresion)
                {
                    var tipoExpresion = ObtenerTipoExpresion(impresion.Expresion);

                    if (tipoExpresion == TipoExpresion.Desconocido)
                    {
                        throw new Exception("No se puede determinar el tipo de la expresión en la instrucción de impresión.");
                    }
                }
            }
        }

        private TipoExpresion ObtenerTipoExpresion(string expresion)
        {
            // Implementar la lógica para determinar el tipo de la expresión.
            // Aquí asumiremos que todas las expresiones son cadenas por simplicidad.
            return TipoExpresion.Cadena;
        }
    }

    public enum TipoExpresion
    {
        Entero,
        Flotante,
        Caracter,
        Booleano,
        Cadena,
        Desconocido
    }
}
