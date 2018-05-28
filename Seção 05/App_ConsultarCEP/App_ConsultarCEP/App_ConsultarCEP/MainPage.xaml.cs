using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App_ConsultarCEP.Servico;
using App_ConsultarCEP.Servico.Modelo;

namespace App_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void BtnCep_Clicked(object sender, EventArgs e)
        {
            string cep = EtCep.Text.Trim();
            

            if(IsValidCep(cep))
            {
                try
                {
                    
                    Endereco endereco = ViaCepServico.BuscarEnderecoViaCEP(cep);

                    if(endereco != null)
                    {
                        lblResultado.Text = string.Format("Endereco: {0} {1} {2} {3}", endereco.Localidade, endereco.Uf, endereco.Bairro, endereco.Logradouro);
                    }
                    else
                    {
                        DisplayAlert("Erro", "O endereco não foi encontrado para o CEP informado", "OK");
                    }

                    
                }
                catch (Exception ex)
                {

                    DisplayAlert("Erro ", ex.Message, "OK");
                }
               
            }
            

           
        }

 

        private bool IsValidCep(string cep)
        {
            bool valido = true;
            if(cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP inválido! o cep deve conter 8 caracteres.", "OK");
                valido = false;
            }
            int NovoCep = 0;
            
            if(!int.TryParse(cep, out NovoCep))
            {
                DisplayAlert("Erro", "Cep inválido! o cep deve ser composto apenas por números", "Ok");

                valido = false;
            }

            return valido;
        }
    }
}
