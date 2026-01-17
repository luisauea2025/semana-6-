using System;

public class Nodo {
    public int Dato { get; set; }
    public Nodo Siguiente { get; set; }
    public Nodo(int dato) { Dato = dato; Siguiente = null; }
}

public class ListaAleatoria {
    private Nodo cabeza;

    public void Insertar(int valor) {
        Nodo nuevo = new Nodo(valor);
        if (cabeza == null) cabeza = nuevo;
        else {
            Nodo actual = cabeza;
            while (actual.Siguiente != null) actual = actual.Siguiente;
            actual.Siguiente = nuevo;
        }
    }

    public void EliminarFueraDeRango(int min, int max) {
        while (cabeza != null && (cabeza.Dato < min || cabeza.Dato > max))
            cabeza = cabeza.Siguiente;

        Nodo actual = cabeza;
        while (actual != null && actual.Siguiente != null) {
            if (actual.Siguiente.Dato < min || actual.Siguiente.Dato > max)
                actual.Siguiente = actual.Siguiente.Siguiente;
            else
                actual = actual.Siguiente;
        }
    }

    public void Mostrar() {
        Nodo actual = cabeza;
        while (actual != null) {
            Console.Write(actual.Dato + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
}

class Program {
    static void Main() {
        ListaAleatoria lista = new ListaAleatoria();
        Random rnd = new Random();

        for (int i = 0; i < 50; i++) lista.Insertar(rnd.Next(1, 1000));

        Console.WriteLine("LISTA ORIGINAL:");
        lista.Mostrar();

        Console.Write("\nIngrese Rango Minimo: ");
        int min = int.Parse(Console.ReadLine());
        Console.Write("Ingrese Rango Maximo: ");
        int max = int.Parse(Console.ReadLine());

        lista.EliminarFueraDeRango(min, max);
        Console.WriteLine("\nLISTA FILTRADA:");
        lista.Mostrar();
    }
}