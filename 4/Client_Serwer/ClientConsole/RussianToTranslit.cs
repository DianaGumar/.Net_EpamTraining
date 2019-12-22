using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole
{
    class RussianToTranslit
    {

        public RussianToTranslit(Client s)
        {
            s.Notify += delegate (string mes)
            {
                Console.WriteLine(ToTranslit(mes));
            };

        }

        /// <summary>
        /// convert to translit all kirill symbols
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string ToTranslit(string str)
        {
            char[] a = str.ToCharArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] >= 'А' && a[i] <= 'я')
                {
                    switch (a[i])
                    {
                        case 'а': sb.Append("a"); break;
                        case 'б': sb.Append("b"); break;
                        case 'в': sb.Append("v"); break;
                        case 'г': sb.Append("g"); break;
                        case 'д': sb.Append("d"); break;
                        case 'е': sb.Append("e"); break;
                        case 'ё': sb.Append("ye"); break;
                        case 'ж': sb.Append("zh"); break;
                        case 'з': sb.Append("z"); break;
                        case 'и': sb.Append("i"); break;
                        case 'й': sb.Append("y"); break;
                        case 'к': sb.Append("k"); break;
                        case 'л': sb.Append("l"); break;
                        case 'м': sb.Append("m"); break;
                        case 'н': sb.Append("n"); break;
                        case 'о': sb.Append("o"); break;
                        case 'п': sb.Append("p"); break;
                        case 'р': sb.Append("r"); break;
                        case 'с': sb.Append("s"); break;
                        case 'т': sb.Append("t"); break;
                        case 'у': sb.Append("u"); break;
                        case 'ф': sb.Append("f"); break;
                        case 'х': sb.Append("ch"); break;
                        case 'ц': sb.Append("z"); break;
                        case 'ч': sb.Append("ch"); break;
                        case 'ш': sb.Append("sh"); break;
                        case 'щ': sb.Append("ch"); break;
                        case 'ъ': sb.Append(""); break;
                        case 'ы': sb.Append("y"); break;
                        case 'ь': sb.Append(""); break;
                        case 'э': sb.Append("e"); break;
                        case 'ю': sb.Append("yu"); break;
                        case 'я': sb.Append("ya"); break;
                        case 'А': sb.Append("A"); break;
                        case 'Б': sb.Append("B"); break;
                        case 'В': sb.Append("V"); break;
                        case 'Г': sb.Append("G"); break;
                        case 'Д': sb.Append("D"); break;
                        case 'Е': sb.Append("E"); break;
                        case 'Ё': sb.Append("Ye"); break;
                        case 'Ж': sb.Append("Zh"); break;
                        case 'З': sb.Append("Z"); break;
                        case 'И': sb.Append("I"); break;
                        case 'Й': sb.Append("Y"); break;
                        case 'К': sb.Append("K"); break;
                        case 'Л': sb.Append("L"); break;
                        case 'М': sb.Append("M"); break;
                        case 'Н': sb.Append("N"); break;
                        case 'О': sb.Append("O"); break;
                        case 'П': sb.Append("P"); break;
                        case 'Р': sb.Append("R"); break;
                        case 'С': sb.Append("S"); break;
                        case 'Т': sb.Append("T"); break;
                        case 'У': sb.Append("U"); break;
                        case 'Ф': sb.Append("F"); break;
                        case 'Х': sb.Append("Ch"); break;
                        case 'Ц': sb.Append("Z"); break;
                        case 'Ч': sb.Append("Ch"); break;
                        case 'Ш': sb.Append("Sh"); break;
                        case 'Щ': sb.Append("Ch"); break;
                        case 'Ъ': sb.Append(""); break;
                        case 'Ы': sb.Append("Y"); break;
                        case 'Ь': sb.Append(""); break;
                        case 'Э': sb.Append("E"); break;
                        case 'Ю': sb.Append("Yu"); break;
                        case 'Я': sb.Append("Ya"); break;

                    }
                }
                else
                {
                    sb.Append(a[i]);
                }
                    
            }

            return sb.ToString();
        }

    }
}
