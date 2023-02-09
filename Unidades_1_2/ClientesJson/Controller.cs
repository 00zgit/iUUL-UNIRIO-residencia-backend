using Atividade03;
using Atividade03.Q1;
using System;

static class Controller
{
	public static void Start()
	{
        List<ClienteForm>? cfList;
        Errors err = new();
        List<Cliente> cList = new();
        //
        // UI > CONTROLLER > VALIDADOR > ERROS > VALIDADOR > CONTROLLER > CLIENTE
        //

        // UI - CONTROLLER
        string strjson = ClienteForm.ReadJsonFile();
		cfList = ClienteForm.ReadData(strjson);

        // CONTROLLER - VALIDADOR - ERROS - VALIDADOR - CONTROLLER
        foreach(var cf in cfList)
        {
            while (!ValidaClienteForm.IsValid(cf, err))
                cf.ReadInvalidData(err);

            // CONTROLLER - CLIENTE
            Cliente c = new(cf);
            cList.Add(c);
        }
            

		

        //CONTROLLER - UI
        ClienteForm.PrintValidCliente(cList);

    }
}
