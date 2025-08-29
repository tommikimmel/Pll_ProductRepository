using Pll_ProductRepository.Dominio;
using Pll_ProductRepository.Servicios;
using System;

ProductServices services = new ProductServices();

List<Product> lp = services.GetProducts();

if (lp.Count > 0)
    foreach (Product p in lp)
        Console.WriteLine(p.ToString());
else
    Console.WriteLine("No hay productos");

//Obtener producto por ID
Console.WriteLine("Obtener un producto por ID");
int id = 1;
Product? prod = services.GetProductById(id);

if (prod != null)
    Console.WriteLine("Producto encontrado: " + prod.ToString());
else
    Console.WriteLine($"No se encontró producto con ID = {id}");

//Dar de baja un producto
Console.WriteLine("Dar de baja un producto por ID");
id = 2;
bool producto = services.DeleteProduct(id);
if (prod != null)
    Console.WriteLine($"Producto dado de baja con exito: {id}");
else
    Console.WriteLine($"No se encontro el producto con ID = {id}");

//Insercion de un producto
Console.WriteLine("Insercion de un producto");
Product newProduct = new Product()
{
    codigo = 0, // El codigo se autogenera en la base de datos
    nombre = "Producto de prueba 2",
    stock = 4,
    precio = 200,
    activo = true
};

bool resultado = services.SaveProduct(newProduct);
if (resultado)
    Console.WriteLine("Producto insertado con exito");
else
    Console.WriteLine("No se pudo insertar el producto");