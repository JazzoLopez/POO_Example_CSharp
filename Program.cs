using System;
using System.Collections.Generic;

internal class Program
{
    public delegate double OperacionMatematica(double a, double b);

    private static void Main(string[] args)
    {
        Operaciones op = new Operaciones();
        double[] vectorA = [10.5, 20.0, 30.0, 40.0, 50.0];
        double[] vectorB = [2.0, 5.0, 10.0, 4.0, 2.0];

        Console.WriteLine("=== RESULTADOS DE OPERACIONES CON VECTORES ===");

        Console.WriteLine("\nSUMA:");
        ImprimirVector(Apply(vectorA, vectorB, op.Sumar));

        Console.WriteLine("\nRESTA:");
        ImprimirVector(Apply(vectorA, vectorB, op.Restar));

        Console.WriteLine("\nMULTIPLICACIÓN:");
        ImprimirVector(Apply(vectorA, vectorB, op.Multiplicar));

        Console.WriteLine("\nDIVISIÓN:");
        try
        {
            ImprimirVector(Apply(vectorA, vectorB, op.Dividir));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static double[] Apply(double[] v1, double[] v2, OperacionMatematica operacion)
    {
        if (v1.Length != v2.Length)
            throw new Exception("Los vectores deben tener la misma longitud.");

        double[] resultado = new double[v1.Length];

        for (int i = 0; i < v1.Length; i++)
        {
            //? USO DEL DELEGADO PARA REALIZAR LA OPERACIÓN
            resultado[i] = operacion(v1[i], v2[i]);
        }

        return resultado;
    }

    public static void ImprimirVector(double[] v)
    {
        Console.WriteLine("[" + string.Join(", ", v) + "]");
    }

    public interface IOperaciones
    {
        double Sumar(double a, double b);
        double Restar(double a, double b);
        double Multiplicar(double a, double b);
        double Dividir(double a, double b);
    }

    public class Operaciones : IOperaciones
    {
        public double Sumar(double a, double b) => a + b;
        public double Restar(double a, double b) => a - b;
        public double Multiplicar(double a, double b) => a * b;
        public double Dividir(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("Error: División por cero.");
            return a / b;
        }
    }
}