Aqui tienes el codigo completo sin tildes, conservando su estructura y funcionamiento:

csharp

```csharp

using System;

class HabitacionHotel
{
    private int numero;
    private string tipo;
    private double precioPorNoche;
    private bool disponible;
    private string clienteActual;

    public int Numero
    {
        get { return numero; }
    }

    public string Tipo
    {
        get { return tipo; }
        set
        {
            if (value == "Individual" || value == "Doble" || value == "Suite")
                tipo = value;
            else
                throw new ArgumentException("Tipo de habitacion no valido.");
        }
    }

    public double PrecioPorNoche
    {
        get { return precioPorNoche; }
        set
        {
            if (value > 0)
                precioPorNoche = value;
            else
                throw new ArgumentException("El precio debe ser mayor a cero.");
        }
    }

    public bool Disponible
    {
        get { return disponible; }
    }

    public string ClienteActual
    {
        get { return clienteActual; }
    }

    public HabitacionHotel(int numero, string tipo, double precioPorNoche)
    {
        this.numero = numero;
        Tipo = tipo;
        PrecioPorNoche = precioPorNoche;
        disponible = true;
        clienteActual = "";
    }

    public double Reservar(string nombreCliente, int noches)
    {
        if (!disponible)
        {
            Console.WriteLine("La habitacion " + numero + " no esta disponible.");
            return -1;
        }

        if (string.IsNullOrWhiteSpace(nombreCliente) || noches <= 0)
        {
            Console.WriteLine("El nombre del cliente y las noches deben ser validos.");
            return -1;
        }

        disponible = false;
        clienteActual = nombreCliente;

        return precioPorNoche * noches;
    }

    public bool Liberar()
    {
        if (!disponible)
        {
            disponible = true;
            clienteActual = "";
            return true;
        }

        return false;
    }

    public string MostrarInfo()
    {
        string estado = disponible ? "Disponible" : "Ocupada";
        string infoCliente = disponible
            ? "Ninguno"
            : clienteActual;

        return "Habitacion: " + numero +
               "\nTipo: " + tipo +
               "\nPrecio por noche: $" + precioPorNoche.ToString("N0") +
               "\nEstado: " + estado +
               "\nCliente actual: " + infoCliente +
               "\n---------------------------";
    }

    public void AplicarDescuento(int porcentaje)
    {
        if (porcentaje < 0 || porcentaje > 100)
        {
            Console.WriteLine("El porcentaje debe estar entre 0 y 100.");
            return;
        }

        precioPorNoche -= precioPorNoche * porcentaje / 100.0;

        if (precioPorNoche < 0)
            precioPorNoche = 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        HabitacionHotel habitacion101 =
            new HabitacionHotel(101, "Individual", 50000);

        HabitacionHotel habitacion202 =
            new HabitacionHotel(202, "Doble", 80000);

        HabitacionHotel habitacion303 =
            new HabitacionHotel(303, "Suite", 150000);

        Console.WriteLine("=== ESTADO INICIAL ===");
        Console.WriteLine(habitacion101.MostrarInfo());
        Console.WriteLine(habitacion202.MostrarInfo());
        Console.WriteLine(habitacion303.MostrarInfo());

        Console.WriteLine("=== OPERACIONES ===");

        double costo = habitacion101.Reservar("Santiago", 3);
        Console.WriteLine("Costo de la reserva de Santiago: $" +
                          costo.ToString("N0"));

        costo = habitacion202.Reservar("Brayan Pinto", 2);
        Console.WriteLine("Costo de la reserva de Brayan Pinto: $" +
                          costo.ToString("N0"));

        costo = habitacion101.Reservar("Otro Cliente", 1);
        Console.WriteLine("Resultado del segundo intento: " + costo);

        bool liberada = habitacion101.Liberar();
        Console.WriteLine("Se libero la habitacion 101? " + liberada);

        habitacion303.AplicarDescuento(10);
        Console.WriteLine("Nuevo precio de la suite: $" +
                          habitacion303.PrecioPorNoche.ToString("N0"));

        costo = habitacion101.Reservar("Carlos Ruiz", 1);
        Console.WriteLine("Costo de la reserva de Carlos Ruiz: $" +
                          costo.ToString("N0"));

        Console.WriteLine("\n=== ESTADO FINAL ===");
        Console.WriteLine(habitacion101.MostrarInfo());
        Console.WriteLine(habitacion202.MostrarInfo());
        Console.WriteLine(habitacion303.MostrarInfo());

        int ocupadas = 0;

        if (!habitacion101.Disponible) ocupadas++;
        if (!habitacion202.Disponible) ocupadas++;
        if (!habitacion303.Disponible) ocupadas++;

        Console.WriteLine("Habitaciones ocupadas: " + ocupadas);
        Console.WriteLine("Fin del programa.");
    }
}
```
