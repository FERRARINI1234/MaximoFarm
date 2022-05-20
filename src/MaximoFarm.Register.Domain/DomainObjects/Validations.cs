namespace MaximoFarm.Register.Domain.DomainObjects
{
    public static class Validations
    {
	public static void ValidateIfEmpty(string valor, string mensagem)
	{
	    if (valor == null || valor.Trim( ).Length == 0)
	    {
		throw new DomainException( mensagem );
	    }
	}

	public static void ValidateIfEmpty(int valor, string mensagem)
	{
	    if (valor == 0)
	    {
		throw new DomainException( mensagem );
	    }
	}
    }
}
