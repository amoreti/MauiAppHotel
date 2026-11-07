using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;
	public ContratacaoHospedagem()
	{
		InitializeComponent();
        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Today;
        dtpck_checkin.MaximumDate = DateTime.Today.AddMonths(1);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date.Value.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkout.Date.Value.AddMonths(6);
    }

    private async void BtnSobre_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new Sobre());

        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }

    private async void BtnAvancar_Clicked(object sender, EventArgs e)
    {
        try
        {
            Hospedagem h = new Hospedagem()
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),
                DataCheckIn = (DateTime)dtpck_checkin.Date,
                DataCheckOut = (DateTime)dtpck_checkout.Date,
            };

            await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = h
            });
            
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }
    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = elemento.Date.Value;

        dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }
}