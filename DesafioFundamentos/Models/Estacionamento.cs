namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            var placa = Console.ReadLine();
            if (VerificarPlacaExiste(placa))
            {
                Console.WriteLine($"Veiculo se encontra no estacionamento Placa: {placa}");
            }
            else
            {
                veiculos.Add(placa);
                Console.WriteLine($"Veiculo adicionado com sucesso Placa: {placa}");
            }

        }

        public bool VerificarPlacaExiste(string placa)
        {
            return veiculos.Count() > 0 && veiculos.Any(x => x.ToUpper() == placa.ToUpper());
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            if (VerificarPlacaExiste(placa))
            {
                bool isInt = false;
                int horas = 0;
                decimal valorTotal = 0;

                do
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    var horasText = Console.ReadLine();

                    isInt = int.TryParse(horasText, out horas);
                    if (!isInt)
                        Console.WriteLine("Favor digitar somente números inteiros.");

                } while (!isInt);

                valorTotal = precoInicial + (precoPorHora * horas);

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal.ToString("C")}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"- {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
