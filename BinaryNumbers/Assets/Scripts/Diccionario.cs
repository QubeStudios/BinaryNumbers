using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class Diccionario
    {
        Dictionary<char, string> diccionario = new Dictionary<char, string>();
        public Diccionario()
        {
            diccionario.Add('A', "00001");

            diccionario.Add('B', "00010");
            diccionario.Add('C', "00011");

            diccionario.Add('D', "00100");
            diccionario.Add('E', "00101");
            diccionario.Add('F', "00110");
            diccionario.Add('G', "00111");

            diccionario.Add('H', "01000");
            diccionario.Add('I', "01001");
            diccionario.Add('J', "01010");
            diccionario.Add('K', "01011");
            diccionario.Add('L', "01100");
            diccionario.Add('M', "01101");
            diccionario.Add('N', "01110");
            diccionario.Add('Ñ', "01111");

            diccionario.Add('O', "10000");
            diccionario.Add('P', "10001");
            diccionario.Add('Q', "10010");
            diccionario.Add('R', "10011");
            diccionario.Add('S', "10100");
            diccionario.Add('T', "10101");
            diccionario.Add('U', "10110");
            diccionario.Add('V', "10111");
            diccionario.Add('W', "11000");
            diccionario.Add('X', "11001");
            diccionario.Add('Y', "11010");
            diccionario.Add('Z', "11011");
        }
        public string obtenerKey(char letra)
        {
            return diccionario[letra];
        }
    }
}
