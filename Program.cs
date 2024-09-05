using System.Text;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese una oración: ");
            string oracion = Console.ReadLine();

            Console.WriteLine("Largo de la oración: " + oracion.Length);

            Console.Write("Ingrese una letra: ");
            char letra = Console.ReadLine()[0];
            int cantidadLetra = oracion.Count(c => c == letra);
            Console.WriteLine("La letra '" + letra + "' se repite " + cantidadLetra + " veces.");

            int cantidadVocales = oracion.Count(c => "aeiouAEIOU".Contains(c));
            Console.WriteLine("Cantidad de vocales: " + cantidadVocales);

            var largosPalabras = oracion.Split(' ').Select(palabra => palabra.Length);
            Console.WriteLine("Largo de cada palabra: " + string.Join(" - ", largosPalabras));

            string oracionReversa = new string(oracion.Reverse().ToArray());
            Console.WriteLine("Oración al revés: " + oracionReversa);

            string palabrasReversas = string.Join(" ", oracion.Split(' ').Select(p => new string(p.Reverse().ToArray())));
            Console.WriteLine("Palabras al revés: " + palabrasReversas);

            string oracionSinVocales = new string(oracion.Where(c => !"aeiouAEIOU".Contains(c)).ToArray());
            Console.WriteLine("Oración sin vocales: " + oracionSinVocales);

            string oracionMayusculas = oracion.ToUpper();
            Console.WriteLine("Oración en mayúsculas: " + oracionMayusculas);

            string oracionCifradaCesar = CifradoCesar(oracion, 3);
            Console.WriteLine("Oración cifrada con Cifrado de César: " + oracionCifradaCesar);

            string oracionCifradaSustitucion = CifradoSustitucion(oracion);
            Console.WriteLine("Oración cifrada con sustitución: " + oracionCifradaSustitucion);
        }

        static string CifradoCesar(string texto, int desplazamiento)
        {
            StringBuilder resultado = new StringBuilder();

            foreach (char c in texto)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    char nuevoCaracter = (char)(((c + desplazamiento - offset) % 26) + offset);
                    resultado.Append(nuevoCaracter);
                }
                else
                {
                    resultado.Append(c); 
                }
            }

            return resultado.ToString();
        }

        static string CifradoSustitucion(string texto)
        {
            char[] cifrado = texto.ToCharArray();

            for (int i = 0; i < cifrado.Length; i++)
            {
                switch (char.ToLower(cifrado[i]))
                {
                    case 'a': cifrado[i] = 'e'; break;
                    case 'e': cifrado[i] = 'i'; break;
                    case 'i': cifrado[i] = 'o'; break;
                    case 'o': cifrado[i] = 'u'; break;
                    case 'u': cifrado[i] = 'a'; break;
                    case 'A': cifrado[i] = 'E'; break;
                    case 'E': cifrado[i] = 'I'; break;
                    case 'I': cifrado[i] = 'O'; break;
                    case 'O': cifrado[i] = 'U'; break;
                    case 'U': cifrado[i] = 'A'; break;
                    default: break;
                }
            }

            return new string(cifrado);

        }
    }
}
