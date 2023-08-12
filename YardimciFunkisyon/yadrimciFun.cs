namespace geometrik.YardimciFunkisyon
{
    public class yadrimciFun
    {
        public static bool arasinda(int x, int sol, int sag) { return x <= sag && x >= sol; }
        /// <summary>
        /// Noktanın koordinatlar ve mesafe dahilinde olup olmadığını kontrol edin
        /// </summary>
        /// <param name="x"></param>
        /// <param name="basla"></param>
        /// <param name="boy"></param>
        /// <returns></returns>
        public static bool isinde(int x, int basla, int boy) { return x <= basla + boy && x >= basla; }
    }
}
