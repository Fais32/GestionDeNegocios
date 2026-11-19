using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaLogica
{
    public static class RutValidator
    {
        public static bool EsRutValido(string rut)
        {
            if (string.IsNullOrWhiteSpace(rut))
                return false;
            // Eliminar espacios
            string rutLimpio = Regex.Replace(rut, @"[^\d]", "");
            // 12 dígitos numéricos
            if (rutLimpio.Length != 12)
                return false;
            // departamentos válidos (01 al 21)
            int codigoDepto = int.Parse(rutLimpio.Substring(0, 2));
            if (codigoDepto < 1 || codigoDepto > 21)
                return false;
            // dígitos 3 al 8 no pueden ser cero
            if (rutLimpio.Substring(2, 6) == "000000")
                return false;
            // dígitos 9 y 10 deben ser "00"
            if (rutLimpio.Substring(8, 2) != "00")
                return false;
            // verificación Módulo 11 para el 12vo dígito
            int[] factores = { 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int suma = 0;
            for (int i = 0; i < 11; i++)
            {
                suma += (rutLimpio[i] - '0') * factores[i];
            }
            int resto = suma % 11;
            int digitoVerificadorCalculado = 11 - resto;
            if (digitoVerificadorCalculado == 11)
                digitoVerificadorCalculado = 0;
            else if (digitoVerificadorCalculado == 10)
                digitoVerificadorCalculado = 1;
            int digitoVerificadorReal = rutLimpio[11] - '0';
            return digitoVerificadorCalculado == digitoVerificadorReal;
        }
    }
}