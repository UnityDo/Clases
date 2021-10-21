using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Para crear una libreria, 1 no hereda de MonoBehaviour
//2 tiene que ser estatica, se pueden llamar desde otros codigos, por q permancen en memoria

    public static class OperacionesLibreria
    {

    public static int ElevadoAlCuadrado(int numero)
    {
        return numero * numero;
    }
    public static int ElevadoAX(int numero, int exponente)
    {
        int numeroTemp = 1;
        for (int i = 0; i < exponente; i++)
        {
            numeroTemp *= numero;
        }
        return numeroTemp;
    }
    public static int Factorial(int numero)
        {
            int numeroTemp = 1;
            int contador = numero;
            for (int i = 0; i < contador; i++)
            {
                Debug.Log(numero);
                numeroTemp *= numero;
                numero--;

            }
            //numero-1 *numero-2....1
            //5*4*3*2*1
            Debug.Log("Soy factorial");
            return numeroTemp;

        }
       

        public static bool EsPar(float numero)
        {
            if (numero % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Devuelve true si es par o false si es impar
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static bool EsPar(int numero)
        {
            if (numero % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

   
