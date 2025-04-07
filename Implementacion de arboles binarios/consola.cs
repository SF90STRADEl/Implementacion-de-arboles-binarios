using System;

class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree bst = new BinarySearchTree();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Insertar nodo");
            Console.WriteLine("2. Eliminar nodo");
            Console.WriteLine("3. Buscar nodo");
            Console.WriteLine("4. Recorrido PreOrden");
            Console.WriteLine("5. Recorrido InOrden");
            Console.WriteLine("6. Recorrido PostOrden");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out int option))
            {
                Console.WriteLine("Opción inválida. Intente de nuevo.");
                continue;
            }

            switch (option)
            {
                case 1:
                    Console.Write("Ingrese el valor a insertar: ");
                    if (int.TryParse(Console.ReadLine(), out int insertValue))
                    {
                        bst.Insert(insertValue);
                        Console.WriteLine($"Valor {insertValue} insertado.");
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;
                case 2:
                    Console.Write("Ingrese el valor a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteValue))
                    {
                        bool found = bst.Search(deleteValue);
                        if (found)
                        {
                            bst.Delete(deleteValue);
                            Console.WriteLine($"Valor {deleteValue} eliminado.");
                        }
                        else
                        {
                            Console.WriteLine($"Valor {deleteValue} no encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;
                case 3:
                    Console.Write("Ingrese el valor a buscar: ");
                    if (int.TryParse(Console.ReadLine(), out int searchValue))
                    {
                        bool found = bst.Search(searchValue);
                        Console.WriteLine(found ? "Valor encontrado." : "Valor no encontrado.");
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;
                case 4:
                    Console.WriteLine("Recorrido PreOrden: " + bst.PreOrder());
                    break;
                case 5:
                    Console.WriteLine("Recorrido InOrden: " + bst.InOrder());
                    break;
                case 6:
                    Console.WriteLine("Recorrido PostOrden: " + bst.PostOrder());
                    break;
                case 7:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
        }
    }
}