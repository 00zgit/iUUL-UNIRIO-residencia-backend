using scb_externo.Models;
using scb_externo.Models.Enum;
using Stripe;
using System.Text.RegularExpressions;

namespace scb_externo.services
{
    public class StripeAPI
    {
        public StatusCobranca EnviaCobranca(CartaoDeCredito cartao, double valor)
        {
            StripeConfiguration.ApiKey = "sk_test_51MgDQ4LUdaMkb0K1hwXewx3t4hPLfLGIDwEMEfNkBKiuSMksGinGb5f1zvTamPdrfXWHCectjcD9J0aWVrU3Id88002hWXZn7e";
            var spllited = Regex.Split(cartao.Validade, "-");

            var paymentMethodService = new PaymentMethodService();
            var paymentMethod = paymentMethodService.Create(new PaymentMethodCreateOptions
            {
                Type = "card",
                Card = new PaymentMethodCardOptions
                {
                    Number = cartao.Numero,
                    ExpMonth = long.Parse(spllited[1]),
                    ExpYear = long.Parse(spllited[0]),
                    Cvc = cartao.Cvv,
                }
            });

            var options = new PaymentIntentCreateOptions
            {
                Amount = (long?)valor * 100,
                Currency = "brl",
                PaymentMethod = paymentMethod.Id,
                Confirm = true,
            };

            var service = new PaymentIntentService();

            try
            {
                var paymentIntent = service.Create(options);
            }
            catch (StripeException e)
            {
                switch (e.StripeError.Type)
                {
                    case "card_error":
                        return StatusCobranca.FALHA;
                    case "insufficient_funds":
                        return StatusCobranca.PENDENTE;
                    case "payment_method_provider_timeout":
                        return StatusCobranca.OCUPADA;
                    default:
                        return StatusCobranca.PENDENTE;
                }
            }

            return StatusCobranca.PAGA;
        }
    }
}
