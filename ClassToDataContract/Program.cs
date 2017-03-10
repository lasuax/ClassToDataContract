using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassToDataContract
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) { Console.WriteLine("No files specified."); return;} 
            var metin = args[0];
            var hedef = args.Length == 2 ? args[1] : "final.cs";
            var deneme = DosyadanOku(metin);
            var liste = Parcala(deneme);
            var siniflar = liste as IList<string> ?? liste.ToList();
            var usings = siniflar[0].Split(new []{"namespace"}, StringSplitOptions.None)[0]; // take usings
            var namespaces = "namespace" + siniflar[0].Split(new []{"namespace"}, StringSplitOptions.None)[1]; // namespace
            siniflar.RemoveAt(0); // remove usings
            var degisik = Degistir(siniflar);
            var final = usings + namespaces + degisik;
            Bitir(final, hedef);
        }

        private static void Bitir(string final, string yol)
        {
            using (var yazici = new StreamWriter(yol))
            {
                yazici.Write(final);
            }
        }

        private static string DosyadanOku(string yol)
        {
            string metin;
            using (var okuyucu = new StreamReader(yol))
            {
                metin = okuyucu.ReadToEnd();
            }
            return metin;
        }

        private static IEnumerable<string> Parcala(string metin)
        {
            return metin.Split(new[] { "public" }, StringSplitOptions.None).ToList();
        }

        private static string Degistir(IEnumerable<string> lstSiniflar)
        {
            string metin = null;
            foreach (var satir in lstSiniflar)
            {
                if (satir.Contains("class"))
                {
                    metin += $"\r\n    [DataContract]\r    public{satir}";
                }
                else
                {
                    metin += $"[DataMember]\r        public{satir}";
                }
            }
            return metin;
        }
    }
}
