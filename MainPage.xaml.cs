namespace Medidor_de_IMC
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void CalcularIMCButton_Clicked(object sender, EventArgs e)
        {
            double imc;
            double altura = AlturaSlider.Value;
            double peso = PesoSlider.Value;
            string nome = NomeEntry.Text;
            string idade = IdadeEntry.Text;

            if (nome == null || idade == null || peso == null || altura == null || GeneroPicker.SelectedIndex == -1)
            {
                AvisoLabel.Text = "Preencha corretamente todas as informações";
                return;
            }

            else
            {
                imc = Math.Round(peso / (altura * altura), 1);

                IMCLabel.Text = $"IMC: {imc}";

                if (imc < 18.5)
                {
                    ClassificacaoIMCLabel.Text = "Classificação: Abaixo do Peso";
                    ClassificacaoIMCLabel.TextColor = Microsoft.Maui.Graphics.Colors.Red;
                }
                else if (imc < 24.9)
                {
                    ClassificacaoIMCLabel.Text = "Classificação: Peso Normal";
                    ClassificacaoIMCLabel.TextColor = Microsoft.Maui.Graphics.Colors.LightGreen;
                }
                else if (imc < 29.9)
                {
                    ClassificacaoIMCLabel.Text = "Classificação: Sobrepeso";
                    ClassificacaoIMCLabel.TextColor = Microsoft.Maui.Graphics.Colors.DarkGreen;
                }
                else if (imc < 34.9)
                {
                    ClassificacaoIMCLabel.Text = "Classificação: Obesidade grau I";
                    ClassificacaoIMCLabel.TextColor = Microsoft.Maui.Graphics.Colors.Orange;
                }
                else if (imc < 39.9)
                {
                    ClassificacaoIMCLabel.Text = "Classificação: Obesidade grau II";
                    ClassificacaoIMCLabel.TextColor = Microsoft.Maui.Graphics.Colors.OrangeRed;
                }
                else if (imc >= 40)
                {
                    ClassificacaoIMCLabel.Text = "Classificação: Obesidade grau III";
                    ClassificacaoIMCLabel.TextColor = Microsoft.Maui.Graphics.Colors.DarkRed;
                }
            }
        }

        private void AlturaSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double alturaArredondado = Math.Round(AlturaSlider.Value, 2);

            AlturaLabel.Text = $"Altura: {alturaArredondado}m";
        }

        private void PesoSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double pesoArredondado = Math.Round(PesoSlider.Value, 1);

            PesoLabel.Text = $"Peso: {pesoArredondado}KG";

        }
    }
}
