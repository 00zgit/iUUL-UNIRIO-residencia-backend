using Atividade02.Q1;
using Empresa;
using System;

static class Controller
{
	public static void Start()
	{
		// UI > CONTROLLER > VALIDADOR > ERROS > VALIDADOR > CONTROLLER > CLIENTE
        ClienteForm cf = new();
        ValidaClienteForm vcf = new();
        Errors err = new();

		// UI - CONTROLLER
		cf = cf.ReadData();

        // CONTROLLER - VALIDADOR - ERROS - VALIDADOR - CONTROLLER
        while (!vcf.IsValid(cf, err))
            cf = cf.ReadInvalidData(err);

		// CONTROLLER - CLIENTE
		Cliente c = new(cf);

		//CONTROLLER - UI
		cf.PrintValidCliente(c);
		
	}
}
