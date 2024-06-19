public static class Escape
{
    private static string[] incognitasSalas = { "1979", "75", "2014", "2018", "50", "2021" };
    private static int estadoJuego = 1;

    private static void InicializarJuego()
    {
        incognitasSalas = new string[] { "1979", "75", "2014", "2018", "50", "2021" };
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