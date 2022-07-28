using PAA_2022_EF_Intro.Models;

Console.WriteLine("Ejemplos de utilización de LinQ para BD:");

using (EFContext bd = new EFContext())
{

    //--------------------------------------------------------Lectura--------------------------------------------------------
    /* 1) Obtener los autores de manga cuyos IDs estén entre 1 y 4, ordenados por Id de forma descendente */
    var autoresOrdenados = bd.AutorManga
        .Where(x => x.Id >= 1 && x.Id <= 4)
        .OrderByDescending(x => x.Id)
        .ToList();

    Console.WriteLine("Listado de autores de manga ordenados via ID de mayor a menor");
    foreach (var AutorManga in autoresOrdenados)
    {
        Console.Write(AutorManga.Id);
        Console.Write(" ");
        Console.WriteLine(AutorManga.NombreAutor);
    }

    /* 2) Obtener el promedio de la cantidad de tomos de mangas */
    double promedioTomos = bd.Manga.Average(x => x.CantidadTomos);
        Console.WriteLine(" ");
        Console.WriteLine("Promeido de tomos entre los mangas");
        Console.WriteLine(promedioTomos);
        Console.WriteLine(" ");

    /* 3) Obtener la fecha menor de los autores */
    DateTime min = bd.AutorManga.Min(x => x.FechaNacimiento);
    Console.WriteLine(" ");
    Console.Write("La primera persona en nacer de las ingresadas nació el día: ");
    Console.Write(min);
    Console.WriteLine(" ");


    //--------------------------------------------------------Escritura--------------------------------------------------------
    /* 4) Insertar un nuevo autor de manga, sin un ID existente aun, que posea
           las siguientes características:
           Nombre: "Yuki Tabata", Fecha de nacimiento: El 30 de julio del 1984,
           Se sabe la actual actividad del autor. 
           Cantidad de obras: 6                   
    */

    AutorManga nuevoAutor = new AutorManga()
    {
        Id = 5,
        NombreAutor = "Yuki Tabata",
        FechaNacimiento = Convert.ToDateTime("1984-07-30"),
        Activo = true,
        CantidadObras = 6
    };

    bd.AutorManga.Add(nuevoAutor);
    bd.SaveChanges();

    Console.WriteLine(" ");
    Console.Write("Se añadió el autor: ");
    Console.Write(nuevoAutor.NombreAutor);
    Console.WriteLine(" ");


    //--------------------------------------------------------Actualización--------------------------------------------------------
    /* 5) Actualizar el Nombre del autor "Akira Toriyama" a "Toriyama" y la cantidad de obras de 50 a 51
           a través de la búsqueda de su id */
    var autorEditar = bd.AutorManga.FirstOrDefault(x => x.Id == 3);

    autorEditar.NombreAutor = "Toriyama";
    autorEditar.CantidadObras = 51;
    bd.AutorManga.Update(autorEditar);
    bd.SaveChanges(); 

    Console.WriteLine(" ");
    Console.WriteLine("Se actualizaron los siguientes datos del autor Akira Toriyama: ");
    Console.Write("Nombre: ");
    Console.Write(autorEditar.NombreAutor);
    Console.WriteLine(" ");
    Console.Write("Cantidad de obras: ");
    Console.Write(autorEditar.CantidadObras);
    Console.WriteLine(" ");

    //--------------------------------------------------------Eliminación--------------------------------------------------------
    /* 6) Eliminar el manga "Tomie"
          a través de la búsqueda de su ID (21)
    */

    var mangaElminar = bd.Manga.FirstOrDefault(x => x.Id == 21);
    bd.Manga.Remove(mangaElminar);
    bd.SaveChanges();
    Console.WriteLine(" ");
    Console.Write("Se eliminó el manga: ");
    Console.Write(mangaElminar.NombreManga);
    Console.WriteLine(" ");
}
