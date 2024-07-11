public static class Escape
{
    private static string[] incognitasSalas = { "1984", "3838", "y va el tercero", "farre", "chiquitapia" };
    private static int estadoJuego = 1;

    private static void InicializarJuego()
    {
        incognitasSalas = new string[] { "1984", "3838", "y va el tercero", "farre", "chiquitapia"};
        estadoJuego = 1;
    }

    public static int GetEstadoJuego() 
    {
        return estadoJuego;
    }

    public static bool ResolverSala(int sala, string incognita)
    {
        if (sala != estadoJuego || sala < 1 || sala > incognitasSalas.Length)
            return false;

        if (incognitasSalas[sala - 1] == incognita)
        {
            estadoJuego++;
            return true;
        }

        return false;
    }
}